# Pas à pas — TP 5 : masques et CIDR

Garde sous les yeux le cours [05-masques-et-cidr.md](../../docs/05-masques-et-cidr.md), en
particulier le tableau des 9 valeurs de masque par octet et l'exemple fil rouge
`192.168.1.77/26`.

## Exercice 1 : conversions CIDR ↔ décimal

Découpe le nombre de bits en tranches de 8, dans l'ordre des octets, et utilise le tableau du
cours pour le reste.

Exemple détaillé avec `/20` : 20 = 8 + 8 + 4. Les deux premiers octets sont donc pleins
(255.255), et le troisième correspond à 4 bits à 1 dans le tableau → 240. Résultat :
**`255.255.240.0`**.

Pour l'autre sens (`255.255.255.248` vers CIDR), retrouve combien de bits à 1 correspond à
248 dans le même tableau (5), et additionne : 8 + 8 + 8 + 5 = **`/29`**.

## Exercice 2 : calcul complet pour 192.168.5.130/27

Suis exactement les 4 étapes du cours (section "La méthode de calcul").

**Étape 1**, convertir 130 en binaire : `10000010`.

**Étape 2**, le masque `/27` vaut, dans le 4ᵉ octet, 3 bits à 1 → `224` (`11100000`).
ET bit à bit :

```
  10000010
ET 11100000
-----------
  10000000   = 128
```

Adresse réseau : **192.168.5.128**.

**Étape 3**, forcer les bits hôte (les 5 derniers) à 1 : `10000000` devient `10011111` = 159.
Adresse de diffusion : **192.168.5.159**.

**Étape 4**, lire le résultat : plage utilisable de 192.168.5.**129** à 192.168.5.**158**,
soit 2⁵ − 2 = **30** hôtes utilisables (5 bits hôte, puisque /27 laisse 32 − 27 = 5 bits).

## Exercice 3 : calcul complet pour 10.4.200.9/22

Ce sous-réseau est plus grand qu'un `/24` habituel : sa partie hôte déborde sur le 3ᵉ octet
(32 − 22 = 10 bits hôte, répartis sur la fin du 3ᵉ octet et tout le 4ᵉ). Le principe reste
identique, seule la position de la coupure change.

**Étape 1**, convertir 200 en binaire : `11001000`.

**Étape 2**, le masque `/22` vaut, dans le 3ᵉ octet, 6 bits à 1 → `252` (`11111100`) ; le 4ᵉ
octet est entièrement hôte (`00000000`). ET bit à bit sur le 3ᵉ octet :

```
  11001000
ET 11111100
-----------
  11001000   = 200 (inchangé : les 2 derniers bits de 200 étaient déjà à 0)
```

Adresse réseau : **10.4.200.0** (4ᵉ octet forcé à 0, entièrement hôte).

**Étape 3**, forcer les bits hôte à 1 : sur le 3ᵉ octet, les 2 derniers bits de `11001000`
passent à 1 → `11001011` = 203 ; le 4ᵉ octet devient entièrement `11111111` = 255. Adresse de
diffusion : **10.4.203.255**.

**Étape 4**, lire le résultat : plage utilisable de 10.4.200.**1** à 10.4.203.**254**, soit
2¹⁰ − 2 = **1022** hôtes utilisables.

## Vérifier son travail

Compare avec les fichiers correspondants dans `Corrige/` si besoin. Le point le plus fréquent
à se tromper est l'exercice 3 : bien vérifier que la partie hôte déborde sur le 3ᵉ octet
plutôt que de rester (à tort) cantonnée au seul 4ᵉ octet.

**Suite : [6. Découpage en sous-réseaux](../../docs/06-decoupage-en-sous-reseaux.md)**
