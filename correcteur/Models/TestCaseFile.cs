namespace Correcteur.Models;

/// <summary>
/// Une fixture de correction pour un TP : une liste de cas, chacun comparant un fichier
/// réponse de l'élève au fichier de référence correspondant dans Corrige/.
/// </summary>
public sealed class TestCaseFile
{
    public required string Tp { get; init; }

    public required List<AnswerCheckCase> Cases { get; init; }
}

/// <summary>
/// Un cas correspond à un fichier d'exercice (Enonce/Corrige) : la comparaison se fait champ
/// par champ, sur les paires "Clé : valeur" des deux fichiers.
/// </summary>
public sealed class AnswerCheckCase
{
    public required string Name { get; init; }

    public required string ReferenceFile { get; init; }

    public required string StudentFile { get; init; }
}
