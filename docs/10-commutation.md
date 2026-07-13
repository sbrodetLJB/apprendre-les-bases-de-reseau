# 10. Commutation

## L'adresse MAC

Chaque interface réseau (leçon 1) possède, en plus d'une éventuelle adresse IP configurable,
une **adresse MAC** : un identifiant de 48 bits, gravé par le fabricant, écrit en
hexadécimal sous forme de 6 octets séparés par `:` ou `-` :

```
AA:BB:CC:11:22:33
```

Les 3 premiers octets identifient le **fabricant** (OUI, *Organizationally Unique
Identifier*), les 3 derniers sont un numéro de série propre à cette interface. Contrairement
à une adresse IP (attribuée logiquement, leçons 4 et 8), une adresse MAC est en principe fixe
et unique pour chaque interface produite dans le monde.

| | Adresse MAC | Adresse IP |
|---|---|---|
| Couche | Accès réseau | Internet |
| Attribution | Gravée par le fabricant | Configurée (manuellement ou par DHCP, leçon 15) |
| Portée | Valable uniquement sur le réseau local | Valable pour joindre n'importe quel réseau |

## Le rôle du switch : apprentissage et transmission

Un switch relie plusieurs hôtes d'un même réseau local et décide, trame par trame, sur quel
port la transmettre — grâce à une **table de commutation** (table CAM) qui associe chaque
adresse MAC connue au port par lequel elle est joignable.

**Apprentissage** : à chaque trame reçue sur un port, le switch note l'**adresse MAC
source** et le port d'arrivée dans sa table — c'est ainsi qu'il apprend, sans configuration,
où se trouve chaque machine.

**Transmission**, à partir de l'**adresse MAC destination** de la trame :
- Si elle figure dans la table → la trame est transmise **uniquement** sur le port associé.
- Si elle est absente de la table (jamais vue comme source jusqu'ici) → la trame est
  **diffusée** (*flooding*) sur tous les ports, sauf celui d'arrivée.
- Si l'adresse destination est l'adresse de diffusion `FF:FF:FF:FF:FF:FF` → toujours
  diffusée sur tous les ports, sauf celui d'arrivée (quel que soit l'état de la table).

## Exemple complet

Topologie : trois PC reliés à un même switch.

| Équipement | Interface | Adresse MAC | Relié à |
|---|---|---|---|
| PC1 | eth0 | AA:AA:AA:AA:AA:01 | SW1 Fa0/1 |
| PC2 | eth0 | AA:AA:AA:AA:AA:02 | SW1 Fa0/2 |
| PC3 | eth0 | AA:AA:AA:AA:AA:03 | SW1 Fa0/3 |

Table de commutation initialement vide. Trois trames se succèdent :

1. **PC1 → PC2** (source AA:01 sur Fa0/1, destination AA:02). Le switch apprend `AA:01 →
   Fa0/1`. La destination AA:02 est encore inconnue → diffusion sur Fa0/2 **et** Fa0/3.
2. **PC2 → PC1** (source AA:02 sur Fa0/2, destination AA:01). Le switch apprend `AA:02 →
   Fa0/2`. La destination AA:01 est maintenant connue (apprise à l'étape 1) → transmission
   uniquement sur Fa0/1.
3. **PC3 → PC1** (source AA:03 sur Fa0/3, destination AA:01). Le switch apprend `AA:03 →
   Fa0/3`. La destination AA:01 est connue → transmission uniquement sur Fa0/1.

Table de commutation après ces trois trames :

| Adresse MAC | Port |
|---|---|
| AA:AA:AA:AA:AA:01 | Fa0/1 |
| AA:AA:AA:AA:AA:02 | Fa0/2 |
| AA:AA:AA:AA:AA:03 | Fa0/3 |

## Domaines de collision et de diffusion

- **Domaine de collision** : ensemble des machines qui pourraient interférer si elles
  émettaient en même temps sur le même support. Avec un switch moderne (chaque port en
  full-duplex), **chaque port de switch est son propre domaine de collision** — la notion
  vient surtout des anciens hubs, qui partageaient un seul domaine de collision entre tous
  leurs ports.
- **Domaine de diffusion** : ensemble des machines qui reçoivent une trame de diffusion
  (`FF:FF:FF:FF:FF:FF`). **Un switch ne segmente jamais un domaine de diffusion** : toutes
  les machines reliées entre elles uniquement par des switches (sans routeur) appartiennent
  au même domaine de diffusion. Seul un **routeur** (ou un **VLAN**, leçon suivante) le
  segmente.

**Suite : [11. VLAN](11-vlan.md)**
