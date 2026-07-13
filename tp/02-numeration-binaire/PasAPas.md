# Pas à pas — TP 2 : numération binaire

Garde sous les yeux le cours [02-numeration-binaire.md](../../docs/02-numeration-binaire.md).

## Exercice 1 : binaire vers décimal

Pour chaque ligne de `Enonce/01-binaire-vers-decimal.txt`, place les 8 bits sous les poids
`128 64 32 16 8 4 2 1` et additionne les poids où le bit vaut 1.

Exemple détaillé avec `11111000` :

| Poids | 128 | 64 | 32 | 16 | 8 | 4 | 2 | 1 |
|---|---|---|---|---|---|---|---|---|
| Bit | 1 | 1 | 1 | 1 | 1 | 0 | 0 | 0 |

Bits à 1 : 128, 64, 32, 16, 8. Somme : 128+64+32+16+8 = **248**.

Fais le même travail pour les quatre autres lignes du fichier.

## Exercice 2 : décimal vers binaire

Pour chaque ligne de `Enonce/02-decimal-vers-binaire.txt`, utilise les divisions successives
par 2 (voir le cours), puis complète avec des zéros de tête pour arriver à 8 chiffres.

Exemple détaillé avec 34 :

| Division | Quotient | Reste |
|---|---|---|
| 34 ÷ 2 | 17 | 0 |
| 17 ÷ 2 | 8 | 1 |
| 8 ÷ 2 | 4 | 0 |
| 4 ÷ 2 | 2 | 0 |
| 2 ÷ 2 | 1 | 0 |
| 1 ÷ 2 | 0 | 1 |

Restes du bas vers le haut : `100010`, soit 6 chiffres. Sur 8 bits, on ajoute deux zéros de
tête : **`00100010`**. Vérification : 32 + 2 = 34. ✓

Fais le même travail pour les quatre autres lignes du fichier.

## Exercice 3 : opérations ET et OU

Pour chaque ligne de `Enonce/03-operations-et-ou.txt`, applique l'opération demandée
**position par position** (voir la table de vérité du cours), sans jamais faire "déborder"
un bit sur son voisin — chaque position se calcule indépendamment des autres.

Exemple détaillé avec `10101100 OU 11110000` :

```
  10101100
OU 11110000
-----------
  11111100
```

Position par position : 1|1=1, 0|1=1, 1|1=1, 0|1=1, 1|0=1, 1|0=1, 0|0=0, 0|0=0.

Fais le même travail pour les trois autres lignes du fichier.

## Vérifier son travail

Chaque réponse doit être une suite de chiffres 0/1 (exercices 2 et 3, toujours sur 8 bits)
ou un nombre décimal (exercice 1). Compare avec les fichiers correspondants dans `Corrige/`
si besoin.

**Suite : [3. Numération hexadécimale et octale](../../docs/03-numeration-hexadecimale-octale.md)**
