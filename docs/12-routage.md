# 12. Routage

## Le rôle du routeur

Rappel de la leçon 1 : un routeur relie des **réseaux différents** entre eux (alors qu'un
switch relie des machines à l'intérieur d'un même réseau, leçon 10). Pour décider où envoyer
chaque paquet, un routeur consulte sa **table de routage**.

## La table de routage

Une table de routage liste, pour chaque réseau de destination connu, comment l'atteindre :

| Colonne | Signification |
|---|---|
| Réseau de destination | Une adresse réseau + masque (ou préfixe CIDR) |
| Passerelle (next-hop) | L'adresse IP du routeur suivant à qui transmettre le paquet — ou "connecté directement" si le réseau est directement relié à une interface de ce routeur |
| Métrique | Un coût, utilisé pour départager plusieurs routes possibles vers le même réseau (plus c'est petit, mieux c'est) |

**Route par défaut** (rappel leçon 7) : la route `0.0.0.0/0` signifie "tout le reste" —
utilisée seulement si aucune autre route de la table ne correspond mieux à l'adresse
recherchée.

## La règle du plus long préfixe correspondant

Quand **plusieurs** routes de la table correspondent à une même adresse de destination, le
routeur choisit toujours celle dont le masque est **le plus spécifique** (le plus grand
nombre de bits, donc le préfixe `/n` le plus élevé) — c'est la règle du **plus long préfixe
correspondant** (*longest prefix match*). Une route plus précise l'emporte toujours sur une
route plus générale, quelle que soit la métrique.

## Exemple complet

Table de routage d'un routeur :

| Réseau de destination | Passerelle | Métrique |
|---|---|---|
| 192.168.1.0/24 | connecté directement (Fa0/0) | 0 |
| 192.168.2.0/24 | connecté directement (Fa0/1) | 0 |
| 10.0.0.0/8 | 192.168.1.254 | 1 |
| 10.0.5.0/24 | 192.168.2.254 | 1 |
| 0.0.0.0/0 | 192.168.1.1 | 1 |

Pour chaque adresse de destination, la route retenue :

- **192.168.1.50** → correspond à `192.168.1.0/24` (et à aucune autre route) → connecté
  directement sur Fa0/0.
- **10.0.5.20** → correspond à **deux** routes, `10.0.0.0/8` et `10.0.5.0/24`. La règle du
  plus long préfixe fait gagner `/24` (plus spécifique que `/8`) → passerelle
  **192.168.2.254**.
- **10.1.1.1** → correspond uniquement à `10.0.0.0/8` (`10.0.5.0/24` ne couvre pas
  10.**1**.1.1) → passerelle **192.168.1.254**.
- **8.8.8.8** → ne correspond à aucune route spécifique → route par défaut `0.0.0.0/0` →
  passerelle **192.168.1.1**.

## Routage statique

Les routes de cette table ont été saisies **manuellement** par un administrateur : c'est le
**routage statique**. Simple à comprendre et à sécuriser (aucune route n'apparaît sans que
quelqu'un l'ait explicitement configurée), mais il faut la mettre à jour à la main à chaque
changement de topologie — ce que corrige le routage dynamique, sujet de la prochaine leçon.

**Suite : [13. Routage dynamique (aperçu)](13-routage-dynamique.md)**
