using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidObjScript : MonoBehaviour
{
    [SerializeField]int fallY= -6;
    float fallSpeed;
    public float fallSpeedX;
    public float fallSpeedY;
    public float rotationDeg;
    public float bigDeg;
    public float littleDeg;
    int healthReset;
    bool hasExploded =false;
    [SerializeField] int scoreForDestruction; 
    [SerializeField] ScoreTracker scoreTracker ;
    [SerializeField] int health;
    [SerializeField] GameObject smallAsteroid;
    [SerializeField] GameObject mediumAsteroid;
    [SerializeField] GameObject largeAsteroid;
    [SerializeField] GameObject hugeAsteroid;
    [SerializeField] GameObject activeAsteroid;
    [SerializeField] int maxSpawnAttempts = 10;
    [SerializeField] int obstacleRadius = 130;
    [SerializeField] bool isChangeable;
  //  GameObject currentAsteroid;
    private void Start()
    {
      //  gameObject.SetActive(true);
        healthReset = health;
        //fallY ;
        fallSpeed = Random.Range(fallSpeedX,fallSpeedY);
        if (Random.value < 0.5f)
        {
            rotationDeg = Random.Range(-bigDeg, -littleDeg);
        }
        else
        {
            rotationDeg= Random.Range(littleDeg, bigDeg);
        }
        //scoreTracker = new ScoreTracker();
    }

    
    void LateUpdate()
    {
        if (isChangeable)
        {
            if (health < 30 && largeAsteroid != null && hugeAsteroid.activeSelf)
            {
                largeAsteroid.SetActive(true);
                hugeAsteroid.SetActive(false);

            }

            if (health < 21 && mediumAsteroid != null && largeAsteroid.activeSelf)
            {
                mediumAsteroid.SetActive(true);
                largeAsteroid.SetActive(false);

            }
            if (health < 11 && smallAsteroid != null && mediumAsteroid.activeSelf)
            {
                smallAsteroid.SetActive(true);
                mediumAsteroid.SetActive(false);

            }
        }
        if (health <= 0)
        {
            if (isChangeable)
            {
                smallAsteroid.SetActive(false);
            }
            hasExploded = true;
            scoreTracker.score += scoreForDestruction;
        }
        
        transform.Rotate(0, 0, rotationDeg * Time.deltaTime);
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        if(transform.position.y < fallY || hasExploded)
        {
            //sprite renderers were not deactivating every time - Update
            smallAsteroid.SetActive(false);
            mediumAsteroid.SetActive(false);
            largeAsteroid.SetActive(false);
            hugeAsteroid.SetActive(false);
            // gameObject.SetActive(true);
            hasExploded = false;
           
            Vector3 position = Vector3.zero;
            bool validPosition = false;
            int spawnAttempts = 0;

            while (!validPosition && spawnAttempts < maxSpawnAttempts)
            {
                spawnAttempts++;
                position = new Vector3(Random.Range(-2.2f, 2.2f), Random.Range(6, 20));
                validPosition = true;

                Collider2D[] colliders = Physics2D.OverlapCircleAll(position, obstacleRadius);
               // Debug.Log("Spawn attempt:  - "+spawnAttempts+" . . . " + gameObject.name);
                foreach (Collider2D col in colliders)
                {
                   // Debug.Log("Collison detected - - > " + col);
                    if (col.tag == "asteroid")
                    {
                        validPosition = false;
                    //    Debug.Log("overLap detected");
                    }
                }
            }

          
                transform.position = position;
                activeAsteroid.SetActive(true);
            
           
            health = healthReset;

            fallSpeed = Random.Range(fallSpeedX, fallSpeedY);


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            int damage = collision.gameObject.GetComponent<Projectile>().projectileDamage;
            health -= damage;
        //    Debug.Log("Health is being decreased by : " + damage + ".  Health is now :" + health);

            //if(collision.gameObject.name == "PowerUpBigShooter") { }
           // health -= 5;
           
        }
       
      //  Debug.Log("Asteroid has collided with something : " + collision);
    }
}
