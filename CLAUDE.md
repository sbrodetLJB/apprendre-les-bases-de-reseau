# CLAUDE.md — apprendre-les-bases-de-reseau

Règles de travail à appliquer automatiquement sur ce projet. Fait partie de la famille
apprendre+game (voir `../FAMILLE_APPRENDRE_GAME.md`) — source pédagogique dont
`game-apprendre-RESEAU` est la version gamifiée standalone, intégrée dans dashboard-ecole sous
`reseau-learning`. Prolongé par `apprendre-reseau-avance` (leçons 16-19, Cisco IOS).

## Contexte rapide

Fondamentaux réseau (binaire, IPv4/IPv6, commutation, routage, filtrage), 15 leçons, TP + corrigés,
correcteur automatique par diff de texte (`correcteur/`). **Conçu explicitement pour
l'accessibilité** : pas de simulateur graphique, pensé NVDA-friendly dès la conception — c'est une
contrainte de conception, pas une option. Structure : `NVDA.md, README.md, correcteur/, docs/,
tp/`. Repo GitHub privé `sbrodetLJB/apprendre-les-bases-de-reseau`, branche par défaut `main`.

---

## Règles non négociables

### 1. Préserver la limite d'usage
Pas de sous-agents sauf besoin réel d'exploration large. Effort `low`/`medium` pour une leçon
isolée ; `high` pour une refonte du correcteur ou de la progression.

### 2. Toujours vérifier en réel — jamais se contenter du code
Exécuter le correcteur pour de vrai contre une réponse correcte ET incorrecte. **Vérifier le rendu
NVDA sur tout nouveau contenu n'est pas optionnel ici** — c'est la contrainte de conception
fondatrice du projet, pas un supplément.

### 3. Documenter systématiquement
`README.md` à jour (sommaire), `docs/` pour le contenu détaillé. Le cours tient lieu de "guide
utilisateur".

### 4. Confirmer avant les vrais choix pédagogiques structurants
`AskUserQuestion` avant de réordonner les leçons ou changer la progression — en particulier tout
ce qui toucherait à l'articulation avec `apprendre-reseau-avance` (leçons 16-19), qui suppose
explicitement rester dans le même parcours.

### 5. Cohérence avec `game-apprendre-RESEAU` et `reseau-learning`
**Attention : `reseau-learning` dans dashboard-ecole a déjà divergé au-delà de ce dépôt** (leçons
Cisco 16-19 + feature "Ateliers réseau" ajoutées directement côté dashboard-ecole, absentes d'ici
et de `game-apprendre-RESEAU`). Signaler tout changement ici comme potentiellement impactant, mais
ne pas supposer que dashboard-ecole reflète encore fidèlement ce contenu.

### 6. Git — commits, branches, versioning
- Commit + push automatique dès qu'un changement est livré ET vérifié en réel.
- Changement majeur (réorganisation, refonte du correcteur) : branche dédiée, testée en réel,
  **fusion dans `main` seulement après votre validation**.
- Tag de version (`vX.Y.Z`) uniquement à la clôture d'un bloc de leçons complet.
- À chaque tag : tag git + `CHANGELOG.md` (racine, à créer) + `README.md` à jour.
- Actions destructrices exclues — toujours confirmées avant exécution.

---

## Où documenter quoi

| Contenu | Fichier |
|---|---|
| Sommaire du cours | `README.md` |
| Contenu pédagogique détaillé | `docs/` |
| TP + corrigés | `tp/` |
| Correcteur (diff de texte) | `correcteur/` |
| Accessibilité NVDA (contrainte fondatrice) | `NVDA.md` |
| Historique des versions | `CHANGELOG.md` (à créer) |
| Convention famille + mapping dashboard-ecole | `../FAMILLE_APPRENDRE_GAME.md` |
