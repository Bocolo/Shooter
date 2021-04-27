using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Spawning;

public class AsteroidsScript : MonoBehaviour
{

    [SerializeField] GameObject[] asteroids;
    [SerializeField] int maxSpawnAttempts = 10;
    [SerializeField] int obstacleRadius =3;

    
    private void Start()
    {
        SpawnAsteroid();
    }
 
    void SpawnAsteroid()
    {
        
        for (int i = 0; i < asteroids.Length; i++)
        {
            Vector2 position = Vector2.zero;
            bool validPosition = false;
            int spawnAttempts = 0;
            
            while(!validPosition && spawnAttempts < maxSpawnAttempts)
            {
                spawnAttempts++;

                position = AsteroidSpace.RandomPosition(2.4f, 7, 30);
              
                validPosition = AsteroidSpace.CheckOverlap(position, obstacleRadius);
            }
                Instantiate(asteroids[i], position, Quaternion.identity);
            }
    }
    
}
