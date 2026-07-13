using System.Text;
using Correcteur.Models;

namespace Correcteur.Reporting;

public static class SummaryWriter
{
    public static string Write(string tpFolderName, List<StudentReport> reports)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"# Sommaire — TP {tpFolderName}");
        sb.AppendLine();
        sb.AppendLine($"Généré le {DateTime.Now:yyyy-MM-dd HH:mm} — {reports.Count} élève(s).");
        sb.AppendLine();
        sb.AppendLine("| Élève | Score | Statut |");
        sb.AppendLine("|-------|-------|--------|");

        foreach (var report in reports.OrderBy(r => r.Student, StringComparer.InvariantCulture))
        {
            var statut = report.Passed == report.Total ? "✅ (tout bon)" : report.Passed == 0 ? "❌" : "⚠️ (partiel)";
            sb.AppendLine($"| {report.Student} | {report.Passed}/{report.Total} | {statut} |");
        }

        return sb.ToString();
    }
}
