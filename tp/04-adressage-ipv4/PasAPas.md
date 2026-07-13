# Pas à pas — TP 4 : adressage IPv4

Garde sous les yeux le cours [04-adressage-ipv4.md](../../docs/04-adressage-ipv4.md).

## Exercice 1 : conversion en binaire

Convertis chacun des 4 octets séparément, avec la méthode de la leçon 2 (poids
128-64-32-16-8-4-2-1), puis assemble les 4 résultats avec un point entre chaque.

Exemple détaillé avec `10.0.5.200` :

- `10` → `00001010`
- `0` → `00000000`
- `5` → `00000101`
- `200` → `11001000`

Résultat : **`00001010.00000000.00000101.11001000`**.

## Exercice 2 : les classes

Regarde uniquement le **premier octet** de chaque adresse et compare-le au tableau des
classes du cours.

Exemple détaillé avec `224.0.0.5` : le premier octet est 224, qui se situe dans l'intervalle
224 à 239 → classe **D** (multicast).

## Exercice 3 : privée ou publique

Compare chaque adresse aux trois plages privées du cours, **en vérifiant l'intervalle
complet**, pas seulement le premier octet.

Exemple détaillé avec `172.32.5.5` : le premier octet est 172, comme pour la plage privée
172.16.0.0-172.31.255.255 — mais le deuxième octet, 32, est **en dehors** de l'intervalle
16-31. Cette adresse n'est donc **pas** privée : réponse **publique**.

Exemple détaillé avec `8.8.8.8` : le premier octet, 8, n'appartient à aucune des trois
plages du cours (10, 172.16-31, 192.168) → réponse **publique**.

## Vérifier son travail

Compare avec les fichiers correspondants dans `Corrige/` si besoin.

**Suite : [5. Masques et CIDR](../../docs/05-masques-et-cidr.md)**
