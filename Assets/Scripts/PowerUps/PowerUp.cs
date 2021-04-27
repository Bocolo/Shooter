using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

  
    [SerializeField] float fallSpeedMin =1;
    [SerializeField] float fallSpeedMax = 5;
    float fallSpeed;
    [SerializeField] float fallY = -6;

    private void Start()
    {
        fallSpeed = Random.Range(fallSpeedMin,fallSpeedMax);
    }
    private void Update()
    {

        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime, Space.World);
       
        if(transform.position.y < fallY)
        {
      
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
           
            Destroy(gameObject);
        }
    }
  
}
