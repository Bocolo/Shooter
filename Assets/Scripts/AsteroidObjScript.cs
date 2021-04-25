using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidObjScript : MonoBehaviour
{
    int fallY;
    float fallSpeed;
    public float fallSpeedX;
    public float fallSpeedY;
    public float rotationDeg;
    public float bigDeg;
    public float littleDeg;
    private void Start()
    {
        fallY = -9;
        fallSpeed = Random.Range(fallSpeedX,fallSpeedY);
        if (Random.value < 0.5f)
        {
            rotationDeg = Random.Range(-bigDeg, -littleDeg);
        }
        else
        {
            rotationDeg= Random.Range(littleDeg, bigDeg);
        }
    }

    
    void Update()
    {
        transform.Rotate(0, 0, rotationDeg * Time.deltaTime);
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        if(transform.position.y < fallY)
        {
            transform.position = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(6, 20));
            fallSpeed = Random.Range(fallSpeedX, fallSpeedY);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Asteroid has collided with something : " + collision);
    }
}
