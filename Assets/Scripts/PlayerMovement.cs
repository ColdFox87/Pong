using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;
    [SerializeField] float moveSpeed;
    void Start()
    {
        moveAction = InputSystem.actions.FindActionMap(gameObject.name).FindAction("Movement");
        moveAction.Enable();
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

    public void ResetPositionY()
    {
        transform.position = new Vector3(transform.position.x, 0);
    }

    public void DisableAction(string action)
    {
        switch(action)
        {
            case "Movement":
                moveAction.Disable();
                break;
        }
    }

    public void EnableAction(string action)
    {
        switch(action)
        {
            case "Movement":
                moveAction.Enable();
                break;
        }
    }
}