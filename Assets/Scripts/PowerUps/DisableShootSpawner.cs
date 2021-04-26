using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //targetScoreToDisable ;
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
      /*  if (powerUpSpawner.powerUpSpawnCount ==1)
        {
            Debug.Log(powerUpSpawner.powerUpSpawnCount);
        }*/
    }
    void SpawnDisabler()
    {
        Vector2 position = new Vector2(Random.Range(-2.2f, 2.2f), Random.Range(5,11));
        Instantiate(shootDisabler, position, Quaternion.identity);
    }
}
