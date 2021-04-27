using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance = null;
   public List<GameObject> pooledSmallBlueProjectiles;
    public List<GameObject> pooledLargeBlueProjectiles;
    public List<GameObject> pooledSmallRedProjectiles;
    public GameObject smallRedProjectilToPool;
    public GameObject smallBlueProjectilToPool;
    public GameObject largeBlueProjectilToPool;
    public int amountToPool = 200;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pooledLargeBlueProjectiles = new List<GameObject>();
        pooledSmallBlueProjectiles = new List<GameObject>();
        pooledSmallRedProjectiles = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject redProj = (GameObject)Instantiate(smallRedProjectilToPool);
            GameObject blueSmallProj = (GameObject)Instantiate(smallBlueProjectilToPool);
            GameObject blueLargeProj = (GameObject)Instantiate(largeBlueProjectilToPool);
            redProj.SetActive(false);
            blueLargeProj.SetActive(false);
            blueSmallProj.SetActive(false);
            pooledSmallRedProjectiles.Add(redProj);
            pooledSmallBlueProjectiles.Add(blueSmallProj);
            pooledLargeBlueProjectiles.Add(blueLargeProj);
        }
    }
    public GameObject GetPooledRed()
    {
        return GetPooled(pooledSmallRedProjectiles);
    }
    public GameObject GetPooledBlueSmall()
    {
        return GetPooled(pooledSmallBlueProjectiles);
    }
    public GameObject GetPooledBlueLarge()
    {
        return GetPooled(pooledLargeBlueProjectiles);
    }
   GameObject GetPooled(List<GameObject> listOfPooledBullets)
    {

        for (int i = 0; i < listOfPooledBullets.Count; i++)
        {
            if (!listOfPooledBullets[i].activeInHierarchy)
            {
                return listOfPooledBullets[i];
            }
        }
        return null;
    }
}

      /* for(int i=0; i<pooledSmallRedProjectiles.Count; i++)
        {
            if (!pooledSmallRedProjectiles[i].activeInHierarchy)
            {
                return pooledSmallRedProjectiles[i];
            }
        }
        return null;*/
