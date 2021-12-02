using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private string _enemyTypeToSpawn = "Green Enemy";
    private int _amountToSpawn;

    private WaitForSeconds _delay;

    void Start()
    {
        _delay = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnEnemmies());
    }

    private IEnumerator SpawnEnemmies()
    {
        while (_amountToSpawn < 10)
        {
            ObjectPooler.Instance.SpawnFromPool(_enemyTypeToSpawn, transform.position, Quaternion.identity);
            _amountToSpawn++;
            yield return _delay;
        }
    }
}
