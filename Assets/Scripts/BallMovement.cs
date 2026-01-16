using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int directionX;
    [SerializeField] int directionY;
    void Start()
    {
        
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
}