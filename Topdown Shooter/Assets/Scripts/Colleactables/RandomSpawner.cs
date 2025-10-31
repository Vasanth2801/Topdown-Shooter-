using System.Collections;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject collectables;
    public Transform[] spawnPoints;
    public float duration = 2f;

    void Start()
    {
        StartCoroutine(SpawnCollectable());
    }


    IEnumerator SpawnCollectable()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(collectables, spawnPoints[randomIndex].position, Quaternion.identity);
        yield return new WaitForSeconds(duration);
    }
}
