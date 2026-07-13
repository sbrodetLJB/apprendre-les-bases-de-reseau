# Correcteur

Outil de correction automatique pour les TP de ce dépôt. Contrairement aux correcteurs des
autres cours (qui exécutent du code ou une requête), celui-ci ne fait **aucune exécution** :
chaque TP de ce cours est un calcul sur papier, donc le correcteur compare simplement le
texte d'une réponse à celui du corrigé, champ par champ.

## Installation

Aucune : uniquement .NET (9.0+), aucune dépendance externe (pas de package NuGet, pas de
serveur, pas de base de données).

## Utilisation

Depuis la racine du dépôt :

```bash
# Un seul élève
dotnet run --project correcteur -- --tp 05 --student dupont_jean

# Tous les élèves d'un TP
dotnet run --project correcteur -- --tp 05 --all

# Lister les TP couverts
dotnet run --project correcteur -- --list
```

Les rapports sont écrits dans `rapports/<tp>/<eleve>.md` (et `_sommaire.md` en mode `--all`).
Ces dossiers, ainsi que `soumissions/`, sont gitignorés.

## Où déposer les rendus

Un dossier par élève et par TP, sous `soumissions/<nom-complet-du-dossier-tp>/<eleve>/`, avec
les mêmes noms de fichiers que dans `tp/<tp>/Enonce/` :

```
soumissions/
  05-masques-et-cidr/
    dupont_jean/
      01-conversion-masques.txt
      02-calcul-reseau-1.txt
      03-calcul-reseau-2.txt
```

## Comment ça marche

1. Pour chaque exercice de la fixture, le fichier de référence (`Corrige/`) et le fichier
   rendu par l'élève sont lus comme une suite de paires `Clé : valeur` — une par ligne, les
   lignes vides et celles commençant par `#` sont ignorées (voir [NVDA.md](../NVDA.md),
   section 3, pour le détail du format).
2. Chaque valeur du corrigé est comparée à la valeur correspondante rendue par l'élève, après
   normalisation (espaces superflus supprimés, casse ignorée).
3. L'exercice est validé seulement si **tous** ses champs correspondent. En cas d'écart, le
   rapport indique précisément quel champ diffère, avec la valeur attendue et celle obtenue.

## Écrire une fixture

```json
{
  "tp": "05-masques-et-cidr",
  "cases": [
    {
      "name": "2 - calcul complet 192.168.5.130/27",
      "referenceFile": "tp/05-masques-et-cidr/Corrige/02-calcul-reseau-1.txt",
      "studentFile": "02-calcul-reseau-1.txt"
    }
  ]
}
```

`referenceFile` pointe vers le fichier `Corrige/` correspondant ; `studentFile` est le nom de
fichier attendu dans le dossier de l'élève.

## Limites connues

- La normalisation est volontairement simple (espaces, casse) : **les accents comptent**.
  Plutôt que de deviner toutes les formes équivalentes possibles pour une notation (adresse
  IPv6 compressée ou développée, masque en décimal ou en CIDR...), chaque énoncé précise
  explicitement le format attendu — voir la remarque à ce sujet dans le plan de ce cours et
  dans chaque `Enonce/`.
- Un champ du corrigé absent de la réponse de l'élève est traité comme un échec sur ce champ
  (pas une erreur bloquante) : le reste de l'exercice continue d'être corrigé normalement.
- Comme il n'y a rien à exécuter, une réponse fausse mais qui "a l'air correcte" (une adresse
  qui existe mais qui n'est pas celle attendue) n'est jamais rattrapée autrement que par la
  comparaison texte — d'où l'importance de recalculer indépendamment chaque valeur du dossier
  `Corrige/` avant de le publier (voir le plan de ce cours).
