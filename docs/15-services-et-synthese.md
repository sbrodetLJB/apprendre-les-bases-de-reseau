# 15. Services réseau et projet de synthèse

## DHCP : attribuer une configuration IP automatiquement

Configurer une adresse IP à la main sur chaque machine d'un réseau ne passe pas à l'échelle.
Le **DHCP** (*Dynamic Host Configuration Protocol*) automatise cette attribution : une
machine qui se connecte reçoit automatiquement une adresse IP, un masque, une passerelle par
défaut et un serveur DNS, sans aucune configuration manuelle.

Le principe tient en quatre échanges, parfois résumés par l'acronyme **DORA** :

| Étape | Message | Sens |
|---|---|---|
| 1 | **D**iscover | La machine diffuse "je cherche un serveur DHCP" (elle n'a pas encore d'adresse) |
| 2 | **O**ffer | Un serveur DHCP répond "voici une adresse disponible" |
| 3 | **R**equest | La machine confirme "je prends cette adresse" |
| 4 | **A**cknowledge | Le serveur valide définitivement l'attribution |

Rappel de la leçon 7 : si aucun serveur DHCP ne répond, la machine se rabat après un délai
sur une adresse **APIPA** (169.254.0.0/16) — un symptôme facile à reconnaître en cas de
panne du service DHCP.

## DNS : traduire un nom en adresse

Personne ne mémorise des adresses IP pour naviguer sur le web : le **DNS** (*Domain Name
System*) traduit un nom de domaine (`www.example.com`) en l'adresse IP du serveur à
contacter. Cette résolution est **hiérarchique** : un serveur DNS qui ne connaît pas la
réponse interroge un serveur plus proche de l'autorité sur ce nom, jusqu'à obtenir une
réponse — un mécanisme distribué, à l'échelle d'Internet tout entier, dont le détail dépasse
le périmètre de ce cours d'introduction.

## Le projet de synthèse

Ce dernier TP réunit, sur un seul scénario, l'adressage (leçons 4 à 9), le routage (leçons 12
et 13) et le filtrage (leçon 14) : concevoir l'adressage IPv4 d'une petite entreprise à deux
sites à partir d'un unique bloc `/24`, en déterminer le routage inter-sites, puis vérifier
quelques règles de filtrage. L'énoncé complet (topologie, besoins en hôtes, règles à
appliquer) se trouve dans `tp/15-services-et-synthese/Enonce/`.

Ce projet ne couvre volontairement aucune notion inédite : c'est l'occasion de vérifier que
la méthode de calcul de la leçon 5, reprise dans toutes les leçons suivantes, est maintenant
appliquée sans avoir besoin de relire le cours à chaque étape.
