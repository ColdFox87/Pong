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
}
