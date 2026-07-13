# Pas à pas — TP 10 : commutation

Garde sous les yeux le cours [10-commutation.md](../../docs/10-commutation.md), en
particulier l'exemple complet à trois trames.

## Exercice 1 : table de commutation

C'est exactement l'exemple du cours, à dérouler soi-même. Pour chaque trame : d'abord
**apprendre** (noter l'adresse source et son port), ensuite **décider** où transmettre (à
partir de l'adresse destination).

- **Trame 1** (PC1 → PC2) : le switch apprend `AA:01 → Fa0/1`. AA:02 est encore absente de la
  table → diffusion sur tous les ports sauf celui d'arrivée (Fa0/1) → **Fa0/2 et Fa0/3**.
- **Trame 2** (PC2 → PC1) : le switch apprend `AA:02 → Fa0/2`. AA:01 est déjà dans la table
  (apprise à l'étape précédente) → transmission ciblée, uniquement **Fa0/1**.
- **Trame 3** (PC3 → PC1) : le switch apprend `AA:03 → Fa0/3`. AA:01 est toujours connue →
  uniquement **Fa0/1**.

Après ces trois trames, la table contient les trois adresses, chacune associée à son port
d'arrivée d'origine (celui par lequel son PC est physiquement relié).

## Exercice 2 : domaines

Relis la section "Domaines de collision et de diffusion" du cours :

- Un switch, seul, **ne segmente jamais** un domaine de diffusion : les 5 PC restent dans un
  seul et même domaine, quel que soit le nombre de switches traversés → **1**.
- Sur un port de switch moderne en full-duplex, il n'y a jamais deux machines à se partager
  le même support physique → **1** domaine de collision par port.
- Le cours n'a présenté qu'un seul équipement capable de segmenter un domaine de diffusion
  jusqu'ici → le **routeur** (le VLAN, capable de la même chose sans routeur, est le sujet de
  la prochaine leçon).

## Vérifier son travail

Compare avec les fichiers correspondants dans `Corrige/` si besoin.

**Suite : [11. VLAN](../../docs/11-vlan.md)**
