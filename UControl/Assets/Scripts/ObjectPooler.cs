using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
        public Transform SpawnPoint;
    }

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public event Action OnEnemyAmountChanged;

    public List<Pool> _pools;

    public Dictionary<string, Queue<GameObject>> _poolDictionary;

    public int[] _table =
    {
        40,
        30,
        20,
        10
    };

    public int _total;
    public int _randomNumber;
    
    private Transform _currentSpawnPoint;

    private void Start()
    {
        foreach (var item in _table)
        {
            //Loop through the table and add each of the ints of the table together
            _total += item;
        }
        
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in _pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.transform.SetParent(transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            _poolDictionary.Add(pool.Tag, objectPool);
        }

        InvokeEnemyAmountChanged();

    }

    private string SelectRandomEnemyPool()
    {
        _randomNumber = UnityEngine.Random.Range(0, _total);
        
        for (int i = 0; i < _table.Length; i++)
        {
            if (_randomNumber <= _table[i])
            {
                //select enemy
                _currentSpawnPoint = _pools[i].SpawnPoint;
                return _pools[i].Tag;
            }
            else
            {
                _randomNumber -= _table[i];
            }
        }

        return null;
    }
    
    public GameObject SpawnFromRandomPool(Quaternion rotation)
    {
        var tag = SelectRandomEnemyPool();
        
        if (!_poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }

        GameObject objectToSpawn = _poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = _currentSpawnPoint.position;
        objectToSpawn.transform.rotation = rotation;
        
        _poolDictionary[tag].Enqueue(objectToSpawn);

        InvokeEnemyAmountChanged();

        return objectToSpawn;
    }
    
    public void InvokeEnemyAmountChanged()
    {
        OnEnemyAmountChanged?.Invoke();
    }
    
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }

        GameObject objectToSpawn = _poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        _poolDictionary[tag].Enqueue(objectToSpawn);

        InvokeEnemyAmountChanged();

        return objectToSpawn;
    }
}