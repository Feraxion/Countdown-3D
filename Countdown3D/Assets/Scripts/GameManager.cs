using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Tabtale.TTPlugins;

public class GameManager : MonoBehaviour
{
  


    public GameObject StartScreen;
    public GameObject FinishScreen;
    public GameObject GameOverScreen;


    public static GameManager inst;
    
    public enum PlayerState
    {
        Prepare,
        Playing,
        Died,
        Shopping,
        Finish
    }

    public PlayerState playerState;
    
    

    private void Awake()
    {
        TTPCore.Setup();
    
       

        inst = this;
        playerState = PlayerState.Prepare;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
    }

    void Update()
    {
        if (playerState == PlayerState.Prepare)
        {
            StartScreen.SetActive(true);

        }

        if (playerState == PlayerState.Finish)
        {

               

            FinishScreen.SetActive(true);
            
        }

        if (playerState == PlayerState.Died)
        {
            GameOverScreen.SetActive(true);
        }
    }
    

    
    
    IEnumerator WaitAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
    }

   
    
    
}
