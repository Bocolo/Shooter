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
    [SerializeField] bool isShootingCenter = true;
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
                ShootCenter();
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  Debug.Log("Trigger on Mainship Detected");
        if (collision.gameObject.tag == "asteroid")
        {
            Die();
        }
    }
 

    void Die()
    {
        isDead = true;
     //   Debug.Log("You have Died");
    }
    private void ShootCenter()
    {
        Instantiate(bulletBlue, shootPointCenter.position, Quaternion.identity);
    }
    private void ShootSides()
    {
        Debug.Log("Shooting From sides");
        Instantiate(bulletRed, shootPointLeft.position, Quaternion.identity);
        Instantiate(bulletRed, shootPointRight.position, Quaternion.identity);
    }

}
