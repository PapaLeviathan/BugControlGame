using System;
using UnityEngine;

public class HitBox1 : HitBox
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 direction = other.gameObject.transform.position - transform.root.position;
        Vector2 forceAndDirection = new Vector2(direction.x * _force, direction.y * _force);
        Debug.Log(forceAndDirection);
        other.GetComponent<Rigidbody2D>().AddForce(forceAndDirection);
    }
}