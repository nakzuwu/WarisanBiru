using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{
    Vector2 movement;
    Vector2 keyboardInput;
    public VariableJoystick variableJoystick;
    public float speed =15;
    private Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        InputMovement();
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        keyboardInput = context.ReadValue<Vector2>().normalized;
        
        
    }

    private void InputMovement()
    {
        Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;
        movement = direction != Vector2.zero? direction.normalized : keyboardInput;
        if (movement != Vector2.zero)
        {
            animator.SetBool("ismove", true);
            animator.SetFloat("movex", movement.x);
            animator.SetFloat("movey", movement.y);
        }
        else
        {
            animator.SetBool("ismove", false);
        }
        Vector2 targetVelocity = new Vector2(movement.x * speed, movement.y * speed);
        rb.velocity = targetVelocity;
    }
    
}
