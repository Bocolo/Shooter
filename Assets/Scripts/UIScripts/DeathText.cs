using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shooter.Player;

public class DeathText : MonoBehaviour
{
    public Text deathText;

    //[SerializeField] Player player;
   // Player player;
   
  /*  private void Start()
    {
        deathText.text = "You are alive";
    }*/
    private void Update()
    {
        if (Player.isDead)
        {
            deathText.text = "You Died";
        }
    }
}
