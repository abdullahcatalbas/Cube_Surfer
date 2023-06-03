using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using HmsPlugin;
using HuaweiMobileServices.IAP;
using HuaweiMobileServices.Id;
using HuaweiMobileServices.Utils;
using System;
using TMPro;


public class GameOver : MonoBehaviour
{
    
    public static GameOver instance;
    public GameObject bg;
    public RectTransform WatchAds;
    public RectTransform WinUI;
    public RectTransform FailUI;
    public bool LeveL2 = false;
    public bool LeveL3 = false;

    public Text pointsText;
    private bool rewarded = false;

    public ScoreManager sc;
    public AdsManager ads;
    
  

    void Awake()
    {
        instance = this;
    }
  
    public void SetUp()
    {
        Debug.Log("Setup");
        bg.gameObject.SetActive(true);
        pointsText.text =ScoreManager.instance.score.ToString() + "  POINTS";
        PlayerBehaviour.Instance.StopPlayer();
        if(PlayerCubeManager.Instance.listOfCubeBehaviour.Count < 1)
        {
            ActiveFailUI();
            ActiveWatchAds();

        }
        else{
            LeveL2 = true;
            ActiveWinUI();
            
        }

       
    }

    public void ActiveWinUI()
    {
        WinUI.gameObject.SetActive(true);
        Vector3 defaultScale = WinUI.transform.localScale;

        WinUI.transform.localScale = Vector3.one * 0.00001f;
        WinUI.DOScale(defaultScale,1f).SetEase(Ease.OutBounce);

        
        
        if (LeveL2 == true)
        {
                LeveL3 = true;
        }
       
        
        
    }

    public void ActiveFailUI()
    {
        FailUI.gameObject.SetActive(true);
        Vector3 defaultScale = FailUI.transform.localScale;

        FailUI.transform.localScale = Vector3.one * 0.00001f;
        FailUI.DOScale(defaultScale,1f).SetEase(Ease.OutBounce);
              
    }
    public void ActiveWatchAds()
    {
        WatchAds.gameObject.SetActive(true);
        Vector3 defaultScale =WatchAds.transform.localScale;

       WatchAds.transform.localScale = Vector3.one * 0.00001f;
       WatchAds.DOScale(defaultScale,1f).SetEase(Ease.OutBounce);
    }

   
     

   

    public void ExtraGem() 
    {
        if(ads.rewarded)
        {
            sc.ExtraGems();
        }
    }

    public void RestartGame()
    {
        LeveL2 = false;
        LeveL3 = false;
        SceneManager.LoadScene("Game");
    
    }
    public void OpenScene()
    {
        
        if(LeveL2 == true)
        {
            SceneManager.LoadScene("LeveL2");
        }
        

        
    }
    public void OpenScene2()
    {
        if(LeveL3 == true)
        {
            SceneManager.LoadScene("LeveL3");
        }
        
    }
     public void OpenMainMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
        
        
    }
    public void Quit()
    {
        Application.Quit();
    }
  

}
