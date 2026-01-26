using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(1, 2)] int player;
    [SerializeField] float moveSpeed;
    InputAction moveAction;

    void OnEnable() => GameEvents.OnGameEnded += DisableMovement;
    void OnDisable() => GameEvents.OnGameEnded -= DisableMovement;

    void Start()
    {
        moveAction = InputSystem.actions.FindActionMap("Player" + player).FindAction("Movement");
        moveAction.Enable();
    }

    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        if(moveValue != Vector2.zero) transform.Translate(moveSpeed * Time.deltaTime * new Vector3(0, moveValue.y));
    }

    void DisableMovement(int _) => moveAction.Disable();
}