# 8. Adressage IPv6

## Pourquoi IPv6

L'IPv4 (leçons 4 à 7) ne propose que 2³² adresses, soit un peu plus de 4 milliards — un
nombre qui a fini par ne plus suffire face au nombre d'appareils connectés. L'**IPv6** répond
à ce problème en passant à des adresses de **128 bits**, soit 2¹²⁸ adresses possibles (un
nombre à 39 chiffres). Beaucoup de principes vus pour IPv4 se retrouvent en IPv6 sous une
forme adaptée — c'est volontairement le fil conducteur des deux prochaines leçons.

## Structure d'une adresse IPv6

Une adresse IPv6 s'écrit en **8 groupes de 4 chiffres hexadécimaux** (chaque groupe, appelé
un *hextet*, code 16 bits), séparés par `:` :

```
2001:0db8:0000:0000:0000:ff00:0042:8329
```

C'est exactement pour cette raison que la leçon 3 a insisté sur l'hexadécimal : une adresse
IPv6 est bien plus lisible en hexadécimal qu'elle ne le serait en binaire (32 chiffres
hexadécimaux contre 128 chiffres binaires, pour la même information).

## Compresser une adresse IPv6

Deux règles, à appliquer **dans cet ordre**, permettent de raccourcir l'écriture :

1. **Zéros de tête** : dans chaque groupe, les zéros de tête peuvent être omis (`0db8`
   devient `db8`, `0042` devient `42`). Cette règle s'applique indépendamment à chaque
   groupe.
2. **Groupes entièrement à zéro** : la plus longue suite de groupes consécutifs qui valent
   tous `0000` peut être remplacée, **une seule fois dans toute l'adresse**, par `::` (deux
   fois deux-points). Si deux suites de même longueur existent, on compresse la première.

Exemple, appliqué à l'adresse ci-dessus :

```
2001:0db8:0000:0000:0000:ff00:0042:8329
```

Étape 1 (zéros de tête par groupe) :

```
2001:db8:0:0:0:ff00:42:8329
```

Étape 2 (la suite de 3 groupes à zéro devient `::`) :

```
2001:db8::ff00:42:8329
```

**Pourquoi une seule fois ?** Parce que `::` doit pouvoir se "déplier" sans ambiguïté : s'il
apparaissait deux fois, il serait impossible de savoir combien de groupes à zéro chaque `::`
représente. Décompresser, c'est l'opération inverse : compter les groupes explicitement
écrits, et insérer à la place du `::` exactement le nombre de groupes `0000` qui manquent
pour arriver à 8 au total.

## Les types d'adresses IPv6

| Type | Plage | Équivalent IPv4 |
|---|---|---|
| Unicast global | 2000::/3 | Adresse publique (leçon 4) |
| Unique local | fc00::/7 | Adresse privée (leçon 4) — rarement utilisée en pratique |
| Link-local | fe80::/10 | APIPA (leçon 7) — sauf qu'en IPv6, **chaque** interface en génère toujours une automatiquement, que le reste de la configuration ait échoué ou non |
| Multicast | ff00::/8 | N'a pas d'équivalent direct : remplace entièrement le broadcast, qui n'existe plus en IPv6 |
| Loopback | ::1 | 127.0.0.1 (leçon 4) |
| Non spécifiée | :: | 0.0.0.0 (leçon 7) |
| Documentation | 2001:db8::/32 | Plages TEST-NET (leçon 7) — c'est d'ailleurs l'adresse utilisée dans tous les exemples de cette leçon, précisément pour cette raison |

**Suite : [9. Sous-réseaux IPv6 et cohabitation IPv4/IPv6](09-sous-reseaux-ipv6.md)**
