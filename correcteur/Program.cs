using System.Text.Json;
using Correcteur.Models;
using Correcteur.Reporting;
using Correcteur.Runners;

var repoRoot = TpLocator.FindRepoRoot();

if (args.Contains("--list"))
{
    var tps = TpLocator.ListAll(repoRoot);
    if (tps.Count == 0)
    {
        Console.WriteLine("Aucun TP couvert par le correcteur pour l'instant.");
        return 0;
    }

    Console.WriteLine("TP couverts par le correcteur :");
    foreach (var tp in tps)
    {
        Console.WriteLine($"  {tp.Number} — {tp.FolderName}");
    }

    return 0;
}

var tpNumber = GetOptionValue(args, "--tp");
if (tpNumber is null)
{
    Console.Error.WriteLine("Usage : dotnet run --project correcteur -- --tp NN --student <eleve>");
    Console.Error.WriteLine("        dotnet run --project correcteur -- --tp NN --all");
    Console.Error.WriteLine("        dotnet run --project correcteur -- --list");
    return 1;
}

var tpInfo = TpLocator.Find(repoRoot, tpNumber);
if (tpInfo is null)
{
    Console.Error.WriteLine($"TP \"{tpNumber}\" introuvable ou non couvert par le correcteur (voir --list).");
    return 1;
}

var fixtureJson = File.ReadAllText(tpInfo.FixturePath);
var fixture = JsonSerializer.Deserialize<TestCaseFile>(fixtureJson, new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
})!;

var soumissionsRoot = Path.Combine(repoRoot, "soumissions", tpInfo.FolderName);
var rapportsRoot = Path.Combine(repoRoot, "rapports", tpInfo.FolderName);
Directory.CreateDirectory(rapportsRoot);

var studentOption = GetOptionValue(args, "--student");
if (args.Contains("--all"))
{
    if (!Directory.Exists(soumissionsRoot))
    {
        Console.Error.WriteLine($"Aucune soumission trouvée dans soumissions/{tpInfo.FolderName}/");
        return 1;
    }

    var students = Directory.EnumerateDirectories(soumissionsRoot)
        .Select(Path.GetFileName)
        .Where(name => name is not null)
        .Select(name => name!)
        .OrderBy(name => name, StringComparer.InvariantCulture)
        .ToList();

    if (students.Count == 0)
    {
        Console.Error.WriteLine($"Aucune soumission trouvée dans soumissions/{tpInfo.FolderName}/");
        return 1;
    }

    var reports = new List<StudentReport>();
    foreach (var student in students)
    {
        var report = CorrectStudent(fixture, repoRoot, tpInfo, soumissionsRoot, student);
        reports.Add(report);
        WriteReport(rapportsRoot, student, report);
        Console.WriteLine($"{student} : {report.Passed}/{report.Total}");
    }

    var summaryPath = Path.Combine(rapportsRoot, "_sommaire.md");
    File.WriteAllText(summaryPath, SummaryWriter.Write(tpInfo.FolderName, reports));
    Console.WriteLine($"Sommaire écrit dans {summaryPath}");

    return 0;
}

if (studentOption is null)
{
    Console.Error.WriteLine("Précise --student <eleve> ou --all.");
    return 1;
}

var singleReport = CorrectStudent(fixture, repoRoot, tpInfo, soumissionsRoot, studentOption);
WriteReport(rapportsRoot, studentOption, singleReport);
Console.WriteLine($"{studentOption} : {singleReport.Passed}/{singleReport.Total}");

return 0;

static StudentReport CorrectStudent(TestCaseFile fixture, string repoRoot, TpInfo tpInfo, string soumissionsRoot, string student)
{
    var studentDir = Path.Combine(soumissionsRoot, student);
    var results = fixture.Cases
        .Select(c => TextAnswerRunner.Run(c, repoRoot, studentDir))
        .ToList();

    return new StudentReport
    {
        Student = student,
        TpFolderName = tpInfo.FolderName,
        GeneratedAt = DateTime.Now,
        Cases = results,
    };
}

static void WriteReport(string rapportsRoot, string student, StudentReport report)
{
    var path = Path.Combine(rapportsRoot, $"{student}.md");
    File.WriteAllText(path, MarkdownReportWriter.Write(report));
}

static string? GetOptionValue(string[] args, string optionName)
{
    var index = Array.IndexOf(args, optionName);
    if (index < 0 || index + 1 >= args.Length)
    {
        return null;
    }

    return args[index + 1];
}
