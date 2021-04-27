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
    public bool isShootingDisabled = false;
    float shootingDisablerTimer = 0;
    float powerUpTimer = 0;
    float powerUpSeconds = 7;
    float shootingDisablerSeconds = 2;
  
    private void Update()
    {
        if (Input.GetKeyDown("space") && !isShootingDisabled)
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
       
       
        if (!isShootingCenter || isShootingLargeBullet)
        {

            powerUpTimer += Time.deltaTime;
          
            if (powerUpTimer > powerUpSeconds)
            {
          
                isShootingCenter = true;
                isShootingLargeBullet = false;
                powerUpTimer = 0;
          
            }
        }
        if (isShootingDisabled)
        {
            shootingDisablerTimer += Time.deltaTime;
            if(shootingDisablerTimer> shootingDisablerSeconds)
            {
                isShootingDisabled = false;
                shootingDisablerTimer = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     ;
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
        if (collision.gameObject.tag == "DisableShooting")
        {
            isShootingDisabled = true;
        }
    }
 

    void Die()
    {
        isDead = true;
    }
    private void ShootCenter(Projectile bullet)
    {
        Instantiate(bullet, shootPointCenter.position, Quaternion.identity);
    }
    private void ShootSides()
    {
        Debug.Log("Shooting From sides");
      

        Instantiate(bulletRed, shootPointLeft.position, Quaternion.identity);
        Instantiate(bulletRed, shootPointRight.position, Quaternion.identity);
    }

}
