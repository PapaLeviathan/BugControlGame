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
            AnimateSkill();
            ActivateHitbox(1, 5f);
        }
        if (Input.GetButtonDown("Skill 2"))
        {
            AnimateSkill();
            ActivateHitbox(2, 5f);
        }
        if (Input.GetButtonDown("Skill 3"))
        {
            AnimateSkill();
            ActivateHitbox(1, 5f);
        }
        if (Input.GetButtonDown("Skill 4"))
        {
            AnimateSkill();
            ActivateHitbox(1, 5f);
        }
        if (Input.GetButtonDown("Skill 5"))
        {
            AnimateSkill();
            ActivateHitbox(1, 5f);
        }
    }

    private void ActivateHitbox(int hitBoxNumber, float duration)
    {
        var hitBoxIndex = hitBoxNumber - 1;
        _hitBoxArray[hitBoxIndex].Duration = duration;
    }

    private void AnimateSkill()
    {
        _animator.SetTrigger("Attack");
    }
}