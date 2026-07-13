# Pas à pas — TP 11 : VLAN

Garde sous les yeux le cours [11-vlan.md](../../docs/11-vlan.md), en particulier son
"Exemple complet" — c'est exactement la topologie de ce TP.

## Raisonnement

La seule question à te poser à chaque fois : **est-ce que les deux machines sont dans le même
VLAN ?** Le switch ou les switches traversés n'ont pas d'importance, seul le numéro de VLAN
compte.

- **PC1 et PC2** : tous deux en VLAN 10 → **oui**, ils communiquent directement.
- **PC1 et PC3** : VLAN 10 contre VLAN 20 — pourtant reliés au **même** switch SW1, mais cela
  ne change rien : des VLAN différents restent des domaines de diffusion séparés → **non**.
- **PC3 et PC4** : tous deux en VLAN 20, mais sur deux switches différents (SW1 et SW2) reliés
  par un trunk qui transporte justement le VLAN 20 → **oui**, la distance physique ne change
  rien tant que le VLAN est transporté de bout en bout.

Pour le mode des ports : un port relié directement à un PC final est toujours en mode
**accès** (Fa0/1) ; un port qui relie deux switches entre eux et doit transporter plusieurs
VLAN est toujours en mode **trunk** (Fa0/24).

## Vérifier son travail

Compare avec `Corrige/01-vlan.txt` si besoin.

**Suite : [12. Routage](../../docs/12-routage.md)**
