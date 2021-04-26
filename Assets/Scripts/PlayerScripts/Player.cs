using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isDead = false;
    [SerializeField] Transform shootPointCenter;
    [SerializeField] Transform shootPointLeft;
    [SerializeField] Transform shootPointRight;
    [SerializeField] Projectile bulletBlue;
    [SerializeField] Projectile bulletRed;
    [SerializeField] Projectile bulletLargeBlue;
    public bool isShootingCenter = true;
    public bool isShootingLargeBullet = false;
    float timer = 0;
    float seconds = 7;
    /*
     Whats next--->
    adding powerup changing which shooter and damage
     
     */
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (isShootingCenter)
            {
                if (isShootingLargeBullet)
                {
                    ShootCenter(bulletLargeBlue);
                }
                else
                {
                    ShootCenter(bulletBlue);
                }
            }
            else
            {
                ShootSides();
            }
        }
       
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootSides();
        }
        if (!isShootingCenter || isShootingLargeBullet)
        {
           // Debug.Log("Timer before first reset is : " + timer);
           // timer = 0;
           // Debug.Log("Timer before rising above seconds reset is : " + timer);
            timer += Time.deltaTime;
          
            if (timer > seconds)
            {
          
                isShootingCenter = true;
                isShootingLargeBullet = false;
                timer = 0;
          
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  Debug.Log("Trigger on Mainship Detected");
        if (collision.gameObject.tag == "asteroid")
        {
            Die();
        }
        if (collision.gameObject.tag == "shooterSwitch")
        {
            isShootingCenter = false;
            isShootingLargeBullet = false;
        }
        if (collision.gameObject.tag == "PowerUp")
        {
            isShootingLargeBullet = true;
            isShootingCenter = true;
        }
    }
 

    void Die()
    {
        isDead = true;
     //   Debug.Log("You have Died");
    }
    private void ShootCenter(Projectile bullet)
    {
        Instantiate(bullet, shootPointCenter.position, Quaternion.identity);
    }
    private void ShootSides()
    {
        Debug.Log("Shooting From sides");
       // Instantiate(bulletRed, shootPointCenter.position, Quaternion.identity);

        Instantiate(bulletRed, shootPointLeft.position, Quaternion.identity);
        Instantiate(bulletRed, shootPointRight.position, Quaternion.identity);
    }

}
