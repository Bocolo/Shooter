using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0f;
  
    private void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2( 0f, Time.time * scrollSpeed);
    }
}
