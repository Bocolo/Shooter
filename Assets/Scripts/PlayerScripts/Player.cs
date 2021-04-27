using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shooter.Player
{
    public class Player : MonoBehaviour
    {
        public static bool isDead = false;
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
                    ShootCenter(!isShootingLargeBullet);

                }
                else
                {

                    ShootSide(shootPointLeft);
                    ShootSide(shootPointRight);
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
                if (shootingDisablerTimer > shootingDisablerSeconds)
                {
                    isShootingDisabled = false;
                    shootingDisablerTimer = 0;
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.tag == "asteroid")
            {
                Die();
                gameObject.SetActive(false);
                GameManager.instance.GameOver();
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
        private void ShootCenter(bool isSmall)
        {
            if (isSmall)
            {
                GameObject smallProjectile = ProjectileManager.instance.GetPooledBlueSmall();
                Debug.Log("Small Projectile is trying to be shot");
                if (smallProjectile != null)
                {
                    smallProjectile.transform.position = shootPointCenter.position;
                    smallProjectile.transform.rotation = Quaternion.identity;
                    Debug.Log("Small Projectils is being activaes");
                    smallProjectile.SetActive(true);
                }
            }
            if (!isSmall)
            {
                GameObject largeProjectile = ProjectileManager.instance.GetPooledBlueLarge();
                if (largeProjectile != null)
                {
                    largeProjectile.transform.position = shootPointCenter.position;
                    largeProjectile.transform.rotation = Quaternion.identity;
                    Debug.Log("Large Projectils is being activaes");
                    largeProjectile.SetActive(true);
                }
            }
        }
        private void ShootSide(Transform shootPoint)
        {
            GameObject redProjectile = ProjectileManager.instance.GetPooledRed();
            if (redProjectile != null)
            {
                redProjectile.transform.position = shootPoint.position;
                redProjectile.transform.rotation = Quaternion.identity;
                Debug.Log("Small Projectils1 is being activaes");
                redProjectile.SetActive(true);
            }
        }


    }



}








/*
 * 
 *     private void ShootSideRight()
    {
        GameObject redProjectile = ProjectileManager.instance.GetPooledRed();
        if (redProjectile != null)
        {
            redProjectile.transform.position = shootPointRight.position;
            redProjectile.transform.rotation = Quaternion.identity;
            Debug.Log("Small Projectils1 is being activaes");
            redProjectile.SetActive(true);
        }
    }
 *     private void ShootSideLeft()
    {
        GameObject redProjectile = ProjectileManager.instance.GetPooledRed();
        if (redProjectile != null)
        {
            redProjectile.transform.position = shootPointLeft.position;
            redProjectile.transform.rotation = Quaternion.identity;
            Debug.Log("Small Projectils1 is being activaes");
            redProjectile.SetActive(true);
        }
    }
 * 
 * 
 * 
 * 
 * 
 * private void ShootCenter(Projectile bullet)
{

    Instantiate(bullet, shootPointCenter.position, Quaternion.identity);
}*/
/*private void ShootSides()
{
    Debug.Log("Shooting From sides");


    Instantiate(bulletRed, shootPointLeft.position, Quaternion.identity);
    Instantiate(bulletRed, shootPointRight.position, Quaternion.identity);
}*/


/*private void ShootSidesTest()
{
    GameObject redProjectile1 = ProjectileManager.instance.GetPooledRed();
    GameObject redProjectile2 = ProjectileManager.instance.GetPooledRed();
    Debug.Log("Red Projectiles is trying to be shot:  :" + redProjectile1 + "   " + redProjectile2);
    if (redProjectile1 != null)
    {
        redProjectile1.transform.position = shootPointLeft.position;
        redProjectile1.transform.rotation = Quaternion.identity;
        Debug.Log("Small Projectils1 is being activaes");
        redProjectile1.SetActive(true);
    }
    if (redProjectile2 != null)
    {
        redProjectile2.transform.position = shootPointRight.position;
        redProjectile2.transform.rotation = Quaternion.identity;
        Debug.Log("Small Projectils 2is being activaes");
        redProjectile2.SetActive(true);
    }
}*/
