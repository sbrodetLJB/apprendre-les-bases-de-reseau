# 13. Routage dynamique (aperçu)

## La limite du routage statique

La leçon 12 s'est terminée sur la limite du routage statique : chaque route est saisie à la
main, donc **rien ne s'adapte automatiquement** en cas de panne d'un lien ou d'ajout d'un
nouveau réseau — il faut reconfigurer chaque routeur concerné soi-même. Sur un réseau avec
peu de routeurs, ce n'est pas un problème ; sur un réseau plus grand, ça le devient vite.

## Le principe du routage dynamique

Avec le **routage dynamique**, les routeurs échangent automatiquement, entre eux, des
informations sur les réseaux qu'ils connaissent, via un **protocole de routage** — et mettent
à jour leur table tout seuls, y compris en cas de panne (bascule vers une route de secours
sans intervention humaine). Cette leçon reste volontairement un aperçu conceptuel : configurer
un protocole de routage dynamique est un sujet à part entière, hors du périmètre d'un cours
d'introduction.

## Deux grandes familles

| Famille | Principe | Exemple | Limite |
|---|---|---|---|
| **Vecteur de distance** | Chaque routeur annonce à ses voisins directs la liste des réseaux qu'il connaît, avec leur distance (nombre de sauts) | **RIP** (*Routing Information Protocol*) | Limité à 15 sauts maximum ; converge lentement après un changement |
| **État de liens** | Chaque routeur diffuse l'état de ses liens directs à **tous** les autres routeurs, qui construisent chacun une carte complète de la topologie et calculent eux-mêmes le meilleur chemin | **OSPF** (*Open Shortest Path First*) | Plus complexe à mettre en œuvre, mais converge plus vite et passe mieux à l'échelle |

La différence clé à retenir : un routeur RIP ne connaît jamais que "ce que ses voisins lui
ont dit" (une liste de distances), alors qu'un routeur OSPF construit une **carte complète**
du réseau avant de calculer lui-même le meilleur chemin (avec un algorithme de plus court
chemin, comme celui de Dijkstra).

**Suite : [14. Filtrage et sécurité de base](14-filtrage-et-securite.md)**
