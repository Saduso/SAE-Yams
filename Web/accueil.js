const data = JSON.parse(`{
  "parameters": {
    "code": "groupe1-001",
    "date": "2024-09-28"
  },
  "players": [
    { "id": 1, "pseudo": "Magi" },
    { "id": 2, "pseudo": "Tare" }
  ],
  "rounds": [
    {
      "id": 1,
      "results": [
        { "id_player": 1, "dice": [5, 5, 6, 5, 6], "challenge": "full", "score": 25 },
        { "id_player": 2, "dice": [1, 2, 1, 2, 2], "challenge": "full", "score": 25 }
      ]
    },
    {
      "id": 2,
      "results": [
        { "id_player": 1, "dice": [4, 4, 4, 5, 1], "challenge": "nombre4", "score": 12 },
        { "id_player": 2, "dice": [4, 6, 4, 5, 4], "challenge": "nombre4", "score": 12 }
      ]
    }
  ],
  "final_result": [
    { "id_player": 1, "bonus": 0, "score": 175 },
    { "id_player": 2, "bonus": 35, "score": 255 }
  ]
}`);

// Sélection des éléments
const vainqueurElem = document.getElementById("vainqueur");
const scoreFinalElem = document.getElementById("score-final");
const joueursElem = document.getElementById("joueurs");

// Trouver le score : on compare les deux scores
const winner = data.final_result.reduce((max, player) => player.score > max.score ? player : max, data.final_result[0]);

// qui est le vainqueur?
const winnerPlayer = data.players.find(player => player.id === winner.id_player);

// Liste des joueurs
const allPlayers = data.players.map(player => `${player.pseudo} (ID: ${player.id})`).join(", ");

// afficher sur la page
vainqueurElem.textContent = `  ${winnerPlayer.pseudo}`;
scoreFinalElem.textContent = `  ${winner.score}`;
joueursElem.textContent = `  ${allPlayers}`;
