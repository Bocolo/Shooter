using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsScript : MonoBehaviour
{

    public GameObject[] asteroids;
    private void Start()
    {
        SpawnAsteroid();
    }
    void SpawnAsteroid()
    {
        
        for (int i = 0; i < asteroids.Length; i++)
        {
            Vector3 position = new Vector3(Random.Range(-2.2f, 2.2f), 6, 0);
            Instantiate(asteroids[i], position, Quaternion.identity);
        }
    }
}
