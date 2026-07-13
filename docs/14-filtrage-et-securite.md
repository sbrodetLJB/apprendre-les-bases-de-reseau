# 14. Filtrage et sécurité de base

## Les ports : identifier une application, pas seulement une machine

La couche Transport (leçon 1) ajoute aux segments un numéro de **port** (0 à 65535), qui
identifie une application précise sur la machine destination — une adresse IP identifie une
machine, un port identifie **quel service** de cette machine doit recevoir les données.
L'ensemble adresse IP + port s'appelle un **socket**.

Les ports 0 à 1023 sont les **ports bien connus** (*well-known ports*), attribués aux
services les plus courants :

| Port | Service |
|---|---|
| 20-21 | FTP (transfert de fichiers) |
| 22 | SSH (administration distante sécurisée) |
| 25 | SMTP (envoi d'email) |
| 53 | DNS (résolution de noms, leçon 15) |
| 67-68 | DHCP (attribution automatique d'adresses, leçon 15) |
| 80 | HTTP (web) |
| 443 | HTTPS (web sécurisé) |

## Rappel : TCP et UDP

Deux protocoles se partagent la couche Transport : **TCP**, connecté et fiable (accusés de
réception, retransmission des segments perdus — utilisé quand rien ne doit se perdre : web,
email, transfert de fichiers), et **UDP**, non connecté et sans garantie de livraison, mais
plus rapide et avec moins de surcharge (utilisé quand la vitesse compte plus que la fiabilité
totale : streaming vidéo/audio, DNS).

## Le pare-feu et les listes de contrôle d'accès (ACL)

Un **pare-feu** filtre le trafic réseau selon des règles portant généralement sur l'adresse
IP source, l'adresse IP destination, le protocole (TCP/UDP) et le port. Sur un routeur, ces
règles forment une **ACL** (*Access Control List*) : une liste **ordonnée** de règles
`PERMIT`/`DENY`.

**Principe d'évaluation, essentiel à retenir** :
1. Les règles sont examinées **dans l'ordre**, une par une.
2. **La première règle qui correspond au paquet s'applique** — les règles suivantes ne sont
   plus regardées, même si elles auraient dit autre chose.
3. Si **aucune** règle ne correspond, un paquet est **refusé par défaut** (deny implicite en
   fin de liste) — une ACL qui ne dit rien explicitement à propos d'un paquet le bloque.

## Exemple complet

ACL d'un routeur, dans l'ordre :

| # | Action | Protocole | Source | Destination | Port destination |
|---|---|---|---|---|---|
| 1 | PERMIT | TCP | 192.168.1.0/24 | n'importe où | 443 |
| 2 | PERMIT | TCP | n'importe où | 192.168.1.10 | 22 |
| 3 | DENY | TCP | 192.168.1.0/24 | n'importe où | n'importe quel port |

*(+ deny implicite pour tout ce qui ne correspond à aucune de ces trois règles)*

Évaluation de quatre paquets :

- **TCP, 192.168.1.5 → 8.8.8.8, port 443** : correspond à la règle 1 → **autorisé**.
- **TCP, 203.0.113.9 → 192.168.1.10, port 22** : ne correspond pas à la règle 1 (mauvais
  port/destination), correspond à la règle 2 → **autorisé**.
- **TCP, 192.168.1.5 → 8.8.8.8, port 80** : ne correspond ni à la règle 1 (port 80 ≠ 443) ni
  à la règle 2 (destination ≠ 192.168.1.10), correspond à la règle 3 (source 192.168.1.0/24,
  n'importe quel port) → **bloqué**.
- **UDP, 203.0.113.20 → 192.168.1.10, port 53** : aucune des trois règles ne porte sur UDP
  (toutes trois précisent TCP) → aucune règle ne correspond → **bloqué** par le deny
  implicite.

**Suite : [15. Services réseau et projet de synthèse](15-services-et-synthese.md)**
