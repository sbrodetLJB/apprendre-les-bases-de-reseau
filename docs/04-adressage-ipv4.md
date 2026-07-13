# 4. Adressage IPv4

## Structure d'une adresse IPv4

Une adresse IPv4 identifie une interface au niveau de la couche Internet (leçon 1). Elle
tient sur **32 bits**, presque toujours écrits sous forme de **4 octets séparés par des
points** (notation décimale pointée) — chaque octet valant donc entre 0 et 255, exactement
comme les octets manipulés en leçon 2.

```
192   .   168   .   1    .   10
11000000.10101000.00000001.00001010
```

Convertir une adresse IPv4 en binaire, c'est simplement convertir chacun de ses 4 octets
séparément avec la méthode de la leçon 2 — aucune notion nouvelle à ce stade.

## Deux parties dans une adresse : réseau et hôte

Une adresse IPv4 se découpe toujours en deux parties : une partie **réseau** (qui identifie
le réseau local auquel appartient l'adresse) et une partie **hôte** (qui identifie une
machine précise à l'intérieur de ce réseau) — un peu comme un numéro de rue se découpe en nom
de rue (le réseau) et numéro de porte (l'hôte). La frontière exacte entre les deux parties
n'est pas fixe : elle est donnée par le **masque de sous-réseau**, qui fait l'objet de la
leçon 5. Cette leçon-ci se concentre sur la structure de l'adresse elle-même et sur quelques
adresses qui ont un sens particulier.

## Les classes historiques

Avant l'invention du CIDR (leçon 5), les adresses IPv4 étaient réparties en **classes**,
reconnaissables au premier octet. Ce découpage est aujourd'hui obsolète en pratique (le CIDR
l'a remplacé), mais le vocabulaire "classe A/B/C" reste très utilisé, y compris dans les
examens :

| Classe | 1ᵉʳ octet | Masque par défaut | Usage |
|---|---|---|---|
| A | 1 à 126 | 255.0.0.0 (/8) | Très grands réseaux (peu de réseaux, beaucoup d'hôtes chacun) |
| B | 128 à 191 | 255.255.0.0 (/16) | Réseaux de taille moyenne |
| C | 192 à 223 | 255.255.255.0 (/24) | Petits réseaux (beaucoup de réseaux, peu d'hôtes chacun) |
| D | 224 à 239 | — | Multicast (une adresse désigne un groupe de destinataires, pas un seul) |
| E | 240 à 255 | — | Réservé, expérimental |

Le premier octet **127** n'appartient à aucune classe utilisable : il est entièrement réservé
au **loopback** (voir plus loin), une adresse qui désigne toujours "cette machine-même".

## Adresses privées et adresses publiques

Une adresse **publique** est unique sur Internet tout entier. Une adresse **privée** n'est
valable qu'à l'intérieur d'un réseau local : elle peut être réutilisée dans des millions de
réseaux locaux différents sans aucun conflit, parce qu'elle n'est jamais routée directement
sur Internet (un routeur de sortie fait généralement de la traduction d'adresse, ou **NAT** —
principe présenté en leçon 7). Trois plages sont réservées aux adresses privées (RFC 1918) :

| Plage privée | Notation CIDR (leçon 5) | Nombre d'adresses |
|---|---|---|
| 10.0.0.0 à 10.255.255.255 | 10.0.0.0/8 | ≈ 16,7 millions |
| 172.16.0.0 à 172.31.255.255 | 172.16.0.0/12 | ≈ 1 million |
| 192.168.0.0 à 192.168.255.255 | 192.168.0.0/16 | 65 536 |

**Piège fréquent** : seule la plage 172.**16**.0.0 à 172.**31**.255.255 est privée. Une
adresse comme 172.32.5.5 commence bien par "172" mais **n'est pas privée** : 32 est en dehors
de l'intervalle 16-31. Il faut vérifier l'intervalle exact, pas seulement le premier octet.

Toute adresse qui n'appartient à aucune de ces trois plages (ni aux adresses réservées
ci-dessous) est une adresse **publique**.

## Quelques adresses réservées à connaître

| Adresse / plage | Signification |
|---|---|
| 127.0.0.0/8 (surtout 127.0.0.1) | **Loopback** : désigne toujours la machine locale elle-même. |
| 0.0.0.0 | Adresse "indéterminée" (utilisée par exemple avant qu'une machine n'ait reçu d'adresse via DHCP, leçon 15). |
| 255.255.255.255 | **Broadcast limité** : désigne toutes les machines du réseau local, sans jamais être routé au-delà. |

**Suite : [5. Masques et CIDR](05-masques-et-cidr.md)**
