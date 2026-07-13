# 11. VLAN

## Le problème que résout le VLAN

La leçon 10 a établi qu'un switch, seul, ne sépare jamais un domaine de diffusion : tous les
ports d'un même switch (et de tous les switches qui lui sont reliés) appartiennent au même
domaine. Séparer physiquement les services d'une entreprise (comptabilité, RH...) sur des
switches différents pour les isoler serait à la fois coûteux et rigide. Le **VLAN** (*Virtual
LAN*) résout ce problème sans matériel supplémentaire : il crée **plusieurs domaines de
diffusion séparés sur un même switch physique**, en assignant chaque port à un VLAN identifié
par un numéro.

Deux machines dans des VLAN différents, même reliées **au même switch**, ne peuvent **pas**
communiquer directement — exactement comme si elles étaient sur deux switches séparés sans
lien entre eux. Il leur faut, comme pour deux réseaux IP différents (leçon 12), un routeur
pour les relier.

## Ports d'accès et ports de trunk

| Mode | Rôle | Appartient à |
|---|---|---|
| **Accès** (*access*) | Relie un port à un hôte final (PC, imprimante...), qui n'a lui-même aucune notion de VLAN | Un seul VLAN |
| **Trunk** | Relie deux switches entre eux (ou un switch à un routeur), en transportant le trafic de **plusieurs** VLAN sur un seul câble | Plusieurs VLAN à la fois |

Sur un lien trunk, chaque trame est marquée d'un **tag** (norme 802.1Q) qui indique à quel
VLAN elle appartient, pour que le switch de l'autre côté sache la remettre dans le bon
domaine de diffusion.

## Exemple complet

| Équipement | Interface | VLAN | Relié à |
|---|---|---|---|
| PC1 (Compta) | eth0 | 10 | SW1 Fa0/1 |
| PC2 (Compta) | eth0 | 10 | SW1 Fa0/2 |
| PC3 (RH) | eth0 | 20 | SW1 Fa0/3 |
| PC4 (RH) | eth0 | 20 | SW2 Fa0/2 |
| SW1 | Fa0/24 (trunk, VLAN 10 et 20) | — | SW2 Fa0/24 |
| SW2 | Fa0/24 (trunk, VLAN 10 et 20) | — | SW1 Fa0/24 |

- **PC1 et PC2** sont dans le même VLAN (10) et sur le même switch → communication directe.
- **PC1 et PC3** sont sur le même switch mais dans des VLAN différents (10 et 20) → **pas**
  de communication directe, malgré la proximité physique.
- **PC3 et PC4** sont dans le même VLAN (20) mais sur des switches **différents** → la
  communication passe par le lien trunk entre SW1 et SW2, qui transporte le VLAN 20 (et le
  VLAN 10) — et fonctionne malgré la distance physique, précisément parce que c'est le VLAN,
  pas le switch, qui définit le domaine de diffusion.

**Suite : [12. Routage](12-routage.md)**
