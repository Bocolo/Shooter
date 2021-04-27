using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Spawning;
using Shooter.Player;


public class AsteroidObjScript : MonoBehaviour
{
    [SerializeField]int fallY= -6;
    [SerializeField] float maxSpawnY = 30;
    [SerializeField] float minSpawnY = 6;
    [SerializeField] float spawnX = 2.4f;
    [SerializeField] float fallSpeedX;
    [SerializeField] float fallSpeedY;
    float fallSpeed;    
    [SerializeField] float bigDeg;
    [SerializeField] float littleDeg;
    float rotationDeg;
    [SerializeField] int scoreForDestruction=1;
    [SerializeField] int health;
    [SerializeField] int maxSpawnAttempts = 10;
    [SerializeField] int obstacleRadius = 130;
    [SerializeField] ScoreTracker scoreTracker ;    
    [SerializeField] GameObject smallAsteroid;
    [SerializeField] GameObject mediumAsteroid;
    [SerializeField] GameObject largeAsteroid;
    [SerializeField] GameObject hugeAsteroid;
    [SerializeField] GameObject activeAsteroid;    
    [SerializeField] bool isChangeable;
    [SerializeField] bool getsBigger;
    bool hasExploded = false;
    int healthReset;
    private void Start()
    {
     
        healthReset = health;
        fallSpeed = Random.Range(fallSpeedX,fallSpeedY);
        if (Random.value < 0.5f)
        {
            rotationDeg = Random.Range(-bigDeg, -littleDeg);
        }
        else
        {
            rotationDeg= Random.Range(littleDeg, bigDeg);
        }

    }


   
    void LateUpdate()
    {
        if (isChangeable && !getsBigger)
        {
            if (health < 30  && hugeAsteroid.activeSelf)
            {
                ActivateAsteroid(largeAsteroid, hugeAsteroid);
         
            }

            if (health < 21  && largeAsteroid.activeSelf)
            {
                ActivateAsteroid(mediumAsteroid, largeAsteroid);
             }
            if (health < 11  && mediumAsteroid.activeSelf)
            {

                ActivateAsteroid(smallAsteroid, mediumAsteroid);
            }
        }
        if (getsBigger)
        {
            if (health < 11 && smallAsteroid.activeSelf)
            {
                ActivateAsteroid(mediumAsteroid, smallAsteroid);
            }

        
        }
        if (health <= 0)
        {
            if (isChangeable)
            {
                smallAsteroid.SetActive(false);
            }
           
            GameManager.instance.score += scoreForDestruction;
            hasExploded = true;
          
            
        }
        
        transform.Rotate(0, 0, rotationDeg * Time.deltaTime);
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime, Space.World);
        if(transform.position.y < fallY || hasExploded)
        {
            smallAsteroid.SetActive(false);
            mediumAsteroid.SetActive(false);
            largeAsteroid.SetActive(false);
            hugeAsteroid.SetActive(false);
          
            hasExploded = false;
           
            Vector2 position = Vector2.zero;
            bool validPosition = false;
            int spawnAttempts = 0;

            while (!validPosition && spawnAttempts < maxSpawnAttempts)
            {
                spawnAttempts++;
                position = AsteroidSpace.RandomPosition(spawnX,minSpawnY,maxSpawnY);
                validPosition = AsteroidSpace.CheckOverlap(position,obstacleRadius);
            }
             transform.position = position;
             activeAsteroid.SetActive(true);
             health = healthReset;
             fallSpeed = Random.Range(fallSpeedX, fallSpeedY);
        }
        if (Player.isDead)
        {
            gameObject.SetActive(false);
        }
    }
    void ActivateAsteroid(GameObject ObjToActivate, GameObject ObjToDeactive)
    {
        ObjToActivate.SetActive(true);
        ObjToDeactive.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            int damage = collision.gameObject.GetComponent<Projectile>().projectileDamage;
            health -= damage;
       
           
        }
       
    }
}

