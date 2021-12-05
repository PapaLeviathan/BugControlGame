using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] protected float _spawnDelay;

    protected WaitForSeconds _delay;
    protected bool _canSpawnEnemies = true;

    protected IEnumerator _spawnEnemies;

    #region Singleton

    public static EnemySpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    IEnumerator Start()
    {
        _delay = new WaitForSeconds(_spawnDelay);

        _spawnEnemies = SpawnEnemies();

        yield return new WaitForSeconds(.5f);
        
        StartCoroutine(_spawnEnemies);
    }


    protected virtual IEnumerator SpawnEnemies()
    {
        while (_canSpawnEnemies)
        {
            if (SpawnerManager.Instance.CurrentEnemyAmount >= SpawnerManager.Instance.MAXEnemyAmount)
                Debug.Log("Cannot spawn, too many enemies");

            yield return _delay;

            yield return new WaitUntil(() =>
                SpawnerManager.Instance.CurrentEnemyAmount < SpawnerManager.Instance.MAXEnemyAmount);


            ObjectPooler.Instance.SpawnFromRandomPool(transform.position, Quaternion.identity);
        }
    }
}