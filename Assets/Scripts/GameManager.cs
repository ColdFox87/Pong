using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Goal(GameObject activeBall, int directionX)
    {
        Destroy(activeBall);

        GameObject newBall = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        // Player who conceded the goal starts next.
        newBall.GetComponent<BallMovement>().directionX = directionX;
    }
}
