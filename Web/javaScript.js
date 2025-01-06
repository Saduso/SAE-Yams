// Charger les données JSON, ca c juste l'exemple du prof, jsp comment on met notre propre json
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

const display = document.getElementById("current-action");
const gauche = document.getElementById("fleche-gauche");
const droite = document.getElementById("fleche-droite");

let indexActu = 0; // Index actuel pour naviguer

// Fonction pour afficher l'action actuelle
function displayAction(index) {
    const roundIndex = Math.floor(index / 2); 
    const playerIndex = index % 2; // Détermine le joueur (0 pour le premier, 1 pour le second)

    const round = data.rounds[roundIndex];
    const player = data.players[playerIndex];
    const result = round.results.find(r => r.id_player === player.id);

    display.innerHTML = `
    <h2>Round ${round.id} - Player: ${player.pseudo}</h2>
    <p>Dice: ${result.dice.join(", ")}</p>
    <p>Challenge: ${result.challenge}</p>
    <p>Score: ${result.score}</p>
  `;
}

gauche.addEventListener("click", () => {
    if (indexActu > 0) {
        indexActu--;
        displayAction(indexActu);
    }
});

droite.addEventListener("click", () => {
    if (indexActu < data.rounds.length * 2 - 1) {
        indexActu++;
        displayAction(indexActu);
    }
});

displayAction(indexActu);
