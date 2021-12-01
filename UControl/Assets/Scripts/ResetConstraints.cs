using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetConstraints : MonoBehaviour
{
  private Rigidbody2D _rigidbody;

  private void Start()
  {
    _rigidbody = GetComponent<Rigidbody2D>();
  }

  public void ResetZConstraint()
  {
    StartCoroutine(Reset());
  }

  private IEnumerator Reset()
  {
    yield return new WaitForSeconds(3f);
    _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    
  }
}
