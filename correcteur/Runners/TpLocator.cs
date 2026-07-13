using Correcteur.Models;

namespace Correcteur.Runners;

public static class TpLocator
{
    /// <summary>
    /// Remonte les dossiers parents jusqu'à trouver "tp/" et "correcteur/" côte à côte —
    /// permet d'invoquer le correcteur depuis n'importe quel dossier de travail.
    /// </summary>
    public static string FindRepoRoot()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir is not null)
        {
            if (Directory.Exists(Path.Combine(dir.FullName, "tp")) &&
                Directory.Exists(Path.Combine(dir.FullName, "correcteur")))
            {
                return dir.FullName;
            }

            dir = dir.Parent;
        }

        throw new InvalidOperationException(
            "Impossible de localiser la racine du dépôt (dossiers \"tp\" et \"correcteur\" introuvables côte à côte).");
    }

    public static TpInfo? Find(string repoRoot, string tpNumber)
    {
        var testcasesDir = Path.Combine(repoRoot, "correcteur", "testcases");
        var fixturePath = Path.Combine(testcasesDir, $"{tpNumber}.json");
        if (!File.Exists(fixturePath))
        {
            return null;
        }

        var tpDir = Path.Combine(repoRoot, "tp");
        var folder = Directory.EnumerateDirectories(tpDir, $"{tpNumber}-*")
            .Select(Path.GetFileName)
            .FirstOrDefault();

        if (folder is null)
        {
            return null;
        }

        return new TpInfo(tpNumber, folder, fixturePath);
    }

    public static List<TpInfo> ListAll(string repoRoot)
    {
        var testcasesDir = Path.Combine(repoRoot, "correcteur", "testcases");
        if (!Directory.Exists(testcasesDir))
        {
            return [];
        }

        var result = new List<TpInfo>();
        foreach (var file in Directory.EnumerateFiles(testcasesDir, "*.json").OrderBy(f => f))
        {
            var number = Path.GetFileNameWithoutExtension(file);
            var info = Find(repoRoot, number);
            if (info is not null)
            {
                result.Add(info);
            }
        }

        return result;
    }
}
