# Pas à pas — TP 1 : le modèle en couches

Garde sous les yeux le cours [01-introduction-aux-reseaux.md](../../docs/01-introduction-aux-reseaux.md),
en particulier le tableau "Un modèle en couches pour s'y retrouver".

## Avant de commencer

1. Ouvre `tp/01-introduction-aux-reseaux/Enonce/01-couches.txt` dans un éditeur de texte.
2. Repère les quatre couches du cours, dans l'ordre : Application, Transport, Internet, Accès
   réseau. Chacune a une unité de données qui lui est propre.
3. À chaque ligne du fichier correspond une unité de données. Le but est d'écrire, après les
   deux-points, le nom de la couche à laquelle elle appartient.

## Exercice 1 : les unités de données

Le cours donne directement la correspondance dans son tableau. Relis-le une ligne à la fois :

- Un **message** est ce qu'une application veut envoyer (une page web, un email...) → couche
  **Application**.
- Un **segment** est un message découpé et associé à des ports par la couche Transport →
  couche **Transport**.
- Un **paquet** est un segment auquel une adresse IP a été ajoutée par la couche Internet →
  couche **Internet**.
- Une **trame** est un paquet prêt à circuler sur le câble, encadré par la couche Accès
  réseau → couche **Accès réseau**.

Complète chaque ligne de `01-couches.txt` avec la couche correspondante, exactement comme
dans le tableau du cours (l'accent de "Accès réseau" compte, mais pas la casse).

## Exercice 2 : les tâches

Ouvre `tp/01-introduction-aux-reseaux/Enonce/02-taches.txt`. Cette fois, il ne s'agit plus de
reconnaître une unité de données mais une **tâche** — raisonne à partir de ce que fait
chaque couche (section "Un modèle en couches pour s'y retrouver" du cours) :

- "Envoyer une trame sur le bon port du switch" : c'est un switch qui fait ça, et le cours
  indique qu'un switch opère au niveau de la couche **Accès réseau**.
- "Contacter le bon réseau pour joindre une adresse IP" : c'est le rôle d'un routeur, qui
  raisonne en adresses IP — couche **Internet**.
- "Découper les données et gérer les ports source/destination" : c'est très exactement la
  définition de la couche **Transport** donnée dans le tableau du cours.
- "Afficher le contenu d'une page web" : c'est l'application elle-même qui interprète le
  contenu reçu — couche **Application**.

## Vérifier son travail

Chaque fichier doit contenir quatre réponses, une par ligne, parmi exactement les quatre
couches du cours. Compare avec `../Corrige/01-couches.txt` et `../Corrige/02-taches.txt` si
besoin — ici, contrairement au cours de bases de données, il n'y a qu'une seule bonne réponse
par ligne.

**Suite : [2. Numération binaire](../../docs/02-numeration-binaire.md)**
