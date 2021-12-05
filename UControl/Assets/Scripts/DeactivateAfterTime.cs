using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterTime : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(SetActiveState());
    }

    private IEnumerator SetActiveState()
    {
        yield return new WaitForSeconds(5f);
        
        ObjectPooler.Instance.InvokeEnemyAmountChanged();
        gameObject.SetActive(false);
    }
}
