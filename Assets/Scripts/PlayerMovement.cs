using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private InputControls inputControls;
    private InputAction movement, jump;
    [SerializeField] private float speed = 3f;
    private float jumpSpeed = 6f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputControls = new InputControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        //enabling player movement/jumping
        movement = inputControls.Player.Movement;
        movement.Enable();

        jump = inputControls.Player.Jump;
        jump.Enable();
    }

    private void OnDisable()
    {
        //disabling player movement/jumping
        movement.Disable();
        jump.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpPlayer();
    }

    private void JumpPlayer()
    {
        if (jump.WasPerformedThisFrame())
        {
            //rb.AddForce(new Vector3(0, 1.0f, 0) * rb.mass * 1.6f, ForceMode2D.Impulse);
            rb.velocity = new Vector2(0, jumpSpeed * rb.gravityScale);
        }
    }

    private void MovePlayer()
    {
        var moveInput = movement.ReadValue<Vector2>();
        var direction = new Vector3(moveInput.x, 0f, 0f);
        var destination = direction * speed * Time.deltaTime;
        transform.Translate(destination);
    }


}
