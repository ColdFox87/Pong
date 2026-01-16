using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;
    [SerializeField] float moveSpeed;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        if(moveValue.y == 1)
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.up);
        }
        else if(moveValue.y == -1)
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.down);
        }
    }
}