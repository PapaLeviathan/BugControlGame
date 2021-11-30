using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private NavMeshAgent _agent;
    private Rigidbody2D _rigidbody;
    private Vector2 _movement;

    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _movement = new Vector2(_horizontal, _vertical);

        _rigidbody.velocity = _movement.normalized * _speed;

        _spriteRenderer.flipX = !(_horizontal <= -0.1f);
        
        if (_movement.magnitude > 0.1f)
        {
            _animator.SetBool("Running", true);
        }
        else
            _animator.SetBool("Running", false);

    }
}