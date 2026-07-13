# Pas à pas — TP 7 : adressage IPv4 avancé

Garde sous les yeux le cours
[07-adressage-ipv4-avance.md](../../docs/07-adressage-ipv4-avance.md).

## Exercice 1 : résumé de routes

**Étape 1**, vérifier que les 4 réseaux sont contigus et de même taille : 10.0.**4**.0/24,
10.0.**5**.0/24, 10.0.**6**.0/24, 10.0.**7**.0/24 — oui, 4 réseaux `/24` qui se suivent.

**Étape 2**, vérifier l'alignement : le premier (10.0.**4**.0) doit être un multiple de 4
(le nombre de réseaux à regrouper) dans le 3ᵉ octet. 4 ÷ 4 = 1, exactement → aligné.

**Étape 3**, nouveau masque : 4 réseaux → log₂(4) = 2 bits à retirer → /24 − 2 = **/22**.

Adresse résumée : **10.0.4.0/22** (on garde l'adresse du premier réseau du groupe).

## Exercice 2 : NAT

Relis la section "Le NAT, en bref" du cours : le routeur remplace l'adresse **source**
privée par sa propre adresse publique avant d'envoyer le paquet vers Internet. Le serveur
distant ne voit donc que l'adresse publique du routeur : **203.0.113.10**. Et puisque le NAT
n'existe justement que parce qu'une adresse privée ne peut pas circuler directement sur
Internet, la réponse à la deuxième question est **non**.

## Exercice 3 : adresses spéciales

Compare chaque adresse au tableau du cours (section "Adresses spéciales, suite de la leçon
4") :

- `169.254.5.5` commence par 169.254 → **APIPA**.
- `127.0.0.1` commence par 127 → **loopback**.
- `192.0.2.15` commence par 192.0.2 → **documentation (TEST-NET)**.
- `0.0.0.0` → **indéterminée**.

## Vérifier son travail

Compare avec les fichiers correspondants dans `Corrige/` si besoin.

**Suite : [8. Adressage IPv6](../../docs/08-adressage-ipv6.md)**
