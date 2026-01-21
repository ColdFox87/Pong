using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static readonly WaitForSeconds _waitForSeconds3 = new(3);
    [SerializeField] GameObject ballPrefab;
    [SerializeField] PlayerMovement playerMovement1;
    [SerializeField] PlayerMovement playerMovement2;

    // Score Things
    int scoreP1, scoreP2;
    [SerializeField] TMP_Text txtScoreP1, txtScoreP2;
    [SerializeField] int scoreLimit;

    // Game Over Things
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TMP_Text txtWinner;

    void Start()
    {
        scoreP1 = scoreP2 = 0;
    }

    public void Goal(GameObject activeBall, int directionX)
    {
        Destroy(activeBall);

        UpdateScore((directionX > 0) ? 1 : 2);

        if(scoreP1 == scoreLimit || scoreP2 == scoreLimit) StartCoroutine(GameOver());
        else InstantiateNewBall(directionX);
    }

    void UpdateScore(int player)
    {
        if(player == 1) txtScoreP1.text = (++scoreP1).ToString();
        else txtScoreP2.text = (++scoreP2).ToString();
    }

    void InstantiateNewBall(int directionX)
    {
        GameObject newBall = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        // Player who conceded the goal starts next.
        newBall.GetComponent<BallMovement>().directionX = directionX;
    }

    IEnumerator GameOver()
    {
        txtWinner.text = (scoreP1 > scoreP2) ? "P1 WINS" : "P2 WINS";
        gameOverScreen.SetActive(true);

        playerMovement1.DisableAction("Movement");
        playerMovement2.DisableAction("Movement");

        yield return _waitForSeconds3;

        RestartGame();
    }

    void RestartGame()
    {
        scoreP1 = scoreP2 = 0;
        txtScoreP1.text = txtScoreP2.text = "0";

        gameOverScreen.SetActive(false);

        playerMovement1.ResetPositionY();
        playerMovement2.ResetPositionY();

        playerMovement1.EnableAction("Movement");
        playerMovement2.EnableAction("Movement");
        InstantiateNewBall(-1);
    }
}