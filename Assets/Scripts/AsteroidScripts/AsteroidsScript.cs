using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsScript : MonoBehaviour
{

    public GameObject[] asteroids;
    public int maxSpawnAttempts = 10;
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
             
                position = new Vector2(Random.Range(-2.2f, 2.2f), Random.Range(7, 30));
                validPosition = true;
                Collider2D[] colliders = Physics2D.OverlapCircleAll(position, obstacleRadius);
                foreach(Collider2D col in colliders)
                {
                    if (col.tag == "asteroid")
                    {

                        validPosition = false;
                    }
                }
             
            }

            
                Instantiate(asteroids[i], position, Quaternion.identity);

            


        }
    }
    
}
