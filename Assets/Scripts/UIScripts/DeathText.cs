using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shooter.Player;

public class DeathText : MonoBehaviour
{
    [SerializeField] Text deathText;

    private void Update()
    {
        if (Player.isDead)
        {
            deathText.text = "You Died";
        }
    }
}
