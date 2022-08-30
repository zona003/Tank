using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    List<GameObject> spawnPoints;

    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    float spawnTime;


    private void Start()
    {
        DetectSpawn();
        StartCoroutine("SpawnCoroutine");
    }

    void Spawn(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab, spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, Quaternion.identity);
    }

    void DetectSpawn()
    {
        spawnPoints.Clear();
        int count = transform.GetSiblingIndex();
        for (int i = 0; i < count; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            spawnPoints.Add(child);
        }
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Spawn(enemyPrefab);
            yield return new WaitForSeconds(spawnTime);
        }
        
    }

    public void PlayerDead()
    {
        StartCoroutine("SpawnPlayer");
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(1);
        Spawn(playerPrefab);
    }
}
