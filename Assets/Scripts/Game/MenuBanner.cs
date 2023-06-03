using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HmsPlugin;
public class MenuBanner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      HMSAdsKitManager.Instance.ShowBannerAd();   
    }
    void update(){
        
    }
}
