using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float maxYPos;
    public float spawnTime;
    public GameObject pipe;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawningPipes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopSpawningPipes()
    {
        CancelInvoke("SpawnPipes");
    }
    public void StartSpawningPipes()
    {
        InvokeRepeating("SpawnPipe", 0.2f, spawnTime);
    }
    private void SpawnPipe()
    {
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(-maxYPos, maxYPos), 0), Quaternion.identity);
    }
}
