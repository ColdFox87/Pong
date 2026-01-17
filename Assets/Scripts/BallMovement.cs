using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] float moveSpeed;
    public int directionX;
    [SerializeField] int directionY;
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        directionY = (Random.Range(0, 2) == 1) ? 1 : -1;
    }

    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * new Vector3(directionX, directionY));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bound")) directionY *= -1;
        else if(collision.gameObject.CompareTag("Player")) directionX *= -1;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            gameManager.Goal(gameObject, directionX);
        }
    }
}