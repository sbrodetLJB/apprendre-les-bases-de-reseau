# 6. Découpage en sous-réseaux

## Pourquoi découper un réseau

Un réseau `/24` (254 hôtes utilisables) est souvent trop grand pour être utilisé tel quel :
séparer les services (serveurs, postes utilisateurs, imprimantes...) sur des sous-réseaux
différents limite le trafic de diffusion et améliore la sécurité (un filtrage, leçon 14,
devient possible entre sous-réseaux). Découper un réseau, c'est **emprunter des bits à la
partie hôte pour agrandir la partie réseau** — donc, très concrètement, choisir un masque
CIDR plus grand que celui de départ.

## Découpage à taille fixe

**Besoin** : diviser un réseau donné en **N sous-réseaux de taille égale**.

**Méthode** :
1. Trouver le nombre de bits à emprunter : le plus petit `n` tel que 2ⁿ ≥ N.
2. Le nouveau masque CIDR = masque de départ + n.
3. La taille de chaque sous-réseau (en nombre d'adresses) = bloc = 2^(bits hôte restants).
4. Les sous-réseaux se suivent, chacun démarrant à un multiple de la taille du bloc.

**Exemple** : diviser `192.168.1.0/24` en **4 sous-réseaux égaux**.

- 2² = 4 ≥ 4 → il faut emprunter **2 bits**. Nouveau masque : /24 + 2 = **/26**.
- Bits hôte restants : 32 − 26 = 6 → bloc de 2⁶ = **64** adresses par sous-réseau.
- Les 4 sous-réseaux démarrent aux multiples de 64 : 0, 64, 128, 192.

| Sous-réseau | Adresse réseau | Adresse de diffusion |
|---|---|---|
| n°0 | 192.168.1.0/26 | 192.168.1.63 |
| n°1 | 192.168.1.64/26 | 192.168.1.127 |
| n°2 | 192.168.1.128/26 | 192.168.1.191 |
| n°3 | 192.168.1.192/26 | 192.168.1.255 |

(C'est très exactement le calcul de la méthode de la leçon 5, répété pour chaque sous-réseau.)

## VLSM : des sous-réseaux de tailles différentes

Le découpage à taille fixe gaspille des adresses dès que les besoins réels diffèrent d'un
service à l'autre (allouer un `/26` de 62 hôtes à un service qui n'en a que 5 en perd 57 pour
rien). Le **VLSM** (*Variable Length Subnet Mask*) alloue à chaque besoin un sous-réseau juste
assez grand, en réutilisant plusieurs tailles de masque à l'intérieur d'un même réseau de
départ.

**Méthode** :
1. Lister les besoins et **les trier du plus grand au plus petit**.
2. Pour chaque besoin, calculer le plus petit masque qui le couvre (2ⁿ − 2 ≥ nombre d'hôtes
   demandé).
3. Allouer les blocs **dans l'ordre décroissant de taille**, chacun démarrant juste après la
   fin du précédent, en l'ajustant si besoin au prochain multiple de sa propre taille de bloc
   (un sous-réseau doit toujours démarrer à une adresse multiple de sa taille — c'est
   automatique si l'on va du plus grand bloc au plus petit).

**Exemple** : à partir de `192.168.10.0/24`, créer des sous-réseaux pour un Service A (60
hôtes), un Service B (25 hôtes) et un Service C (10 hôtes).

| Besoin | Hôtes demandés | 2ⁿ − 2 ≥ besoin | Masque | Taille du bloc |
|---|---|---|---|---|
| Service A | 60 | 2⁶ − 2 = 62 | /26 | 64 |
| Service B | 25 | 2⁵ − 2 = 30 | /27 | 32 |
| Service C | 10 | 2⁴ − 2 = 14 | /28 | 16 |

Allocation, du plus grand bloc au plus petit, en partant de `192.168.10.0` :

| Sous-réseau | Adresse réseau | Adresse de diffusion |
|---|---|---|
| Service A (/26, bloc 64) | 192.168.10.0 | 192.168.10.63 |
| Service B (/27, bloc 32) | 192.168.10.64 | 192.168.10.95 |
| Service C (/28, bloc 16) | 192.168.10.96 | 192.168.10.111 |

Chaque sous-réseau démarre exactement là où le précédent s'arrête (+1), et chaque adresse de
départ est bien un multiple de la taille de son propre bloc (64, puis 32, puis 16) — c'est
cette régularité qui garantit qu'aucun sous-réseau n'empiète sur un autre.

**Suite : [7. Adressage IPv4 avancé](07-adressage-ipv4-avance.md)**
