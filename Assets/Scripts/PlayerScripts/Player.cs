
using UnityEngine;


namespace Shooter.Player
{
    public class Player : MonoBehaviour
    {
        public static bool isDead = false;
        [SerializeField] Transform shootPointCenter;
        [SerializeField] Transform shootPointLeft;
        [SerializeField] Transform shootPointRight;
       

        public bool isShootingCenter = true;
        public bool isShootingLargeBullet = false;
        public bool isShootingDisabled = false;
        float shootingDisablerTimer = 0;
        float powerUpTimer = 0;
        float powerUpSeconds = 7;
        float shootingDisablerSeconds = 2;

        private void Awake()
        {
            isDead = false;
        }
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
                ActivateProjectile(smallProjectile, shootPointCenter);
              
            }
            if (!isSmall)
            {
                GameObject largeProjectile = ProjectileManager.instance.GetPooledBlueLarge();
                ActivateProjectile(largeProjectile, shootPointCenter);
            
            }
        }
        private void ShootSide(Transform shootPoint)
        {
            GameObject redProjectile = ProjectileManager.instance.GetPooledRed();

            ActivateProjectile(redProjectile, shootPoint);
            
        }
        void ActivateProjectile(GameObject projectile, Transform shootPoint)
        {
            if(projectile != null)
            {
                projectile.transform.position = shootPoint.position;
                projectile.transform.rotation = Quaternion.identity;
                projectile.SetActive(true);
            }
        }

    }



}








