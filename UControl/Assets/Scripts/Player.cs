using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    
    private NavMeshAgent _agent;
    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    
    
    private float _horizontal;
    private float _vertical;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _movement = new Vector2(_horizontal, _vertical);

        _rigidbody.velocity = _movement.normalized * _speed;

    }
}
