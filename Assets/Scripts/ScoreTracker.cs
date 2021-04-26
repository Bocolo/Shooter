using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class ScoreTracker : MonoBehaviour
    {
        public int score;
        public Text scoreText;

    private void Awake()
    {
        score = 0;
        scoreText.text = "this is test text";  
    }
    private void LateUpdate()
        {
        //scoreText.text = "This is the update";
     /*   if (score > 1)
        {
            scoreText.text = "now";
            Debug.Log("ScoreText is updating");
        }*/

            HandleScore();
        }

        public void HandleScore()
        {
            
            scoreText.text = "Score: " + score;
        }
    }

