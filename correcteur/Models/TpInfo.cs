namespace Correcteur.Models;

/// <summary>
/// Un TP localisé sur le disque : son numéro à deux chiffres, le nom complet de son dossier
/// (ex. "06-decoupage-en-sous-reseaux") et le chemin absolu de sa fixture JSON.
/// </summary>
public sealed record TpInfo(string Number, string FolderName, string FixturePath);
