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
     
    }
    private void Update()
    {
        if (GameManager.instance.score >= targetScoreSwitcher)
        {
       
            targetScoreSwitcher += targetScoreSwitcher;
            SpawnPowerUp(shooterSwitcher);
            powerUpSpawnCount++;
        }
        if (GameManager.instance.score >= targetScoreLarger)
        {
      
            targetScoreLarger += targetScoreLarger;
            SpawnPowerUp(largerShooter);
            powerUpSpawnCount++;
        }
    }
    void SpawnPowerUp(GameObject powerUp)
    {

        Vector2 position = new Vector2(Random.Range(-2.2f, 2.2f),7);
        Instantiate(powerUp, position, Quaternion.identity );
    }


}
