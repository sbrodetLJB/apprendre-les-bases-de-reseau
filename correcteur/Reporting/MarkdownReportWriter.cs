using System.Text;
using Correcteur.Models;

namespace Correcteur.Reporting;

public static class MarkdownReportWriter
{
    public static string Write(StudentReport report)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"# Rapport de correction — TP {report.TpFolderName}");
        sb.AppendLine();
        sb.AppendLine($"- Élève : **{report.Student}**");
        sb.AppendLine($"- Date : {report.GeneratedAt:yyyy-MM-dd HH:mm}");
        sb.AppendLine();

        sb.AppendLine("## Résultats");
        sb.AppendLine();
        sb.AppendLine("| # | Exercice | Résultat |");
        sb.AppendLine("|---|----------|----------|");
        for (var i = 0; i < report.Cases.Count; i++)
        {
            var c = report.Cases[i];
            sb.AppendLine($"| {i + 1} | {c.Name} | {(c.Passed ? "✅" : "❌")} |");
        }

        sb.AppendLine();

        var failed = report.Cases.Where(c => !c.Passed).ToList();
        if (failed.Count > 0)
        {
            sb.AppendLine("## Détail des échecs");
            sb.AppendLine();
            foreach (var c in failed)
            {
                sb.AppendLine($"### {c.Name}");
                sb.AppendLine();

                if (c.MissingFileError is not null)
                {
                    sb.AppendLine(c.MissingFileError);
                }
                else
                {
                    sb.AppendLine("| Champ | Attendu | Obtenu |");
                    sb.AppendLine("|---|---|---|");
                    foreach (var m in c.Mismatches)
                    {
                        sb.AppendLine($"| {m.Field} | {m.Expected} | {m.Obtained} |");
                    }
                }

                sb.AppendLine();
            }
        }

        sb.AppendLine("## Score");
        sb.AppendLine();
        sb.AppendLine($"**{report.Passed} / {report.Total}** exercice(s) correct(s) (comparaison champ par champ, pas de texte libre).");

        return sb.ToString();
    }
}
