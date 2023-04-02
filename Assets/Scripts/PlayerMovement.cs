using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    private Rigidbody2D rb;
    private InputControls inputControls;
    private InputAction movement, jump;
    [Header("Movement Settings")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpSpeed = 6f;
    private bool _inAir = false;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private static readonly int InAir = Animator.StringToHash("inAir");
    private static readonly int HorizontalMove = Animator.StringToHash("HorizontalMove");

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        inputControls = new InputControls();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (jump.WasPerformedThisFrame() && !_inAir)
        {
            //rb.AddForce(new Vector3(0, 1.0f, 0) * rb.mass * 1.6f, ForceMode2D.Impulse);
            rb.velocity = new Vector2(0, jumpSpeed * rb.gravityScale);
            _inAir = true;
            _animator.SetBool(InAir, _inAir);
        }
    }

    private void MovePlayer()
    {
        if (rb.velocity.y == 0)
        {
            _inAir = false;
            _animator.SetBool(InAir, _inAir);
        }
        var moveInput = movement.ReadValue<Vector2>();
        var direction = new Vector3(moveInput.x, 0f, 0f);
        var destination = direction * (speed * Time.deltaTime);
        _animator.SetFloat(HorizontalMove, Mathf.Abs(moveInput.x));
        _spriteRenderer.flipX = moveInput.x < 0;
        transform.Translate(destination);
    }
}
