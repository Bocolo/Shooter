using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Spawning
{
    public class AsteroidSpace : MonoBehaviour
    {
        public static bool CheckOverlap(Vector2 position, int Radius)
        {
           
            Collider2D[] colliders = Physics2D.OverlapCircleAll(position, Radius);
            foreach (Collider2D col in colliders)
            {
               
                if (col.tag == "asteroid")
                {

                    return false;
                }
               
            }
            return true;
        }
        public static Vector2 RandomPosition(float width, float height1, float height2)
        {
           
            Vector2 position = new Vector2(Random.Range(-width, width), Random.Range(height1, height2));
          
            return position;
        }
            
    
    }
}
