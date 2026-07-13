# Pas à pas — TP 13 : routage dynamique

Garde sous les yeux le cours
[13-routage-dynamique.md](../../docs/13-routage-dynamique.md), en particulier le tableau des
deux familles de protocoles.

## Raisonnement

Les quatre questions reprennent directement le tableau et le paragraphe qui le suit :

- Le protocole à vecteur de distance du tableau, avec sa limite caractéristique de 15 sauts,
  est nommé explicitement dans la colonne "Exemple" → **RIP**.
- Le protocole à état de liens, qui calcule lui-même le meilleur chemin après avoir construit
  une carte complète, est nommé juste en dessous → **OSPF**.
- Le paragraphe qui suit le tableau précise qu'un routeur RIP ne connaît "que ce que ses
  voisins lui ont dit" (une liste de distances), **pas** une carte complète → réponse
  **non**.
- Toute la section "Le principe du routage dynamique" explique que la bascule en cas de
  panne se fait "sans intervention humaine" → réponse **non**.

## Vérifier son travail

Compare avec `Corrige/01-protocoles.txt` si besoin.

**Suite : [14. Filtrage et sécurité de base](../../docs/14-filtrage-et-securite.md)**
