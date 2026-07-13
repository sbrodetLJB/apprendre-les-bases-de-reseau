# Pas à pas — TP 3 : numération hexadécimale et octale

Garde sous les yeux le cours
[03-numeration-hexadecimale-octale.md](../../docs/03-numeration-hexadecimale-octale.md), en
particulier la table de correspondance décimal/hexadécimal/binaire.

## Exercice 1 : binaire ↔ hexadécimal

Pour les quatre premières lignes de `Enonce/01-binaire-hexadecimal.txt`, découpe les 8 bits
en deux groupes de 4 (le premier quartet, puis le second), et convertis chaque quartet
séparément avec la table du cours.

Exemple détaillé avec `00101010` :

```
0010 | 1010
```

- `0010` = 2
- `1010` = A

Résultat : **`2A`**.

Pour la dernière ligne (`9F`, hexadécimal vers binaire), fais l'inverse : chaque chiffre
hexadécimal redevient son quartet de 4 bits.

- `9` = `1001`
- `F` = `1111`

Résultat : **`10011111`**.

## Exercice 2 : hexadécimal ↔ décimal

Pour `9F` et `3C` (hexadécimal vers décimal), multiplie le premier chiffre par 16 et ajoute
le second.

Exemple détaillé avec `3C` : 3×16 + C×1 = 3×16 + 12 = 48 + 12 = **60**.

Pour 202 et 58 (décimal vers hexadécimal), utilise les divisions successives par 16 (voir le
cours). Exemple détaillé avec 58 :

| Division | Quotient | Reste |
|---|---|---|
| 58 ÷ 16 | 3 | 10 (= A) |
| 3 ÷ 16 | 0 | 3 |

Restes du bas vers le haut : `3`, `A` → **`3A`**. Vérification : 3×16 + 10 = 58. ✓

## Exercice 3 : l'octal

Même principe qu'entre binaire et hexadécimal, mais avec des groupes de **3** bits.

Exemple détaillé avec `101110` (binaire vers octal) :

```
101 | 110
```

- `101` = 5
- `110` = 6

Résultat : **`56`**.

Pour `27` (octal vers décimal) : 2×8 + 7×1 = 16 + 7 = 23. Pour 100 (décimal vers octal),
divisions successives par 8, comme pour l'hexadécimal mais avec 8 à la place de 16.

## Vérifier son travail

Pense à toujours écrire l'hexadécimal en majuscules. Compare avec les fichiers
correspondants dans `Corrige/` si besoin.

**Suite : [4. Adressage IPv4](../../docs/04-adressage-ipv4.md)**
