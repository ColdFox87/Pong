using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public int directionX;
    int directionY;

    void Start() => directionY = (Random.Range(0, 2) == 1) ? 1 : -1;
    void Update() => transform.Translate(moveSpeed * Time.deltaTime * new Vector3(directionX, directionY));

    void OnCollisionEnter2D(Collision2D collision)
    {
        string collisorTag = collision.gameObject.tag;

        if(collisorTag.Equals("Bound")) directionY *= -1;
        else if(collisorTag.Equals("Player")) directionX *= -1;

        GameEvents.BallHit();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal")) GameEvents.GoalScored(directionX > 0 ? 1 : 2);
    }
}