using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
 
    [SerializeField] float speed;
   


    [SerializeField] [Range(0, 1)] float LerpConstant;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    void FixedUpdate()
    {

        Movement();
    }
    private void Movement()
    {

        if (transform.position.x <= -2.2f)
        {
            transform.position = new Vector2(-2.2f, transform.position.y);
        }
        else if (transform.position.x >= 2.2f)
        {
            transform.position = new Vector2(2.2f, transform.position.y);
        }

        float h = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(h, rb.velocity.y);
        rb.velocity = Vector2.Lerp(rb.velocity, movement, LerpConstant) * speed;


    }

}
