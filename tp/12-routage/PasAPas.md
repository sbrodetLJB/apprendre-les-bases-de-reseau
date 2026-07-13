# Pas à pas — TP 12 : routage

Garde sous les yeux le cours [12-routage.md](../../docs/12-routage.md), en particulier son
"Exemple complet" — c'est exactement la table de routage de ce TP.

## Méthode

Pour chaque adresse, liste **toutes** les routes de la table qui la contiennent, puis
applique la règle du plus long préfixe (le `/n` le plus élevé l'emporte) si plusieurs routes
correspondent.

- **192.168.1.50** : une seule route correspond, `192.168.1.0/24` → **connecté directement**.
- **10.0.5.20** : deux routes correspondent, `10.0.0.0/8` **et** `10.0.5.0/24` (10.0.5.20
  appartient bien aux deux). `/24` étant plus spécifique que `/8`, c'est elle qui l'emporte →
  passerelle **192.168.2.254**.
- **10.1.1.1** : vérifie bien laquelle des deux routes "10" correspond réellement —
  10.1.1.1 n'appartient **pas** à `10.0.5.0/24` (le 3ᵉ octet doit valoir exactement 5), donc
  seule `10.0.0.0/8` correspond → passerelle **192.168.1.254**.
- **8.8.8.8** : aucune route spécifique ne correspond → route par défaut `0.0.0.0/0` →
  passerelle **192.168.1.1**.

## Vérifier son travail

Compare avec `Corrige/01-table-de-routage.txt` si besoin. L'erreur la plus fréquente est sur
10.1.1.1 : bien vérifier l'intervalle exact de chaque route avant de conclure, comme pour
l'exercice 3 de la leçon 4.

**Suite : [13. Routage dynamique (aperçu)](../../docs/13-routage-dynamique.md)**
