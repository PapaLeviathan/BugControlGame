using UnityEngine;

public class HitBox4 : HitBox
{
    [SerializeField] protected float _torque;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().AddTorque(_torque);
        other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        other.GetComponent<ResetConstraints>().ResetZConstraint();
    }
}