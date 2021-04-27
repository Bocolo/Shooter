using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]float projectileSpeed = 1f;
    [SerializeField] GameObject hitEffect = null;
    [SerializeField] float aboveScreenView;
    public int projectileDamage =5;
    private void Update()
    {
        transform.Translate(Vector2.up *projectileSpeed *Time.deltaTime);
        if (transform.position.y >= aboveScreenView)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
       // projectileSpeed = 0;

        if (hitEffect != null)
        {
            Instantiate(hitEffect,transform.position,transform.rotation);
        }

        gameObject.SetActive(false);
        //Destroy(gameObject); 
    }
}
