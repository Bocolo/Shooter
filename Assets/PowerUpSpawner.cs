using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
   [SerializeField] GameObject shooterSwitcher;
    [SerializeField] ScoreTracker scoreTracker;

    int targetScore;

    private void Start()
    {
        targetScore = 50;
        Debug.Log("Score tracker score in spawner is: " + scoreTracker.score);
    }
    private void Update()
    {
        if (scoreTracker.score >= targetScore)
        {
            Debug.Log("Score tracker score is greater than target: " + scoreTracker.score);
            targetScore += 50;
            SpawnPowerUp();
        }
    }
    void SpawnPowerUp()
    {
        Debug.Log("Spawning powerUp");
        Vector3 position = new Vector3(Random.Range(-2.2f, 2.2f),7);
        Instantiate(shooterSwitcher, position, Quaternion.identity );
    }


}
