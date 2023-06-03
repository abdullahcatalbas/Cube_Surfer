using DG.Tweening;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public PlayerMoverRunner PlayerMoverRunner;
    public SwerveInputSystem SwerveInputSystem;
    public SwerveMovement SwerveMovement;
    public PlayerBehaviour PlayerBehaviour;
    public PlayerCubeManager PlayerCubeManager;
    public CubeBehaviour CubeBehaviour;
    public CubeDetector CubeDetector;
    public GameOver GameOver;
    public AdsManager AdsManager;
    public IAPManager IAPManager;
    public ScoreManager ScoreManager;
    ////////////////////////////////
    
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
   

    
}
