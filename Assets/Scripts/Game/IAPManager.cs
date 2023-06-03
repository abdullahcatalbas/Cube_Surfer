using HmsPlugin;
using HuaweiMobileServices.Base;
using HuaweiMobileServices.IAP;
using HuaweiMobileServices.Utils;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using HuaweiConstants;
using UnityEngine;
using UnityEngine.Events;
using HuaweiMobileServices.Id;
using UnityEngine.SceneManagement;
using HmsPlugin;

using HuaweiMobileServices.IAP;
using HuaweiMobileServices.Utils;

using System;
using System.Collections.Generic;

using UnityEngine;

public class IAPManager : MonoBehaviour
{

    
    public AdsManager ads;


    public static Action<string> IAPLog;

    List<InAppPurchaseData> consumablePurchaseRecord = new List<InAppPurchaseData>();
    List<InAppPurchaseData> activeNonConsumables = new List<InAppPurchaseData>();
    List<InAppPurchaseData> activeSubscriptions = new List<InAppPurchaseData>();

    #region Singleton

    public static IAPManager Instance { get; private set; }
    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    #region Monobehaviour

    private void OnEnable()
    {
        HMSIAPManager.Instance.OnBuyProductSuccess += OnBuyProductSuccess;
        HMSIAPManager.Instance.OnInitializeIAPSuccess += OnInitializeIAPSuccess;
        HMSIAPManager.Instance.OnInitializeIAPFailure += OnInitializeIAPFailure;
        HMSIAPManager.Instance.OnBuyProductFailure += OnBuyProductFailure;
    }

    private void OnDisable()
    {
        HMSIAPManager.Instance.OnBuyProductSuccess -= OnBuyProductSuccess;
        HMSIAPManager.Instance.OnInitializeIAPSuccess -= OnInitializeIAPSuccess;
        HMSIAPManager.Instance.OnInitializeIAPFailure -= OnInitializeIAPFailure;
        HMSIAPManager.Instance.OnBuyProductFailure -= OnBuyProductFailure;
    }

    void Awake()
    {
        Singleton();
    }

    void Start()
    {
        // Uncomment below if InitializeOnStart is not enabled in Huawei > Kit Settings > IAP tab.
        //HMSIAPManager.Instance.InitializeIAP();
    }

    #endregion

    public void InitializeIAP()
    {
        Debug.Log($"InitializeIAP");

        HMSIAPManager.Instance.InitializeIAP();
    }

    private void RestoreProducts()
    {

        HMSIAPManager.Instance.RestorePurchaseRecords((restoredProducts) =>
        {
            foreach (var item in restoredProducts.InAppPurchaseDataList)
            {
                if ((IAPProductType)item.Kind == IAPProductType.Consumable)
                {
                    Debug.Log($"Consumable: ProductId {item.ProductId} , SubValid {item.SubValid} , PurchaseToken {item.PurchaseToken} , OrderID  {item.OrderID}");
                    consumablePurchaseRecord.Add(item);
                }
            }
        });

        HMSIAPManager.Instance.RestoreOwnedPurchases((restoredProducts) =>
        {
            foreach (var item in restoredProducts.InAppPurchaseDataList)
            {
                if ((IAPProductType)item.Kind == IAPProductType.Subscription)
                {
                    Debug.Log($"Subscription: ProductId {item.ProductId} , ExpirationDate {item.ExpirationDate} , AutoRenewing {item.AutoRenewing} , PurchaseToken {item.PurchaseToken} , OrderID {item.OrderID}");
                    activeSubscriptions.Add(item);
                }
                else if ((IAPProductType)item.Kind == IAPProductType.NonConsumable)
                {
                    Debug.Log($"NonConsumable: ProductId {item.ProductId} , DaysLasted {item.DaysLasted} , SubValid {item.SubValid} , PurchaseToken {item.PurchaseToken} ,OrderID {item.OrderID}");
                    activeNonConsumables.Add(item);
                }
            }
        });

    }

    public void PurchaseProduct(string productID)
    {
        Debug.Log($"PurchaseProduct");

        HMSIAPManager.Instance.PurchaseProduct(productID);
    }

    #region Callbacks

    private void OnBuyProductSuccess(PurchaseResultInfo obj)
    {
        Debug.Log($"OnBuyProductSuccess");

        if (obj.InAppPurchaseData.ProductId == "182246")
        {
            ads.HideAds = true;
            IAPLog?.Invoke("Ads Removed!");
        }
        if (obj.InAppPurchaseData.ProductId == "182476")
        {
            ads.Double = true;
            IAPLog?.Invoke("USe 2x");
        }
        
    }

    private void OnInitializeIAPFailure(HMSException obj)
    {
        IAPLog?.Invoke("IAP is not ready.");
    }

    private void OnInitializeIAPSuccess()
    {
        IAPLog?.Invoke("IAP is ready.");

        RestoreProducts();
    }

    private void OnBuyProductFailure(int code)
    {
        IAPLog?.Invoke("Purchase Fail.");
    }

    #endregion
}