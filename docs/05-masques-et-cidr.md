# 5. Masques et CIDR

## À quoi sert un masque

La leçon 4 a laissé une question ouverte : dans une adresse IPv4, où s'arrête la partie
réseau et où commence la partie hôte ? C'est le rôle du **masque de sous-réseau** : une suite
de 32 bits, avec des **1** partout où l'adresse désigne le réseau (toujours en partant de la
gauche, sans interruption) et des **0** partout où elle désigne l'hôte.

```
Adresse : 192.168.1.77   = 11000000.10101000.00000001.01001101
Masque  : /26             = 11111111.11111111.11111111.11000000
                             \_______________________/\_______/
                                  partie réseau          partie hôte
```

## Deux notations pour le même masque

- **Notation décimale pointée**, comme une adresse IP : `255.255.255.192`.
- **Notation CIDR** (Classless Inter-Domain Routing) : `/26`, le nombre total de bits à 1
  dans le masque. C'est la notation la plus rapide à manipuler, et la plus utilisée en
  pratique.

Comme un octet ne peut contenir que 0 à 8 bits à 1 **consécutifs en partant de la gauche**,
il n'existe que 9 valeurs décimales possibles pour un octet de masque — un tableau à
connaître par cœur, la référence la plus utile de cette leçon :

| Bits à 1 dans l'octet | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
|---|---|---|---|---|---|---|---|---|---|
| Valeur décimale | 0 | 128 | 192 | 224 | 240 | 248 | 252 | 254 | 255 |

Un masque CIDR `/n` s'obtient en remplissant les octets de gauche à droite avec des 8, puis
en plaçant le reste dans l'octet suivant grâce à ce tableau. Exemple : `/26` = 8 + 8 + 8 + 2,
soit `255.255.255.192` (2 bits à 1 dans le dernier octet → 192, voir le tableau).

## La méthode de calcul (à réutiliser dans toutes les leçons suivantes)

Pour une adresse et un masque donnés, trois valeurs se calculent toujours de la même façon :
**l'adresse réseau**, **l'adresse de diffusion**, et la **plage d'adresses utilisables**.

Exemple fil rouge : `192.168.1.77/26`.

**Étape 1 — convertir l'adresse en binaire** (leçon 2) :

```
192.168.1.77 = 11000000.10101000.00000001.01001101
```

**Étape 2 — appliquer le masque avec un ET bit à bit** (leçon 2) pour obtenir l'**adresse
réseau** : tous les bits hôte tombent à 0.

```
  11000000.10101000.00000001.01001101
ET 11111111.11111111.11111111.11000000
-------------------------------------
  11000000.10101000.00000001.01000000   =  192.168.1.64
```

**Étape 3 — mettre tous les bits hôte à 1** pour obtenir l'**adresse de diffusion**
(broadcast) de ce sous-réseau :

```
  11000000.10101000.00000001.01000000   (adresse réseau)
     bits hôte forcés à 1 → 01111111
-------------------------------------
  11000000.10101000.00000001.01111111   =  192.168.1.127
```

**Étape 4 — lire le résultat** : la **plage utilisable** est tout ce qui se trouve entre
l'adresse réseau et l'adresse de diffusion, exclues (ce sont des adresses réservées, jamais
attribuées à un hôte) : de **192.168.1.65** à **192.168.1.126**.

| Résultat | Valeur |
|---|---|
| Adresse réseau | 192.168.1.64 |
| Adresse de diffusion | 192.168.1.127 |
| Première adresse utilisable | 192.168.1.65 |
| Dernière adresse utilisable | 192.168.1.126 |
| Nombre d'hôtes utilisables | 2⁶ − 2 = 62 |

Le nombre de bits hôte (ici 6, puisque `/26` laisse 32 − 26 = 6 bits après la partie
réseau) donne directement le nombre d'adresses du sous-réseau (2⁶ = 64), dont il faut
toujours retirer 2 (l'adresse réseau et l'adresse de diffusion ne sont jamais attribuables à
un hôte) : 64 − 2 = **62 hôtes utilisables**.

## Le raccourci du "bloc" (une fois la méthode ci-dessus comprise)

Une fois qu'on comprend *pourquoi* le calcul binaire donne ce résultat, un raccourci évite de
reposer le calcul en binaire à chaque fois : la **taille du bloc** de chaque sous-réseau vaut
`256 − (valeur décimale du masque dans l'octet intéressant)`. Pour `/26` (masque `192` dans
le 4ᵉ octet) : bloc = 256 − 192 = **64**. Les sous-réseaux successifs commencent alors à
chaque multiple de 64 : 0, 64, 128, 192... L'adresse `192.168.1.77` tombe entre 64 et 128 →
adresse réseau **192.168.1.64**, diffusion juste avant le multiple suivant : 64 + 64 − 1 =
**192.168.1.127**. Mêmes résultats, en beaucoup moins d'écriture — mais seulement si l'on
sait déjà pourquoi ça fonctionne (étapes 1 à 4 ci-dessus).

## Table de référence des masques usuels

| CIDR | Masque décimal | Bits hôte | Hôtes utilisables |
|---|---|---|---|
| /24 | 255.255.255.0 | 8 | 254 |
| /25 | 255.255.255.128 | 7 | 126 |
| /26 | 255.255.255.192 | 6 | 62 |
| /27 | 255.255.255.224 | 5 | 30 |
| /28 | 255.255.255.240 | 4 | 14 |
| /29 | 255.255.255.248 | 3 | 6 |
| /30 | 255.255.255.252 | 2 | 2 |

**Suite : [6. Découpage en sous-réseaux](06-decoupage-en-sous-reseaux.md)**
