using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]float projectileSpeed = 1f;
    [SerializeField] GameObject hitEffect = null;
    [SerializeField] float aboveScreenView;
    private void Update()
    {
        transform.Translate(Vector2.up *projectileSpeed *Time.deltaTime);
        if (transform.position.y >= aboveScreenView)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //add collision/other health component
        //small/med/big asteroids requiing more projectiles
      //  Debug.Log("Projectile has collided");
        
        projectileSpeed = 0;

        if (hitEffect != null)
        {
            Instantiate(hitEffect,transform.position,transform.rotation);
        }

        
        Destroy(gameObject); 
    }
}
