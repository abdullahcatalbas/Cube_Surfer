using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScoreManager : MonoBehaviour
{
   public static ScoreManager instance;
   public AdsManager ads;
   public GameOver go;
 
   public Text scoreText;

   
   
   public int score = 0;
   private int score_kt = 1;
   
   
   

   private void Awake()
   {
    instance = this;
   }

   void Start()
   {      
        scoreText.text = score.ToString() + " POINTS";
        if(ads.Double){
            score_kt = 2;
        }

   }
   public void AddPoint()
    {

        score += score_kt;
        scoreText.text = score.ToString() + " POINTS";     

    }
    public void ExtraGems(){

        score += 15;
    }
    public void AddGems()
    {

        score += 10;
        go.pointsText.text = score.ToString() + " POINTS";
        scoreText.text = score.ToString() + " POINTS";


    }
    public void DoubleScore()
    {
        score_kt = 2;
    }

}
