using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class ScoreTracker : MonoBehaviour
    {
        public int score;
        public Text scoreText;

    private void Start()
    {
        score = 0;
    }
    private void Update()
        {
            HandleScore();
        }

        public void HandleScore()
        {
            
            scoreText.text = "Score: " + score;
        }
    }

