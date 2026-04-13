Ce projet est mon tout premier code réalisé en Programmation Orientée Objet (POO).

# Morpion (Tic-Tac-Toe) - C# Console

## Note de l'auteur
> **Ce projet est mon tout premier code réalisé en Programmation Orientée Objet (POO).**
>
> Il a été conçu et structuré de A à Z par mes soins pour valider ma transition du langage Pascal vers le C#. L'intégralité de la logique de jeu, de l'architecture des classes et de la gestion des références a été **développée sans l'aide d'IA générative (ou presque)**, afin de garantir une compréhension réelle des mécanismes de la POO et du fonctionnement du framework .NET.

---

## Présentation
Un jeu de Morpion classique développé en **C#**. Ce projet marque le passage d'une programmation procédurale (Pascal) à une approche orientée objet, avec une séparation claire des responsabilités.

## Le Défi : Passer du Pascal au C#
L'objectif principal était de migrer ma logique de réflexion habituelle vers les concepts fondamentaux de la POO :
* **Migration de logique** : Passer des procédures globales aux méthodes de classes.
* **Gestion de la mémoire** : Comprendre la différence entre le passage par valeur (copie) et le passage par référence (`ref`).
* **Architecture** : Faire communiquer des objets entre eux (ex: la classe `Joueur` qui interagit avec la classe `Plateau`) sans créer de dépendances infinies.

## Fonctionnalités
* **Mode 2 Joueurs** : Jouez en local avec une alternance automatique.
* **Objet "Tour" (T)** : Utilisation d'un objet pivot pour gérer le joueur actuel de manière dynamique.
* **Logique de Victoire** : Algorithme de détection (lignes, colonnes, diagonales).
* **Sécurisation** : Vérification des cases déjà occupées et validation des saisies.

## Comment jouer ?

1.  Clonez le dépôt :
    ```bash
    git clone [https://github.com/TON_PSEUDO/Morpion-CS.git](https://github.com/TON_PSEUDO/Morpion-CS.git)
    ```
2.  Ouvrez le projet dans **Visual Studio**.
3.  Lancez l'application (`F5`).
4.  Utilisez les chiffres de **1 à 9** pour placer votre pion :
    ```
     1 | 2 | 3 
    -----------
     4 | 5 | 6 
    -----------
     7 | 8 | 9 
    ```

## Structure du Projet
* `Plateau.cs` : Gère la grille 3x3, l'affichage et les conditions de victoire.
* `Joueur.cs` : Définit les propriétés des joueurs et la logique de placement des pions.
* `Program.cs` : Point d'entrée gérant le menu principal et le lancement des parties.

---
Projet réalisé avec rigueur pour poser les bases de mon futur en développement C#.
