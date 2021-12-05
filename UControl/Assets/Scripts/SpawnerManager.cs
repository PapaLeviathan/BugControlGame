using System;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    #region Singleton

    public static SpawnerManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public int MAXEnemyAmount = 10;
    public int CurrentEnemyAmount;

    private void Start()
    {
        ObjectPooler.Instance.OnEnemyAmountChanged += UpdateCurrentEnemyAmount;
    }

    private void UpdateCurrentEnemyAmount()
    {
        CurrentEnemyAmount = GetComponentsInChildren<IEnemy>().Length;
    }

}