using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
   [SerializeField] GameObject shooterSwitcher;
    [SerializeField] GameObject largerShooter;
    [SerializeField] ScoreTracker scoreTracker;


    int targetScoreSwitcher;
    int targetScoreLarger;
    public int powerUpSpawnCount;

    private void Start()
    {
        powerUpSpawnCount = 0;
        targetScoreSwitcher = 40;
        targetScoreLarger = 54;
      //  Debug.Log("Score tracker score in spawner is: " + scoreTracker.score);
    }
    private void Update()
    {
        if (scoreTracker.score >= targetScoreSwitcher)
        {
         //   Debug.Log("Score tracker score is greater than target: " + scoreTracker.score);
            targetScoreSwitcher += targetScoreSwitcher;
            SpawnPowerUp(shooterSwitcher);
            powerUpSpawnCount++;
        }
        if (scoreTracker.score >= targetScoreLarger)
        {
        //    Debug.Log("Score tracker score is greater than target: " + scoreTracker.score);
            targetScoreLarger += targetScoreLarger;
            SpawnPowerUp(largerShooter);
            powerUpSpawnCount++;
        }
    }
    void SpawnPowerUp(GameObject powerUp)
    {
    //    Debug.Log("Spawning powerUp: "+powerUp);
        Vector2 position = new Vector2(Random.Range(-2.2f, 2.2f),7);
        Instantiate(powerUp, position, Quaternion.identity );
    }


}
