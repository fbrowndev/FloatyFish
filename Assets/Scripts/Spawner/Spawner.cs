using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Spawner Variables
    [Header("Spawner Settings")]
    [SerializeField] private GameObject[] _colorStrips;
    [SerializeField] private float _spawnTime = 3f;


    private bool _stopSpawning = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnColorStripsRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnGameObstacles()
    {
        GameObject[] _spawnGroup = _colorStrips;
        Vector3 _spawnPos = transform.position;
        int _randSpawn = Random.Range(0, _spawnGroup.Length);
        Instantiate(_spawnGroup[_randSpawn], _spawnPos, Quaternion.identity);
    }

    #region Spawn Routines

    IEnumerator SpawnColorStripsRoutine()
    {
        yield return new WaitForSeconds(4f);
        while(_stopSpawning == false) 
        {
            SpawnGameObstacles();
            yield return new WaitForSeconds(_spawnTime);
        }
    }


    #endregion


    void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
