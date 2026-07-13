# 2. Numération binaire

## Pourquoi le binaire

Un ordinateur ne manipule que deux états électriques : présence ou absence de signal, 0 ou
1. Toute l'informatique repose là-dessus, et le réseau ne fait pas exception : une adresse
IP, un masque de sous-réseau, une adresse MAC sont, sous le capot, une suite de 0 et de 1.
Savoir convertir rapidement entre décimal et binaire (et bientôt hexadécimal, leçon 3) est le
prérequis technique de tout le reste de ce cours, en particulier des leçons 5 et 6 sur les
masques et le découpage en sous-réseaux.

## Rappel : comment fonctionne notre système décimal

Le système décimal (base 10, celui qu'on utilise tous les jours) donne à chaque position
d'un nombre un **poids** qui est une puissance de 10 : unités (10⁰ = 1), dizaines
(10¹ = 10), centaines (10² = 100), etc. Un nombre est simplement la somme de ses chiffres
multipliés par le poids de leur position. Exemple avec 247 :

```
    2       4       7
 x100    x10     x1
= 200  +  40   +  7   = 247
```

Le binaire (base 2) fonctionne exactement pareil, sauf que la base n'est plus 10 mais 2 : les
seuls chiffres possibles sont 0 et 1, et chaque position vaut une puissance de 2 plutôt qu'une
puissance de 10.

## Les poids d'un octet

En réseau, on raisonne presque toujours par paquets de 8 bits (un **octet**, aussi appelé
*byte*) — c'est la taille d'un des quatre nombres d'une adresse IPv4 (leçon 4). Voici les
poids des 8 positions d'un octet, à connaître par cœur :

| Position | 8 | 7 | 6 | 5 | 4 | 3 | 2 | 1 |
|---|---|---|---|---|---|---|---|---|
| Poids | 128 | 64 | 32 | 16 | 8 | 4 | 2 | 1 |

## Convertir du binaire vers le décimal

**Méthode** : additionner les poids des positions où le bit vaut 1.

Exemple : convertir `10110100` en décimal.

| Poids | 128 | 64 | 32 | 16 | 8 | 4 | 2 | 1 |
|---|---|---|---|---|---|---|---|---|
| Bit | 1 | 0 | 1 | 1 | 0 | 1 | 0 | 0 |

Bits à 1 : positions 128, 32, 16 et 4. Somme : 128 + 32 + 16 + 4 = **180**.

## Convertir du décimal vers le binaire

**Méthode** : divisions successives par 2, en gardant le reste à chaque étape ; le résultat
se lit **du dernier reste obtenu vers le premier**.

Exemple : convertir 91 en binaire.

| Division | Quotient | Reste |
|---|---|---|
| 91 ÷ 2 | 45 | 1 |
| 45 ÷ 2 | 22 | 1 |
| 22 ÷ 2 | 11 | 0 |
| 11 ÷ 2 | 5 | 1 |
| 5 ÷ 2 | 2 | 1 |
| 2 ÷ 2 | 1 | 0 |
| 1 ÷ 2 | 0 | 1 |

On lit les restes du bas vers le haut : `1011011`. Sur un octet (8 bits), on complète avec un
zéro devant pour arriver à 8 chiffres : **`01011011`**.

Vérification (toujours utile) : 64 + 16 + 8 + 2 + 1 = 91. ✓

## Les opérations bit à bit ET et OU

Ces deux opérations combinent deux suites de bits **position par position**, indépendamment
les unes des autres. Elles seront la base du calcul des masques de sous-réseau (leçon 5).

| A | B | A ET B | A OU B |
|---|---|---|---|
| 0 | 0 | 0 | 0 |
| 0 | 1 | 0 | 1 |
| 1 | 0 | 0 | 1 |
| 1 | 1 | 1 | 1 |

- **ET** (`AND`) : le résultat vaut 1 seulement si les deux bits valent 1. Retenir : ET avec
  1 conserve le bit d'origine, ET avec 0 le force à 0 — quel que soit ce bit d'origine.
- **OU** (`OR`) : le résultat vaut 1 si au moins un des deux bits vaut 1. Retenir : OU avec 0
  conserve le bit d'origine, OU avec 1 le force à 1.

Exemple, position par position, sur un octet entier :

```
  10101100
ET 11110000
----------
  10100000
```

Les 4 premiers bits de `10101100` sont conservés (ET avec 1), les 4 derniers sont forcés à 0
(ET avec 0) — exactement le principe qu'utilisera un masque de sous-réseau.

**Suite : [3. Numération hexadécimale et octale](03-numeration-hexadecimale-octale.md)**
