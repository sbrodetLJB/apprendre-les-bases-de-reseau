# Pas à pas — TP 8 : adressage IPv6

Garde sous les yeux le cours [08-adressage-ipv6.md](../../docs/08-adressage-ipv6.md).

## Exercice 1 : compression

Applique les deux règles du cours, dans l'ordre.

Exemple détaillé avec `fe80:0000:0000:0000:0202:b3ff:fe1e:8329` :

**Règle 1** (zéros de tête par groupe) : `fe80:0:0:0:202:b3ff:fe1e:8329`.

**Règle 2** (la plus longue suite de groupes à zéro devient `::`) : les groupes 2, 3 et 4
valent tous 0 → `fe80::202:b3ff:fe1e:8329`.

Pour la dernière ligne (que des zéros, sauf le dernier groupe), la règle 2 s'applique à toute
l'adresse sauf le dernier groupe : il ne reste que `::1`.

## Exercice 2 : décompression

Compte d'abord combien de groupes sont écrits explicitement, puis insère à la place du `::`
autant de groupes `0000` qu'il en manque pour arriver à 8.

Exemple détaillé avec `fe80::1` : deux groupes explicites (`fe80` et `1`) → il manque 8 − 2 =
6 groupes à zéro. Résultat, en n'oubliant pas de remettre les zéros de tête sur chaque
groupe : `fe80:0000:0000:0000:0000:0000:0000:0001`.

## Exercice 3 : types d'adresses

Compare chaque adresse au tableau du cours (section "Les types d'adresses IPv6"), en
regardant son préfixe :

- `fe80::1` commence par `fe80` → **link-local**.
- `ff02::1` commence par `ff` → **multicast**.
- `::1` → **loopback** (cas particulier, à connaître directement).
- `2001:db8::5` commence par `2001:db8` → **documentation**, la plage réservée aux exemples,
  utilisée dans tout le cours.
- `::` (rien d'autre) → **non spécifiée**.
- `2606:4700:4700::1111` ne correspond à aucune des plages réservées ci-dessus → **unicast
  global**, une vraie adresse routable sur Internet.

## Vérifier son travail

Compare avec les fichiers correspondants dans `Corrige/` si besoin.

**Suite : [9. Sous-réseaux IPv6 et cohabitation IPv4/IPv6](../../docs/09-sous-reseaux-ipv6.md)**
