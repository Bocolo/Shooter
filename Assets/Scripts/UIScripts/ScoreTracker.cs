using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class ScoreTracker : MonoBehaviour
    {
        
        [SerializeField] Text scoreText;
        [SerializeField] Text highScoreText;

    private void Start()
    {
   
       
        highScoreText.text = "Highscore: " +PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void LateUpdate()
        {
     

            HandleScore();
        if (GameManager.instance.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", GameManager.instance.score);
            highScoreText.text= "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
     
        }

        public void HandleScore()
        {
           
            scoreText.text = "Score: " + GameManager.instance.score;
        }

    }

