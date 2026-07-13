namespace Correcteur.Models;

public sealed class FieldMismatch
{
    public required string Field { get; init; }

    public required string Expected { get; init; }

    public required string Obtained { get; init; }
}

public sealed class CaseResult
{
    public required string Name { get; init; }

    public bool Passed => Mismatches.Count == 0 && MissingFileError is null;

    public string? MissingFileError { get; init; }

    public List<FieldMismatch> Mismatches { get; init; } = [];
}

public sealed class StudentReport
{
    public required string Student { get; init; }

    public required string TpFolderName { get; init; }

    public required DateTime GeneratedAt { get; init; }

    public required List<CaseResult> Cases { get; init; }

    public int Passed => Cases.Count(c => c.Passed);

    public int Total => Cases.Count;
}
