using System.Collections;
using UnityEngine;

public class SkyBlueEnemySpawner : EnemySpawner
{
    [SerializeField] protected string _enemyTypeToSpawn = "Sky Blue Enemy";

    protected override IEnumerator SpawnEnemies()
    {
        while (_canSpawnEnemies)
        {
            if (SpawnerManager.Instance.CurrentEnemyAmount >= SpawnerManager.Instance.MAXEnemyAmount)
                Debug.Log("Cannot spawn, too many enemies");

            yield return _delay;

            yield return new WaitUntil(() =>
                SpawnerManager.Instance.CurrentEnemyAmount < SpawnerManager.Instance.MAXEnemyAmount);


            ObjectPooler.Instance.SpawnFromPool(_enemyTypeToSpawn, transform.position, Quaternion.identity);
        }
    }
}