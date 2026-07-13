# Travailler sur ce cours avec NVDA

Ce cours est conçu pour être utilisable à 100% avec un lecteur d'écran (NVDA en particulier),
sans version "adaptée" séparée.

## 1. Naviguer les fichiers markdown (`docs/`, `PasAPas.md`)

Même convention que les autres cours de ce compte : hiérarchie de titres stricte, un seul
titre de niveau 1 par fichier, jamais de saut de niveau.

| Touche NVDA | Action |
|---|---|
| `H` | Titre suivant |
| `Maj+H` | Titre précédent |
| `1` à `6` | Titre de niveau N suivant |
| `K` | Lien suivant |
| `T` | Tableau suivant |
| `Ctrl+Alt+Flèches` | Se déplacer cellule par cellule dans un tableau, avec annonce de l'en-tête de colonne |

## 2. Les topologies réseau sans schéma visuel

Le plus gros piège accessibilité de ce sujet, habituellement, ce sont les schémas de
topologie (rectangles reliés par des traits, équipements dessinés). Ce cours n'en utilise
aucun : dès qu'une leçon ou un TP décrit une topologie (commutation, routage, filtrage,
projet de synthèse), elle est notée **dans un tableau markdown**, navigable comme n'importe
quel autre tableau de ce cours :

```
| Équipement | Interface | Adresse | Relié à |
|---|---|---|---|
| R1 | Fa0/0 | 192.168.1.1/24 | SW1 |
| SW1 | Fa0/1 | — | R1 |
| SW1 | Fa0/2 | — | PC1 |
| PC1 | eth0 | 192.168.1.10/24 | SW1 |
```

Ce n'est pas une adaptation dégradée : un tableau porte exactement la même information qu'un
schéma (quel équipement, quelle interface, quelle adresse, relié à quoi), sans rien perdre —
même raisonnement que la notation Merise textuelle du cours
[apprendre-les-bases-de-donnees](https://github.com/sbrodetLJB/apprendre-les-bases-de-donnees).

## 3. Le format des gabarits de TP

Contrairement aux cours de code de ce dépôt, les fichiers `Enonce/NN-exercice.txt` de ce
cours ne sont pas du code : ce sont de simples gabarits, une ligne par champ à renseigner,
par exemple :

```
Adresse réseau :
Adresse de diffusion :
Première adresse utilisable :
Dernière adresse utilisable :
Nombre d'hôtes utilisables :
```

Rien de plus qu'un fichier texte brut, lu ligne par ligne par NVDA sans aucune difficulté
particulière — pas besoin de tableau ici, un gabarit à compléter reste plus simple à remplir
dans un éditeur de texte qu'un tableau markdown.

## 4. Vérifier son propre travail

Contrairement au cours de bases de données, un exercice de ce cours **a une seule bonne
réponse par champ** : chaque énoncé précise explicitement le format attendu (notation
décimale ou CIDR, forme compressée ou développée pour une adresse IPv6...), justement pour
qu'il n'y ait jamais à deviner "la" forme correcte. C'est ce que vérifie l'outil
`correcteur/` (voir [correcteur/README.md](correcteur/README.md)) : il compare le texte de ta
réponse, champ par champ, à celui du corrigé.
