# Projet de synthèse — cahier des charges

Une petite entreprise a deux sites, chacun avec son propre routeur (R1 au Site A, R2 au Site
B), reliés entre eux par une liaison point à point. Un seul bloc d'adresses a été alloué à
toute l'entreprise : **192.168.100.0/24**.

## Besoins en hôtes

| Réseau | Hôtes nécessaires |
|---|---|
| LAN Utilisateurs A (Site A) | 50 |
| LAN Utilisateurs B (Site B) | 20 |
| LAN Serveurs A (Site A) | 10 |
| Liaison WAN R1 – R2 | 2 (point à point) |

## Règle de filtrage à appliquer sur R1

Seul le trafic HTTPS (TCP port 443) est autorisé depuis le LAN Utilisateurs B vers le LAN
Serveurs A ; tout le reste de ce LAN vers ce LAN est bloqué (règle explicite, avant le deny
implicite habituel).

## Convention d'attribution des adresses

Pour chaque sous-réseau, l'adresse de passerelle (celle du routeur) est **la première
adresse utilisable** du sous-réseau — sauf sur la liaison WAN, où R1 reçoit la première
adresse utilisable et R2 la seconde.

## À déterminer (voir les fichiers `Enonce/`)

1. Le découpage VLSM du bloc `192.168.100.0/24` (`01-adressage.txt`).
2. Les adresses exactes des interfaces de R1 et R2 (`02-adressage-routeurs.txt`).
3. Le routage entre les deux sites (`03-routage.txt`).
4. Le résultat de la règle de filtrage ci-dessus sur deux échanges donnés
   (`04-filtrage.txt`).
