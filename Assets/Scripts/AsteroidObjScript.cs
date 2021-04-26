using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidObjScript : MonoBehaviour
{
    int fallY;
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
  //  GameObject currentAsteroid;
    private void Start()
    {
      //  gameObject.SetActive(true);
        healthReset = health;
        fallY = -9;
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

    
    void Update()
    {
        if (health < 30 && largeAsteroid != null && hugeAsteroid.activeSelf)
        {
            largeAsteroid.SetActive(true);
            hugeAsteroid.SetActive(false);
            Debug.Log("checking health under 30");
        }

        if (health < 21 && mediumAsteroid!= null  && largeAsteroid.activeSelf)
            {
                mediumAsteroid.SetActive( true);
                largeAsteroid.SetActive(false);
            Debug.Log("checking health under 20");
            }
            if (health < 11 && smallAsteroid!=null && mediumAsteroid.activeSelf)
            {
            smallAsteroid.SetActive( true);
            mediumAsteroid.SetActive(false);
            Debug.Log("checking health under 10");
        }
        if (health <= 0)
        {
            smallAsteroid.SetActive(false);
            hasExploded = true;
            scoreTracker.score += scoreForDestruction;
        }
        
        transform.Rotate(0, 0, rotationDeg * Time.deltaTime);
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        if(transform.position.y < fallY || hasExploded)
        {
            // gameObject.SetActive(true);
            hasExploded = false;
            activeAsteroid.SetActive(true);
            health = healthReset;
            transform.position = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(6, 20));
            fallSpeed = Random.Range(fallSpeedX, fallSpeedY);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Projectile>())
        {
            health -= 5;
           
        }
       
        Debug.Log("Asteroid has collided with something : " + collision);
    }
}
