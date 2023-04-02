using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Activated = Animator.StringToHash("Activated");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        _animator.SetTrigger(Activated);
        GameManager.instance.SetNewCheckpoint(transform.position);
    }
}
