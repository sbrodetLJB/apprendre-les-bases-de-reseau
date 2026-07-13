# 9. Sous-réseaux IPv6 et cohabitation IPv4/IPv6

## Le préfixe /64, une convention quasi systématique

Comme pour IPv4, un préfixe IPv6 (`/n`) indique le nombre de bits réservés à la partie
réseau. Mais là où IPv4 pousse à économiser chaque bit (leçons 5-6, faute d'adresses en
nombre suffisant), IPv6 en a tellement qu'une **convention** s'est imposée : un sous-réseau
final (un LAN, celui auquel se connectent réellement des machines) utilise presque toujours
un préfixe **/64**, quelle que soit sa taille réelle — 2⁶⁴ adresses restent disponibles pour
les hôtes, un nombre qu'aucun réseau local ne remplira jamais.

Un fournisseur d'accès délègue en général un bloc plus grand à un client (souvent un `/48`
ou un `/56`), à charge pour ce client de le découper en autant de sous-réseaux `/64` que
nécessaire.

## Découper un bloc délégué en sous-réseaux /64

**Exemple** : un client reçoit le bloc `2001:db8:aa::/48`. Les 16 bits entre le `/48` et le
`/64` (le **4ᵉ groupe hexadécimal** de l'adresse) forment l'**identifiant de sous-réseau** :
il suffit de le faire varier pour créer chaque sous-réseau `/64`.

Contrairement au subnetting IPv4 (leçon 6), il n'y a ici pas besoin de calculer une taille de
bloc en bits : l'espace disponible (65 536 valeurs possibles pour ce seul groupe) est si
largement suffisant qu'on numérote directement les sous-réseaux en hexadécimal, du plus
simple au plus grand :

| Sous-réseau n° (décimal) | 4ᵉ groupe (hexadécimal) | Adresse compressée |
|---|---|---|
| 0 | `0000` | `2001:db8:aa::/64` |
| 5 | `0005` | `2001:db8:aa:5::/64` |
| 26 | `001a` | `2001:db8:aa:1a::/64` |

(26 en hexadécimal s'écrit `1A` — voir leçon 3 si besoin de réviser la conversion.)

## Cohabitation IPv4 et IPv6

La transition d'IPv4 vers IPv6 est très progressive : la grande majorité des réseaux actuels
font tourner les deux protocoles **en même temps**. La technique la plus répandue est le
**dual-stack** : une machine (ou un routeur) a simultanément une adresse IPv4 et une adresse
IPv6 configurées sur la même interface, et choisit laquelle utiliser en fonction du
destinataire contacté (si le destinataire n'est joignable qu'en IPv4, la machine utilise son
adresse IPv4 ; s'il est joignable en IPv6, elle privilégie généralement l'IPv6). D'autres
techniques existent pour les cas où l'un des deux protocoles manque à un bout de la
connexion (tunnels, traduction NAT64...), mais restent hors du périmètre de ce cours
d'introduction.

**Suite : [10. Commutation](10-commutation.md)**
