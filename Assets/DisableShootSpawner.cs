using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableShootSpawner : MonoBehaviour
{
   [SerializeField] GameObject shootDisabler;
    PowerUpSpawner powerUpSpawner;
    int targetScoreToDisable;
    float timer;
    int waitForSecs = 2;
    private void Start()
    {
        timer = 0;
        targetScoreToDisable = 1;
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
                targetScoreToDisable += targetScoreToDisable;
            }
        }
      /*  if (powerUpSpawner.powerUpSpawnCount ==1)
        {
            Debug.Log(powerUpSpawner.powerUpSpawnCount);
        }*/
    }
    void SpawnDisabler()
    {
        Vector2 position = new Vector2(Random.Range(-2.2f, 2.2f), Random.Range(5,7));
        Instantiate(shootDisabler, position, Quaternion.identity);
    }
}
