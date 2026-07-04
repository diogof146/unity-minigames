using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace TurnBattle {

  public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject[] enemyPieces;
    public GameObject[] playerPieces;

    private int currentTurn;
    private string[] turnOrder;
    [HideInInspector]
    public bool playerTurn;

    private float distance;
    private float maxMovement = 8f;

    private bool inTurn;
    private Piece lastPiece;
    private Camera cam;

    private NavMeshAgent playerAgent;
    private bool hasPickedPlayer;

    [HideInInspector]
    public string winner;
    private int playerPoints;
    private int enemyPoints;

    public TMP_Text currentTurnText;
    public TMP_Text turnOrderText;
    public TMP_Text playerScoreText;
    public TMP_Text npcScoreText;

    void Awake() { instance = this; }


    void Start() {
      playerPoints = 0;
      enemyPoints = 0;
      winner = "";
      turnOrder = new string[6];
      GenerateTurnOrder();
      VerifyTurn();
      inTurn = false;
      cam = Camera.main;
    }

    void Update() {
      if (lastPiece == null || lastPiece.HasArrived()) { inTurn = false; }

      if (inTurn) { return; }

      UpdateUI();

      if (!playerTurn) { EnemyTurn(); }
      else {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
          Ray ray = cam.ScreenPointToRay(Input.mousePosition);
          RaycastHit hit;
          if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.CompareTag("Player")) {
              playerAgent = hit.collider.GetComponent<NavMeshAgent>();
              hasPickedPlayer = true;
            }
            else if (hit.collider.CompareTag("Floor") && hasPickedPlayer) {
              GameObject target = ChoosePieceToTrack(playerAgent.transform, enemyPieces);
              if (target == null) { return; }
              distance = Vector3.Distance(playerAgent.transform.position, hit.point);
              float targetDistance = Vector3.Distance(playerAgent.transform.position, target.transform.position);
              Vector3 movePosition;
              if (distance <= maxMovement) {
                movePosition = hit.point;
                playerAgent.SetDestination(movePosition);
              }
              else {
                Vector3 direction = hit.point - playerAgent.transform.position;
                direction = direction.normalized;
                movePosition = playerAgent.transform.position + (direction * maxMovement);
                playerAgent.SetDestination(movePosition);
              }
              if (targetDistance <= maxMovement) { playerAgent.GetComponent<Piece>().Attack(target); }

              lastPiece = playerAgent.GetComponent<Piece>();
              hasPickedPlayer = false;
              inTurn = true;
              ChangeTurn();
            }
          }
        }
      }
    }

    private NavMeshAgent EnemyChoice() {
      GameObject piece = null;
      int chosenPiece = Random.Range(0, enemyPieces.Length);
      while (piece == null) {
        chosenPiece = Random.Range(0, enemyPieces.Length);
        piece = enemyPieces[chosenPiece];
      }
      NavMeshAgent agent = enemyPieces[chosenPiece].GetComponent<NavMeshAgent>();
      return agent;
    }

    private void EnemyTurn() {
      inTurn = true;
      NavMeshAgent agent = EnemyChoice();
      lastPiece = agent.GetComponent<Piece>();
      GameObject piece = ChoosePieceToTrack(agent.transform, playerPieces);
      if (piece == null) { return; }
      Vector3 movePosition;
      if (distance <= maxMovement) {
        movePosition = piece.transform.position;
        agent.SetDestination(movePosition);
        agent.GetComponent<Piece>().Attack(piece);
      }
      else {
        Vector3 direction = piece.transform.position - agent.transform.position;
        direction = direction.normalized;
        movePosition = agent.transform.position + (maxMovement * direction);
        agent.SetDestination(movePosition);
      }
      ChangeTurn();
    }

    private GameObject ChoosePieceToTrack(Transform piece, GameObject[] options) {
      GameObject closest = null;
      distance = Mathf.Infinity;
      float newDistance;
      for (int i = 0; i < options.Length; i++) {
        if (options[i] != null) {
          newDistance = Vector3.Distance(piece.position, options[i].transform.position);
          if (newDistance <= distance) {
            closest = options[i];
            distance = newDistance;
          }
        }
      }
      return closest;
    }

    private void GenerateTurnOrder() {
      string[] tempOrder = { "P", "P", "P", "E", "E", "E" };
      int rand;

      for (int i = 0; i < tempOrder.Length; i++) {
        rand = Random.Range(i, tempOrder.Length);
        string temp = tempOrder[i];
        tempOrder[i] = tempOrder[rand];
        tempOrder[rand] = temp;
      }

      turnOrder = tempOrder;
    }

    private void VerifyTurn() {
      if (turnOrder[currentTurn] == "P") {
        playerTurn = true;
      }
      else {
        playerTurn = false;
      }
    }

    private void ChangeTurn() {
      currentTurn++;
      if (currentTurn >= 6) {
        currentTurn = 0;
      }
      VerifyTurn();
    }

    public void DestroyPiece(GameObject piece) {
      if (piece.CompareTag("Player")) {
        enemyPoints++;
        Destroy(piece);
        if (enemyPoints >= 3) {
          GameOver();
        }
      }
      else {
        playerPoints++;
        Destroy(piece);
        if (playerPoints >= 3) {
          GameOver();
        }
      }
    }

    private void GameOver() {
      if (playerPoints > enemyPoints) winner = "Player";
      else winner = "NPC";

      SceneManager.LoadScene("TurnBattleGameOver");
    }

    private void UpdateUI() {
      npcScoreText.text = "NPC Score: " + enemyPoints;
      playerScoreText.text = "Player Score: " + playerPoints;
      currentTurnText.text = playerTurn ? "Player Turn" : "NPC Turn";
      turnOrderText.text = "Turn Order: \n" + string.Join("-", turnOrder);
    }
  }
}
