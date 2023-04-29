using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipePrefab;

    private float spawnRateTime = 2f;

    private void Update()
    {
        spawnRateTime-= Time.deltaTime;
        if (spawnRateTime < 0)
        {
            SpawnPipe();
            spawnRateTime = GameManager.instance.data.rateTime;
        }
    }

    private void SpawnPipe()
    {
        Instantiate(pipePrefab, transform.position, Quaternion.identity);
    }
}
