using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    int scoreP1, scoreP2;
    [SerializeField] TMP_Text txtScoreP1, txtScoreP2;
    void Start()
    {
        scoreP1 = scoreP2 = 0;
    }

    public void Goal(GameObject activeBall, int directionX)
    {
        Destroy(activeBall);

        UpdateScore((directionX > 0) ? 1 : 2);

        GameObject newBall = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        // Player who conceded the goal starts next.
        newBall.GetComponent<BallMovement>().directionX = directionX;
    }

    void UpdateScore(int player)
    {
        if(player == 1) txtScoreP1.text = (++scoreP1).ToString();
        else txtScoreP2.text = (++scoreP2).ToString();
    }
}