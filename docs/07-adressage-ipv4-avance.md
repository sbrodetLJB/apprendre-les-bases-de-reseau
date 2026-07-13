# 7. Adressage IPv4 avancé

## Le résumé de routes (l'inverse du découpage)

La leçon 6 a découpé un grand réseau en plusieurs petits. Le **résumé de routes**
(*supernetting*, ou agrégation) fait l'inverse : regrouper plusieurs réseaux **contigus** de
même taille sous une seule entrée, avec un masque plus court — utile pour garder les tables
de routage compactes (leçon 12).

**Méthode** :
1. Vérifier que les réseaux sont **contigus** et de **même taille**.
2. Vérifier que le premier réseau démarre à une adresse **multiple de N fois sa taille** (N
   étant le nombre de réseaux à regrouper) — sinon le regroupement n'est pas possible en une
   seule route.
3. Nouveau masque = ancien masque − log₂(N).

**Exemple** : résumer `192.168.0.0/24`, `192.168.1.0/24`, `192.168.2.0/24` et
`192.168.3.0/24` (4 réseaux contigus).

- 4 réseaux → log₂(4) = 2 bits à retirer. Nouveau masque : /24 − 2 = **/22**.
- Le premier réseau (192.168.**0**.0) démarre bien à un multiple de 4 (en comptant par pas de
  1 dans le 3ᵉ octet) → le regroupement est valide.

Résultat : les quatre réseaux se résument en une seule route, **`192.168.0.0/22`** — une
machine qui doit atteindre n'importe laquelle des quatre adresses .0, .1, .2 ou .3 dans le 3ᵉ
octet est concernée par cette unique route.

## Le NAT, en bref

La leçon 4 a établi qu'une adresse privée n'est jamais routée directement sur Internet.
Pourtant, un PC avec une adresse privée navigue bien sur le web : c'est le rôle du **NAT**
(*Network Address Translation*), pratiqué par le routeur qui fait la jonction entre le
réseau local et Internet.

**Principe** : quand une machine du réseau local (adresse privée) envoie une requête vers
Internet, le routeur remplace l'adresse source privée par **sa propre adresse publique**
avant de transmettre le paquet, et retient la correspondance pour pouvoir rediriger la
réponse vers la bonne machine interne au retour. Le serveur distant ne voit donc jamais
l'adresse privée : uniquement l'adresse publique du routeur.

En pratique, un même routeur domestique ou d'entreprise n'a souvent qu'**une seule** adresse
publique pour tout un réseau local : la variante **PAT** (*Port Address Translation*)
distingue alors chaque machine interne par le **port** utilisé (leçon 14), pas seulement par
l'adresse.

## Adresses spéciales, suite de la leçon 4

| Adresse / plage | Signification |
|---|---|
| 169.254.0.0/16 (**APIPA**) | Attribuée automatiquement par une machine qui n'a reçu aucune adresse par DHCP (leçon 15) et qui n'en a pas non plus de fixe — signale un problème de configuration ou de serveur DHCP injoignable. |
| 127.0.0.0/8 | Loopback (rappel, leçon 4) : désigne toujours la machine locale. |
| 192.0.2.0/24, 198.51.100.0/24, 203.0.113.0/24 (**TEST-NET**) | Réservées à la documentation et aux exemples (RFC 5737) — jamais routées sur Internet. Ce cours les utilise dans ses exemples chaque fois qu'une adresse publique est nécessaire, précisément pour ne jamais donner l'impression qu'il s'agit d'une vraie adresse existante. |
| 0.0.0.0/0 | Ne désigne pas une machine : c'est la notation d'une **route par défaut** dans une table de routage (leçon 12), signifiant "tout le reste". |

**Suite : [8. Adressage IPv6](08-adressage-ipv6.md)**
