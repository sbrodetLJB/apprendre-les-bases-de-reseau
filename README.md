# Apprendre les bases de réseau

Support de cours progressif pour apprendre les fondamentaux des réseaux informatiques, en
partant de zéro : **numération** (binaire, octale, hexadécimale), **adressage IPv4 et
IPv6**, **commutation**, **routage** et **filtrage** (ports, pare-feu, listes de contrôle
d'accès).

Ce cours ne suppose **aucune connaissance préalable** en réseau. Il est autonome : il ne
dépend d'aucun autre cours de ce dépôt.

> Étudiant·e utilisant NVDA ou un autre lecteur d'écran ? Lire [NVDA.md](NVDA.md) avant de commencer.

Chaque leçon contient :
- un **cours** dans [docs/](docs/) (markdown, en français) ;
- un **TP** correspondant dans [tp/](tp/), avec un dossier `Enonce/` (des gabarits texte à
  remplir), un fichier `PasAPas.md` (guide pas à pas) et un dossier `Corrige/` (la solution).

## Prérequis

Aucun logiciel spécifique, aucun serveur, aucun accès réseau : tous les TP de ce cours se
font **par le calcul**, sur papier ou dans un simple éditeur de texte (VS Code par exemple).
C'est un choix délibéré (voir [NVDA.md](NVDA.md)) : les simulateurs réseau graphiques
habituels (topologies à glisser-déposer) sont peu utilisables avec un lecteur d'écran, et ce
cours n'en a de toute façon pas besoin pour couvrir en profondeur l'adressage, la
commutation, le routage et le filtrage.

## Plan du cours

| # | Leçon | TP |
|---|---|---|
| 1 | [Introduction aux réseaux](docs/01-introduction-aux-reseaux.md) | [tp/01-introduction-aux-reseaux](tp/01-introduction-aux-reseaux) |
| 2 | [Numération binaire](docs/02-numeration-binaire.md) | [tp/02-numeration-binaire](tp/02-numeration-binaire) |
| 3 | [Numération hexadécimale et octale](docs/03-numeration-hexadecimale-octale.md) | [tp/03-numeration-hexadecimale-octale](tp/03-numeration-hexadecimale-octale) |
| 4 | [Adressage IPv4](docs/04-adressage-ipv4.md) | [tp/04-adressage-ipv4](tp/04-adressage-ipv4) |
| 5 | [Masques et CIDR](docs/05-masques-et-cidr.md) | [tp/05-masques-et-cidr](tp/05-masques-et-cidr) |
| 6 | [Découpage en sous-réseaux](docs/06-decoupage-en-sous-reseaux.md) | [tp/06-decoupage-en-sous-reseaux](tp/06-decoupage-en-sous-reseaux) |
| 7 | [Adressage IPv4 avancé](docs/07-adressage-ipv4-avance.md) | [tp/07-adressage-ipv4-avance](tp/07-adressage-ipv4-avance) |
| 8 | [Adressage IPv6](docs/08-adressage-ipv6.md) | [tp/08-adressage-ipv6](tp/08-adressage-ipv6) |
| 9 | [Sous-réseaux IPv6 et cohabitation IPv4/IPv6](docs/09-sous-reseaux-ipv6.md) | [tp/09-sous-reseaux-ipv6](tp/09-sous-reseaux-ipv6) |
| 10 | [Commutation](docs/10-commutation.md) | [tp/10-commutation](tp/10-commutation) |
| 11 | [VLAN](docs/11-vlan.md) | [tp/11-vlan](tp/11-vlan) |
| 12 | [Routage](docs/12-routage.md) | [tp/12-routage](tp/12-routage) |
| 13 | [Routage dynamique (aperçu)](docs/13-routage-dynamique.md) | [tp/13-routage-dynamique](tp/13-routage-dynamique) |
| 14 | [Filtrage et sécurité de base](docs/14-filtrage-et-securite.md) | [tp/14-filtrage-et-securite](tp/14-filtrage-et-securite) |
| 15 | [Services réseau et projet de synthèse](docs/15-services-et-synthese.md) | [tp/15-services-et-synthese](tp/15-services-et-synthese) |

## Deux fils conducteurs, présents dans (presque) toutes les leçons

- **Méthode de calcul** : une méthode fixe et réutilisable pour tout exercice d'adressage
  (conversion en binaire → application du masque/préfixe → lecture du résultat), introduite
  dès la leçon 5 et reprise à l'identique ensuite — pour ne jamais avoir à réinventer la
  démarche à chaque nouvel exercice.
- **IPv4 et IPv6 en parallèle** : chaque notion vue pour IPv4 (masque/CIDR, découpage en
  sous-réseaux...) est reprise juste après pour IPv6, pour s'appuyer sur l'analogie plutôt
  que de traiter les deux comme des sujets sans rapport.

## Comment travailler

1. Lire le cours de la leçon dans `docs/`.
2. Ouvrir `tp/0X-.../Enonce/`, remplir les gabarits texte (chaque champ à compléter est
   laissé vide, précédé de son intitulé).
3. Bloqué·e ? Ouvrir `tp/0X-.../PasAPas.md`, qui guide le calcul étape par étape.
4. Poser le calcul et vérifier chaque valeur soi-même : ce cours n'a rien à exécuter, la
   seule vérification possible est de refaire le calcul et de le confronter au corrigé.
5. Comparer avec `tp/0X-.../Corrige/` — le format attendu est précisé dans chaque énoncé
   (notation décimale ou CIDR, forme compressée ou développée pour IPv6...), il n'y a donc
   qu'une seule bonne réponse par champ, contrairement au cours de bases de données.

## Environnement de TP

Aucun. C'est la principale différence avec les autres cours de ce dépôt : pas de serveur TP
Manager, pas de base de données, pas de simulateur réseau. Un éditeur de texte suffit pour
ouvrir un énoncé, y écrire ses réponses, et l'enregistrer.

## Lien avec les autres cours

Ce cours est autonome (aucun prérequis lié aux autres dépôts) et ne suppose aucune
connaissance issue de
[apprendre-la-programmation-web](https://github.com/sbrodetLJB/apprendre-la-programmation-web)
ni de
[apprendre-les-bases-de-donnees](https://github.com/sbrodetLJB/apprendre-les-bases-de-donnees).
