# Pas à pas — TP 9 : sous-réseaux IPv6

Garde sous les yeux le cours [09-sous-reseaux-ipv6.md](../../docs/09-sous-reseaux-ipv6.md).

## Exercice 1 : sous-réseaux à partir d'un bloc /48

Le bloc délégué est `2001:db8:aa::/48` : les 3 premiers groupes (`2001`, `db8`, `aa`) sont
fixes. Le 4ᵉ groupe devient le numéro de sous-réseau, à écrire **en hexadécimal** (leçon 3).

- Sous-réseau n°0 : le 4ᵉ groupe vaut `0`, ce qui rejoint directement la suite de zéros déjà
  compressée → **`2001:db8:aa::/64`**.
- Sous-réseau n°5 : 5 s'écrit `5` en hexadécimal (pas de conversion nécessaire, c'est en
  dessous de 10) → **`2001:db8:aa:5::/64`**.
- Sous-réseau n°26 : converti en hexadécimal (méthode de la leçon 3, divisions successives
  par 16) : 26 ÷ 16 = 1 reste 10 (= A) → `1A`, soit `1a` en minuscules →
  **`2001:db8:aa:1a::/64`**.

Dans les trois cas, les 4 derniers groupes (la partie hôte, 64 bits) restent à zéro pour une
adresse de sous-réseau, d'où le `::` final.

## Exercice 2 : cohabitation

Relis la section "Cohabitation IPv4 et IPv6" du cours : le nom de la configuration la plus
répandue, où une machine garde une adresse IPv4 et une adresse IPv6 en même temps, est le
**dual-stack**. Et la convention de préfixe pour un sous-réseau LAN IPv6, déjà vue en tête de
cette leçon, est **/64**.

## Vérifier son travail

Compare avec les fichiers correspondants dans `Corrige/` si besoin.

**Suite : [10. Commutation](../../docs/10-commutation.md)**
