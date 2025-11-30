# 🎲 Projet Yams
Ce projet n'a pas été réalisé avec GitHub, la récupération de l'historique des versions n'est donc pas possible à cause de fichiers trop volumineux. 

## Description du jeu
## Comment jouer :

- Récuperation des fichiers sur machine local.
- Ouvrir le terminal.
- Se deplacer dans le dossier "C-sharp".
- Lancer la commande : ``dotnet run``.
- Jouer.
- Envoyer le json dans un api spécial (Résérvée aux étudiants).
- Ovrir le dossier "Web" dans un navigateur.
- Donner l'identifiant de la partie (obtenu grace à l'api).
- Visualiser la partie grace aux fleches..

---

## Équipe

Projet réalisé par trois étudiants dans le cadre du B.U.T. Informatique.
<br>
Durée du projet : 2 mois.

Le travail a été divisé en trois grandes missions :

  - ### Programmation du jeu en C#
→ Simulation complète d’une partie de Yams entre deux joueurs.

  - ### Gestion des données en JSON
→ Enregistrement du déroulement complet d’une partie (lancers, scores, vainqueur, etc.).

  - ### Interface Web
→ Visualisation du déroulement de la partie à partir des fichiers JSON, avec affichage du vainqueur.

---

## Technologies utilisées

- .NET C#

- JSON

- HTML / CSS / JavaScript

---

## Partie C# : Simulation du jeu

La partie C# permet de :

-Lancer une partie complète entre deux joueurs.

-Gérer les dés, les tours et le calcul des scores.

-Générer un fichier JSON retraçant le déroulement complet :

  -le numéro du tour,

  -les dés lancés,

  -les combinaisons choisies,

  -et le vainqueur.

Le projet a été réalisé sous C#.

![Debut_partie](Web/images/yams_start.png)
![Pendant_partie](Web/images/yams_while.png)
![Fin_Partie](Web/images/yams_win.png)

---
## Partie JSON : Exemple
  ``{
    "parameters": {
        "code": "groupe1-001",
        "date": "2025-37-30"
    },
    
    "players": [
        {
            "id": 1,
            "pseudo": "fella"
        },
        {
            "id": 2,
            "pseudo": "Guillaume"
        }
    ],
    "rounds": [{
    "id": 0,
    "results": [
        {
            "id_player": 1,
            "dice": [2, 5, 4, 3, 1],
            "challenge": "Petite Suite",
            "score": 30
        },
        {
            "id_player": 2,
            "dice": [2, 2, 4, 5, 3],
            "challenge": "Petite Suite",
            "score": 30
        }
    ]

---

## Partie Web : Visualisation du déroulement

L’interface Web utilise les fichiers JSON générés pour :

-Afficher les résultats de chaque lancer.

-Montrer les scores des joueurs au fil de la partie.

-Mettre en valeur le vainqueur à la fin du jeu.

Cette partie a été conçue avec HTML, CSS, et JavaScript.
![site_web](Web/images/yams.png)


---

## Résultat final

Une application complète permettant de :

-Simuler une partie de Yams entre deux joueurs.

-Sauvegarder automatiquement le déroulement.

-Visualiser ensuite la partie depuis le web avec le score final.
