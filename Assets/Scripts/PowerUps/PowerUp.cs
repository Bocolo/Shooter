using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

  
    public float fallSpeed =1;
    public float fallY = -6;
    
    private void Update()
    {

        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
       
        if(transform.position.y < fallY)
        {
         //   gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("power up trigger");
        if (collision.gameObject.tag == "Player")
        {
           // player.isShootingCenter = false;
            Destroy(gameObject);
        }
    }
  
}
