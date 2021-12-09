using System;
using UnityEngine;

public class HitBox1 : HitBox
{
    [SerializeField] private int _layerMask;
    private int _bitMask;

    private void Start()
    {
        _bitMask = ((1 << 8));
        //Debug.Log(Convert.ToString(_bitMask, 2).PadLeft(32, '0'));
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.layer != 1 << 8) return;
        Debug.Log(Convert.ToString(other.gameObject.layer << 1, 2).PadLeft(32, '0'));
        Vector2 direction = other.gameObject.transform.position - transform.root.position;
        Vector2 forceAndDirection = new Vector2(direction.x * _force, direction.y * _force);
        //Debug.Log(forceAndDirection);
        other.GetComponent<Rigidbody2D>().AddForce(forceAndDirection);
    }
}