using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathText : MonoBehaviour
{
    public Text deathText;
    [SerializeField] Player player;
    private void Start()
    {
        deathText.text = "You are alive";
    }
    private void Update()
    {
        if (player.isDead)
        {
            deathText.text = "You Died";
        }
    }
}
