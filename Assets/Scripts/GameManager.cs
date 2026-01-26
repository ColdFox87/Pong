using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject prefabBall;
    GameObject activeBall;
    int[] score;

    void OnEnable() => GameEvents.OnGoalScored += GoalHandler;
    void OnDisable() => GameEvents.OnGoalScored -= GoalHandler;
    void Start() => score = new int[] {0, 0};

    void GoalHandler(int player)
    {
        Destroy(activeBall);

        score[player - 1]++; // Player can be 1 or 2 but score array goes 0 to 1
        GameEvents.ScoreChanged(score);

        if(score[player - 1] == 3) GameEvents.GameEnded(player);
        else activeBall = SpawnNewBall(player == 1 ? 1 : -1);
    }

    GameObject SpawnNewBall(int directionX)
    {
        GameObject newBall = Instantiate(prefabBall, Vector3.zero, Quaternion.identity);
        newBall.GetComponent<BallMovement>().directionX = directionX;
        return newBall;
    }
}