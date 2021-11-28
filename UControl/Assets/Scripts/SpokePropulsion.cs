using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PropulsionType
{
       AddForce,
       AddForceAtPosition,
       AddRelativeForce,
       AddRelativeTorque,
       AddTorque,
       ClosestPointOnBounds,
       GetPointVelocity,
       GetRelativePointVelocity,
       IsSleeping,
       MovePosition,
       MoveRotation,
       ResetCentreOfMass,
       ResetInertiaTensor,
       SetDensity,
       Sleep,
       SweepTest,
       SweepTestAll,
       WakeUp
}

public class SpokePropulsion : MonoBehaviour
{
    [SerializeField] private PropulsionType _propulsionType = PropulsionType.AddForce;
    [SerializeField] private Transform _propulsionPoint1;
    [SerializeField] private Transform _propulsionPoint2;
    [SerializeField] private Vector2 _force;
    [SerializeField] private float _torque;
    
    private Rigidbody2D _rigidbody;
    private RaycastHit2D[] _results;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ApplyPropulsion()
    {
        switch (_propulsionType)
        {
            case PropulsionType.AddForce:
                AddForce();
                break;
            case PropulsionType.AddForceAtPosition:
                AddForceAtPosition();
                break;
        }
    }

    private void AddForce()
    {
        _rigidbody.AddForce(_force);
    }

    private void AddForceAtPosition()
    {
        Debug.Log("Added force at position");
        _rigidbody.AddForceAtPosition(_force, _propulsionPoint1.position);
    }

    private void AddRelativeForce()
    {
        _rigidbody.AddRelativeForce(_force);
    }
    
    private void AddTorque()
    {
        _rigidbody.AddTorque(_torque);
    }
    
    private void Cast()
    {
        _rigidbody.Cast(_force, _results);
    }

    private void ClosestPoint()
    {
       Debug.Log(_rigidbody.ClosestPoint(transform.position));
    }
    
    private void Distance()
    {
        Debug.Log(_rigidbody.Distance(GetComponent<Collider2D>()));
    }

}
