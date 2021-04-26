using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Transform shootPoint;
    [SerializeField] float speed;
    [SerializeField] Projectile bullet;
  
    [SerializeField] [Range(0, 1)] float LerpConstant;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
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
    private void Shoot()
    {
        Instantiate(bullet, shootPoint.position,Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  Debug.Log("Your spaceship has been hit");
    }

}
