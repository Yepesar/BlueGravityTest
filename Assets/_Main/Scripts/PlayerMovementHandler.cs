using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementHandler : MonoBehaviour
{
    public float movementSpeed = 2f;
    
    [SerializeField] private Rigidbody2D rb;

    public InputActionAsset actions;
    
    InputAction moveAction;
    Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        moveAction = actions.FindActionMap("Player").FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveInput.x, moveInput.y) * movementSpeed * Time.fixedDeltaTime;
        rb.velocity = movement;
    }
}