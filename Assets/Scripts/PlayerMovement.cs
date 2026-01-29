using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(1, 2)] int player;
    [SerializeField] float moveSpeed;
    InputAction moveAction;
    Vector2 moveValue;
    Rigidbody2D rb;
    
    void OnEnable() => GameEvents.OnGameEnded += DisableMovement;
    void OnDisable() => GameEvents.OnGameEnded -= DisableMovement;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        moveAction = InputSystem.actions.FindActionMap("Player" + player).FindAction("Movement");
        moveAction.Enable();
    }

    void Update() => moveValue = moveAction.ReadValue<Vector2>();
    void FixedUpdate() => rb.linearVelocity = moveValue * moveSpeed;
    void DisableMovement(int _) => moveAction.Disable();
}