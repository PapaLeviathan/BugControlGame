using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillInput : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private HitBox[] _hitBoxArray;

    private void Start()
    {
        _hitBoxArray = GetComponentsInChildren<HitBox>(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Skill 1"))
        {
            AnimateSkill(1);
            ActivateHitbox(1, 5f);
        }
        if (Input.GetButtonDown("Skill 2"))
        {
            AnimateSkill(2);
            ActivateHitbox(2, 5f);
        }
        if (Input.GetButtonDown("Skill 3"))
        {
            AnimateSkill(3);
            ActivateHitbox(3, 5f);
        }
        if (Input.GetButtonDown("Skill 4"))
        {
            AnimateSkill(4);
            ActivateHitbox(4, 5f);
        }
        if (Input.GetButtonDown("Skill 5"))
        {
            AnimateSkill(5);
            ActivateHitbox(5, 5f);
        }
    }

    private void ActivateHitbox(int hitBoxNumber, float duration)
    {
        var hitBoxIndex = hitBoxNumber - 1;
        _hitBoxArray[hitBoxIndex].Duration = duration;
    }

    private void AnimateSkill(int attackNumber)
    {
        //_animator.SetTrigger("Attack");
        _animator.CrossFade("Attack " + attackNumber, 0f);
    }
}