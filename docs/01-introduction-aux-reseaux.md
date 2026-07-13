# 1. Introduction aux réseaux

## Pourquoi un réseau

Un réseau informatique relie des machines entre elles pour qu'elles puissent échanger des
informations : partager un fichier, afficher une page web, envoyer un message, imprimer sur
une imprimante partagée. Sans réseau, chaque machine serait isolée. Ce cours explique
comment ces échanges sont rendus possibles, en partant des couches les plus concrètes
(comment un signal circule sur un câble) jusqu'aux plus abstraites (comment deux
applications se comprennent).

## Le vocabulaire de base

| Terme | Définition |
|---|---|
| **Hôte** | Une machine qui participe au réseau (ordinateur, serveur, smartphone...). |
| **Interface réseau** | Le point de connexion d'un hôte au réseau (une carte réseau filaire, une puce Wi-Fi...). Un hôte peut avoir plusieurs interfaces. |
| **Adresse** | Un identifiant qui permet de désigner un hôte (ou une interface) sur le réseau, pour lui envoyer des données. Ce cours en étudie deux types : les adresses **MAC** (leçon 10) et les adresses **IP** (leçons 4 à 9). |
| **Protocole** | Un ensemble de règles convenues à l'avance, que les deux extrémités d'une communication respectent, pour se comprendre. |
| **Réseau local (LAN)** | Un ensemble de machines proches, reliées directement (un bâtiment, une salle de TP...). |
| **Interconnexion de réseaux** | Le fait de relier plusieurs réseaux locaux entre eux (Internet en est le plus grand exemple). |

## Un modèle en couches pour s'y retrouver

Un échange réseau complet (afficher une page web, par exemple) combine en réalité plusieurs
problèmes bien distincts, résolus indépendamment les uns des autres : comment transporter des
bits sur un câble, comment adresser une machine parmi des millions, comment garantir qu'aucune
donnée ne se perd en route, comment l'application sait quoi faire du contenu reçu. Découper
ces problèmes en **couches** permet de les traiter séparément.

Il existe un modèle très complet à 7 couches (le modèle OSI), mais ce cours utilise une
version simplifiée à 4 couches, directement alignée sur la suite de protocoles réellement
utilisée sur Internet (TCP/IP) et sur le découpage des leçons qui suivent :

| Couche | Rôle | Unité de données | Vu dans ce cours |
|---|---|---|---|
| Application | Le format compris par les logiciels (page web, email, fichier...) | Message | (hors périmètre de ce cours) |
| Transport | Découpe les données, gère les ports, fiabilise (ou non) l'acheminement | Segment | Leçon 14 (filtrage, ports TCP/UDP) |
| Internet | Adresse chaque machine et détermine le chemin entre réseaux | Paquet | Leçons 4 à 9 (IPv4/IPv6), 12-13 (routage) |
| Accès réseau | Transporte les données sur un support physique local (câble, Wi-Fi) | Trame | Leçons 10-11 (commutation, VLAN) |

Chaque couche ajoute sa propre "enveloppe" à ce que lui donne la couche du dessus — c'est ce
qu'on appelle l'**encapsulation**. Un message applicatif devient un segment (couche
Transport), qui devient un paquet une fois une adresse IP ajoutée (couche Internet), qui
devient à son tour une trame une fois prêt à circuler sur le câble (couche Accès réseau). À
l'arrivée, chaque couche du destinataire retire l'enveloppe qui la concerne, dans l'ordre
inverse.

## Les équipements réseau

| Équipement | Couche où il opère | Rôle |
|---|---|---|
| **Hôte** (PC, serveur, smartphone...) | Toutes | Émet et reçoit des données, exécute les applications. |
| **Commutateur (switch)** | Accès réseau | Relie plusieurs hôtes d'un même réseau local et achemine les trames vers le bon port, à partir de l'adresse MAC de destination (leçon 10). |
| **Routeur** | Internet | Relie plusieurs réseaux différents entre eux et achemine les paquets vers le bon réseau, à partir de l'adresse IP de destination (leçons 12-13). |

La différence entre un switch et un routeur est une des idées les plus importantes de ce
cours, reprise dans plusieurs leçons : un switch relie des machines **à l'intérieur** d'un
même réseau (il ne connaît que des adresses MAC), un routeur relie des réseaux **différents**
entre eux (il raisonne en adresses IP).

## Décrire une topologie sans schéma

Ce cours ne dessine jamais de topologie sous forme de schéma (voir [NVDA.md](../NVDA.md)) :
un petit réseau se décrit entièrement dans un tableau, équipement par équipement, interface
par interface. Exemple : un PC relié à un switch, lui-même relié à un routeur qui donne accès
à Internet.

| Équipement | Interface | Adresse | Relié à |
|---|---|---|---|
| PC1 | eth0 | 192.168.1.10/24 | SW1 |
| SW1 | Fa0/1 | — | PC1 |
| SW1 | Fa0/2 | — | R1 |
| R1 | Fa0/0 | 192.168.1.1/24 | SW1 |
| R1 | Fa0/1 | (accès Internet) | — |

Cette convention sera utilisée dans toutes les leçons qui décrivent un petit réseau
(commutation, routage, filtrage, projet de synthèse final).

**Suite : [2. Numération binaire](02-numeration-binaire.md)**
