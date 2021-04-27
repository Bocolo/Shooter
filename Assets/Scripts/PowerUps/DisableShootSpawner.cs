using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Spawning;
public class DisableShootSpawner : MonoBehaviour
{
   [SerializeField] GameObject shootDisabler;
    PowerUpSpawner powerUpSpawner;
    int targetScoreToDisable = 1;
    float timer;
    int waitForSecs = 2;
    int scoreIncreaser;
    private void Start()
    {
        timer = 0;
      
        scoreIncreaser = targetScoreToDisable;
        powerUpSpawner = GetComponent<PowerUpSpawner>();
    }
    private void Update()
    {
        if(powerUpSpawner.powerUpSpawnCount > targetScoreToDisable)
        {
            
            timer += Time.deltaTime;
            if (timer > waitForSecs)
            {
                SpawnDisabler();
                SpawnDisabler();
                timer = 0;
                targetScoreToDisable += scoreIncreaser;
            }
        }
    
    }
    void SpawnDisabler()
    {
        Vector2 position = AsteroidSpace.RandomPosition(2.2f, 5, 25);
        Instantiate(shootDisabler, position, Quaternion.identity);
    }
}
