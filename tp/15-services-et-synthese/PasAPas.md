# Pas à pas — TP 15 : projet de synthèse

Garde sous les yeux [00-cahier-des-charges.md](Enonce/00-cahier-des-charges.md) et repasse,
si besoin, par les leçons [5](../../docs/05-masques-et-cidr.md),
[6](../../docs/06-decoupage-en-sous-reseaux.md), [7](../../docs/07-adressage-ipv4-avance.md),
[12](../../docs/12-routage.md) et [14](../../docs/14-filtrage-et-securite.md) : ce TP ne fait
que réutiliser leurs méthodes, sur un seul scénario.

## Exercice 1 : VLSM

Même méthode que la leçon 6 : trier les besoins du plus grand au plus petit, trouver le
masque de chacun, puis allouer dans cet ordre.

| Besoin | Hôtes | 2ⁿ − 2 ≥ besoin | Masque | Bloc |
|---|---|---|---|---|
| LAN Utilisateurs A | 50 | 2⁶ − 2 = 62 | /26 | 64 |
| LAN Utilisateurs B | 20 | 2⁵ − 2 = 30 | /27 | 32 |
| LAN Serveurs A | 10 | 2⁴ − 2 = 14 | /28 | 16 |
| Liaison WAN | 2 | 2² − 2 = 2 | /30 | 4 |

Allocation à partir de 192.168.100.0, du plus grand bloc au plus petit :

- LAN Utilisateurs A (/26, bloc 64) : 192.168.100.**0** à .63.
- LAN Utilisateurs B (/27, bloc 32) : commence juste après (64, multiple de 32) → 192.168.100.**64** à .95.
- LAN Serveurs A (/28, bloc 16) : commence juste après (96, multiple de 16) → 192.168.100.**96** à .111.
- Liaison WAN (/30, bloc 4) : commence juste après (112, multiple de 4) → 192.168.100.**112** à .115.

## Exercice 2 : adresses des routeurs

La convention du cahier des charges donne la première adresse utilisable comme passerelle
(sauf sur le WAN, où R1 prend la première et R2 la seconde) — relis la leçon 5 pour la
méthode "adresse réseau + 1".

- R1, LAN Utilisateurs A (réseau .0/26) → première utilisable **192.168.100.1**.
- R1, LAN Serveurs A (réseau .96/28) → première utilisable **192.168.100.97**.
- R1, WAN (réseau .112/30) → première utilisable **192.168.100.113**.
- R2, LAN Utilisateurs B (réseau .64/27) → première utilisable **192.168.100.65**.
- R2, WAN (réseau .112/30) → **deuxième** utilisable (R1 a déjà pris la première) →
  **192.168.100.114**.

## Exercice 3 : routage

**Résumé de routes** (leçon 7) : R2 voudrait regrouper les deux réseaux du Site A
(192.168.100.0/26 et 192.168.100.96/28) en une seule route. Mais un résumé exige des réseaux
**contigus** — or le réseau du Site B (192.168.100.64/27) est intercalé exactement entre les
deux : .0-.63, puis **.64-.95 (Site B)**, puis .96-.111. Les deux réseaux du Site A ne sont
donc pas contigus → réponse **non** : R2 a besoin de deux routes statiques séparées vers le
Site A.

**Passerelles** : pour joindre un réseau de l'autre site, chaque routeur passe par
l'interface WAN de l'autre routeur (méthode de la leçon 12, "passerelle = next-hop") :

- R1 → LAN Utilisateurs B : passerelle **192.168.100.114** (interface WAN de R2).
- R2 → LAN Serveurs A : passerelle **192.168.100.113** (interface WAN de R1).

## Exercice 4 : filtrage

Même méthode que la leçon 14 : évaluer les règles dans l'ordre. La règle du cahier des
charges est : PERMIT TCP (LAN Utilisateurs B) → (LAN Serveurs A) port 443, puis DENY tout le
reste de ce LAN vers ce LAN.

- **Port 443** : correspond exactement à la règle PERMIT → **autorisé**.
- **Port 22** : ne correspond pas à la règle PERMIT (mauvais port), correspond à la règle
  DENY qui couvre "tout port" restant entre ces deux réseaux → **bloqué**.

## Vérifier son travail

Compare avec les fichiers correspondants dans `Corrige/` si besoin. Une erreur dans
l'exercice 1 se propage dans tous les suivants : si un résultat semble incohérent en
exercice 2, 3 ou 4, la cause est presque toujours à chercher dans l'exercice 1.
