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
            Vector3 position = Vector3.zero;
            bool validPosition = false;
            int spawnAttempts = 0;
            
            while(!validPosition && spawnAttempts < maxSpawnAttempts)
            {
                spawnAttempts++;
                position = new Vector3(Random.Range(-2.2f, 2.2f), Random.Range(7, 21));
                validPosition = true;
                Collider2D[] colliders = Physics2D.OverlapCircleAll(position, obstacleRadius);
                foreach(Collider2D col in colliders)
                {
                    if (col.tag == "asteroid")
                    {
                        validPosition = false;
                    }
                }
                if (spawnAttempts == 10 && !validPosition)
                {
                    Debug.Log("Spawning in overlap");
                }
            }

            // Vector3 position = new Vector3(Random.Range(-2.2f, 2.2f), Random.Range(7, 21));
           
                Instantiate(asteroids[i], position, Quaternion.identity);

            


        }
    }
    
}
