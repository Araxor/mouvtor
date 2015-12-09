# Mouvtor

## Equipe

- Lucien Camuglia
- Alan Devaud
- Dimitri Lizzi

## But

Conception d'une application multi-input pour l'apprentissage de mouvements.

## Travail à réaliser

TODO: copier document fourni

## Environnement

## Travail à rendre

## Structure

Deux vues:

- Une application d'enregistrement de tracés
    + Bouton de début d'enregistrement
    + Bouton de fin d'enregistrement
    + Sauvegarde du tracé dans un fichier
    + Ouverture d'un tracé depuis un fichier
    + Outils de dessin du tracé
        * Ligne droite
        * Libre
    + Outils de sélection (bonus si le temps le permet)
        * Souris
        * Zone
    + Zone de dessin
- Une application de reproduction de tracés
    + Ouverture d'un fichier de tracé
    + Affichage du tracé demandé
    + Enregistrement du tracé de l'utilisateur et évalution de la similarité avec le tracé original

Un tracé est une liste de points qui ont: 

- une coordonée (X, Y)
- un taux de pression (Z)
- un temps (millisecondes depuis le début du tracé)

Lesx tracés seront enregistrés dans un fichier CSV contenant ces informations pour chaque point.

Exemple:

```csv
36,27,43,2345
34,55,43,2455
55,23,42,2535
55,66,27,2645
```


## Planning

### 02.12.2015

- Présentation du sujet et planning
- Ouverture du git
- Réflexion sur la structure
- Esquisses de l'interface

### 09.12.2015

- création projet Visual Studio
- création interface
- classes de base pour la gestion des tracés
- classe générique pour la gestion des périphériques d'entrée

### 16.12.2015

- classe pour l'entrée à la souris
- interface d'enregistrement tracés

### 23.12.2015

- interface d'enregistrement tracés
- documentation du travail effectué
- classe pour Leapmotion

### 13.01.2016

- interface d'enregistrement des tracés
- interface de reproduction des tracés
- documentation

### 20.01.2016

- interface de reproduction des tracés
- classe pour tablette graphique
- classe pour leapmotion

### 27.01.2016

- interface de reproduction des tracés
- classe pour tablette graphique
- classe pour leapmotion

### 03.02.2016

- interface de reproduction des tracés
- classe pour tablette graphique
- classe pour souris 3D

### 10.02.2016

- classe pour souris 3D
- interface de reproduction des tracés
- documentation

### 24.02.2016

- classe pour souris 3D
- interface de reproduction des tracés
- documentation

### 02.03.2015

- documentation
- "gel" du code

### 09.03.2015

- documentation
- préparation présentation

### 16.03.2015

- mise en page et relecture de la documentation
- préparation présentation
- rendu du projet

### 23.03.2015

- présentation du projet