# Pas à pas — TP 6 : découpage en sous-réseaux

Garde sous les yeux le cours
[06-decoupage-en-sous-reseaux.md](../../docs/06-decoupage-en-sous-reseaux.md).

## Exercice 1 : découpage à taille fixe

**Étape 1**, trouver le nombre de bits à emprunter : il faut 8 sous-réseaux, et 2³ = 8 ≥ 8 →
**3 bits**. Nouveau masque : /24 + 3 = **/27**.

**Étape 2**, la taille de chaque sous-réseau : bits hôte restants = 32 − 27 = 5 → 2⁵ =
**32** adresses par sous-réseau.

**Étape 3**, les sous-réseaux démarrent aux multiples de 32 : 0, 32, 64, 96, 128, 160, 192,
224 (huit valeurs, une par sous-réseau, numérotées de 0 à 7).

- Sous-réseau n°0 → 192.168.4.**0**
- Sous-réseau n°3 → le 4ᵉ multiple de 32 (en comptant 0, 32, 64, **96**) → 192.168.4.**96**
- Sous-réseau n°7 → le 8ᵉ et dernier multiple (0, 32, 64, 96, 128, 160, 192, **224**) →
  192.168.4.**224**

## Exercice 2 : VLSM

**Étape 1**, trier les besoins du plus grand au plus petit : Site A (100), Site B (50), Site
C (20) — déjà dans cet ordre dans l'énoncé.

**Étape 2**, trouver le masque de chacun (plus petit `n` tel que 2ⁿ − 2 ≥ besoin) :

- Site A, 100 hôtes : 2⁷ − 2 = 126 ≥ 100 → **/25** (bloc de 128).
- Site B, 50 hôtes : 2⁶ − 2 = 62 ≥ 50 → **/26** (bloc de 64).
- Site C, 20 hôtes : 2⁵ − 2 = 30 ≥ 20 → **/27** (bloc de 32).

**Étape 3**, allouer dans l'ordre décroissant, en partant de 192.168.20.0 :

- Site A occupe le premier bloc de 128 : 192.168.20.**0** à 192.168.20.127.
- Site B commence juste après (128), qui est bien un multiple de 64 → 192.168.20.**128** à
  192.168.20.191.
- Site C commence juste après (192), qui est bien un multiple de 32 → 192.168.20.**192** à
  192.168.20.223.

## Vérifier son travail

Vérifie que chaque adresse réseau que tu as trouvée est bien un multiple de la taille de son
propre bloc — sinon, il y a une erreur d'allocation quelque part. Compare avec les fichiers
correspondants dans `Corrige/` si besoin.

**Suite : [7. Adressage IPv4 avancé](../../docs/07-adressage-ipv4-avance.md)**
