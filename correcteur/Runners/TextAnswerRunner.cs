using System.Globalization;
using System.Text.RegularExpressions;
using Correcteur.Models;

namespace Correcteur.Runners;

/// <summary>
/// Compare un fichier réponse d'élève au fichier de référence correspondant, paire par paire
/// "Clé : valeur". Aucune exécution, aucune base de données : la correction est purement
/// textuelle (voir correcteur/README.md, section "Comment ça marche").
/// </summary>
public static class TextAnswerRunner
{
    public static CaseResult Run(AnswerCheckCase testCase, string repoRoot, string studentDir)
    {
        var referencePath = Path.Combine(repoRoot, testCase.ReferenceFile);
        var studentPath = Path.Combine(studentDir, testCase.StudentFile);

        if (!File.Exists(referencePath))
        {
            throw new InvalidOperationException($"Fichier de référence introuvable : {referencePath}");
        }

        if (!File.Exists(studentPath))
        {
            return new CaseResult
            {
                Name = testCase.Name,
                MissingFileError = $"Fichier attendu introuvable : {testCase.StudentFile}",
            };
        }

        var reference = ParseAnswerFile(referencePath);
        var student = ParseAnswerFile(studentPath);

        var mismatches = new List<FieldMismatch>();
        foreach (var (key, expectedValue) in reference)
        {
            var studentValue = student.FirstOrDefault(kv => NormalizeKey(kv.Key) == NormalizeKey(key)).Value;

            if (studentValue is null || Normalize(studentValue) != Normalize(expectedValue))
            {
                mismatches.Add(new FieldMismatch
                {
                    Field = key,
                    Expected = expectedValue,
                    Obtained = studentValue ?? "(champ absent)",
                });
            }
        }

        return new CaseResult
        {
            Name = testCase.Name,
            Mismatches = mismatches,
        };
    }

    /// <summary>
    /// Lit un fichier de réponses : une paire "Clé : valeur" par ligne, lignes vides et
    /// commentaires ("#...") ignorés. Le format est décrit dans NVDA.md, section 3.
    /// </summary>
    private static List<(string Key, string Value)> ParseAnswerFile(string path)
    {
        var result = new List<(string, string)>();

        foreach (var rawLine in File.ReadAllLines(path))
        {
            var line = rawLine.Trim();
            if (line.Length == 0 || line.StartsWith('#'))
            {
                continue;
            }

            // Le délimiteur "clé : valeur" est toujours un espace suivi d'un ":" (jamais un
            // simple ":" isolé) : une clé peut elle-même contenir des deux-points (adresse
            // IPv6, ex. "fe80::1 : link-local"), donc chercher le premier ":" tout court
            // couperait la clé en plein milieu.
            var separatorIndex = line.IndexOf(" :", StringComparison.Ordinal);
            if (separatorIndex < 0)
            {
                continue;
            }

            var key = line[..separatorIndex].Trim();
            var value = line[(separatorIndex + 2)..].Trim();
            result.Add((key, value));
        }

        return result;
    }

    private static string NormalizeKey(string key) => Normalize(key);

    /// <summary>
    /// Normalisation volontairement simple (espaces, casse) — voir "Limites connues" dans
    /// correcteur/README.md : chaque énoncé précise le format exact attendu plutôt que de
    /// faire reposer la correction sur une normalisation plus permissive (accents, formes
    /// équivalentes...).
    /// </summary>
    private static string Normalize(string value)
    {
        var collapsed = Regex.Replace(value.Trim(), @"\s+", " ");
        return collapsed.ToLower(CultureInfo.InvariantCulture);
    }
}
