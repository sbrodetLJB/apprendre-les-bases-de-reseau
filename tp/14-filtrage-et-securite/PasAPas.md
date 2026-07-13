# Pas à pas — TP 14 : filtrage et sécurité de base

Garde sous les yeux le cours
[14-filtrage-et-securite.md](../../docs/14-filtrage-et-securite.md).

## Exercice 1 : les ports

Relis le tableau des ports bien connus du cours — chaque numéro s'y trouve directement :
80 → HTTP, 443 → HTTPS, 22 → SSH, 53 → DNS.

## Exercice 2 : évaluer une ACL

Pour chaque paquet, examine les règles **dans l'ordre** (1, puis 2, puis 3), et arrête-toi à
la **première** qui correspond entièrement (protocole, source, destination, port).

- **TCP 192.168.1.5 → 8.8.8.8 port 443** : la règle 1 (PERMIT TCP, source 192.168.1.0/24,
  n'importe quelle destination, port 443) correspond point par point → **autorisé**, sans
  regarder les règles suivantes.
- **TCP 203.0.113.9 → 192.168.1.10 port 22** : la règle 1 ne correspond pas (port 22 ≠ 443).
  La règle 2 (PERMIT TCP, n'importe quelle source, destination 192.168.1.10, port 22)
  correspond → **autorisé**.
- **TCP 192.168.1.5 → 8.8.8.8 port 80** : la règle 1 ne correspond pas (port 80 ≠ 443), la
  règle 2 ne correspond pas (destination ≠ 192.168.1.10). La règle 3 (DENY TCP, source
  192.168.1.0/24, n'importe quelle destination, n'importe quel port) correspond → **bloqué**.
- **UDP 203.0.113.20 → 192.168.1.10 port 53** : les trois règles précisent toutes le
  protocole TCP — aucune ne peut donc correspondre à un paquet UDP, quels que soient les
  adresses et le port. Aucune règle ne correspond → **bloqué** par le deny implicite de fin
  de liste.

## Vérifier son travail

Compare avec les fichiers correspondants dans `Corrige/` si besoin.

**Suite : [15. Services réseau et projet de synthèse](../../docs/15-services-et-synthese.md)**
