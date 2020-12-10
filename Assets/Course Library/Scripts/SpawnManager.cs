using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    int index;
    Vector3 spawnPos = new Vector3(25, 0, 0);
    float repeatRate;
    WaitForSeconds repeater;
    // Start is called before the first frame update
    void Start()
    {
        repeatRate = Random.Range(1.8f, 3.5f);
        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        repeater = new WaitForSeconds(repeatRate);
        StartCoroutine(SpawnObstacles());
        GameManager.Instance.resetEvent.AddListener(Restart);
    }
       void SpawnObstacle(int index)
    {
         Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);
  
    }
    IEnumerator SpawnObstacles()
    {
        while (!GameManager.Instance.gameOver)
        {
            index = Random.Range(0, obstaclePrefab.Length);
            SpawnObstacle(index);
            yield return repeater;
        }
       
    }
    void Restart()
    {
        StopAllCoroutines();
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }

    }
}
