# 3. Numération hexadécimale et octale

## Pourquoi l'hexadécimal

Écrire une adresse en binaire est fiable mais long : une adresse IPv6 (leçon 8) fait 128
bits, une adresse MAC (leçon 10) en fait 48. L'**hexadécimal** (base 16) résout ce problème
d'une façon particulièrement élégante : **un seul chiffre hexadécimal représente exactement
4 bits** (un groupe de 4 bits s'appelle un **quartet**). Un octet (8 bits) s'écrit donc
toujours avec exactement 2 chiffres hexadécimaux, ni plus ni moins.

C'est pour cette raison, et pas par hasard, que les adresses MAC et IPv6 s'écrivent en
hexadécimal : c'est la notation la plus compacte qui reste malgré tout directement
traduisible en binaire, quartet par quartet, sans aucun calcul complexe.

## Les 16 chiffres hexadécimaux

La base 16 a besoin de 16 chiffres. Au-delà de 9, on utilise les lettres A à F :

| Décimal | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Hexadécimal | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | A | B | C | D | E | F |
| Binaire (4 bits) | 0000 | 0001 | 0010 | 0011 | 0100 | 0101 | 0110 | 0111 | 1000 | 1001 | 1010 | 1011 | 1100 | 1101 | 1110 | 1111 |

Cette table est la plus utile de toute la leçon : elle permet de convertir directement entre
binaire et hexadécimal, quartet par quartet, sans passer par le décimal.

## Convertir du binaire vers l'hexadécimal

**Méthode** : découper les bits en groupes de 4, **en partant de la droite**, puis convertir
chaque groupe séparément grâce à la table ci-dessus.

Exemple : convertir `10110100` en hexadécimal.

```
1011 | 0100
```

- `1011` = B (voir la table)
- `0100` = 4

Résultat : **`B4`**.

## Convertir de l'hexadécimal vers le binaire

**Méthode inverse** : chaque chiffre hexadécimal redevient son quartet de 4 bits, dans
l'ordre.

Exemple : convertir `9F` en binaire.

- `9` = `1001`
- `F` = `1111`

Résultat : **`10011111`**.

## Convertir entre hexadécimal et décimal

Comme pour le binaire (leçon 2), chaque position d'un nombre hexadécimal a un poids, mais
cette fois ce sont des puissances de 16 : 16⁰ = 1, 16¹ = 16, 16² = 256...

**Hexadécimal → décimal** : multiplier chaque chiffre par le poids de sa position, puis
additionner. Exemple avec `9F` : 9×16 + F×1 = 9×16 + 15×1 = 144 + 15 = **159**.

**Décimal → hexadécimal** : divisions successives par 16, restes lus du bas vers le haut —
exactement la même méthode qu'en binaire (leçon 2), avec 16 à la place de 2. Exemple avec
202 :

| Division | Quotient | Reste |
|---|---|---|
| 202 ÷ 16 | 12 | 10 (= A) |
| 12 ÷ 16 | 0 | 12 (= C) |

Restes du bas vers le haut : `C`, `A` → **`CA`**. Vérification : C×16 + A×1 = 12×16 + 10 =
192 + 10 = 202. ✓

En pratique, pour un seul octet (0 à 255), la conversion directe depuis le binaire (méthode
du paragraphe précédent) est presque toujours plus rapide que de passer par le décimal.

## L'octal, en bref

L'octal (base 8) fonctionne sur le même principe, avec des groupes de **3 bits** au lieu de
4 (8 = 2³) :

| Décimal | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 |
|---|---|---|---|---|---|---|---|---|
| Octal | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 |
| Binaire (3 bits) | 000 | 001 | 010 | 011 | 100 | 101 | 110 | 111 |

Exemple, `101110` en octal : découpé en groupes de 3 en partant de la droite, `101 | 110`,
soit `5` puis `6` → **`56`**. L'octal est aujourd'hui surtout un héritage historique (il a
précédé l'hexadécimal sur d'anciens systèmes) — ce cours ne l'utilise plus après cette leçon,
mais le principe (grouper les bits, convertir groupe par groupe) est le même qu'en
hexadécimal, avec un groupe plus petit.

**Suite : [4. Adressage IPv4](04-adressage-ipv4.md)**
