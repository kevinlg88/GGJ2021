using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image manaBar;

    public TextMeshProUGUI timerUI;

    //[Header("Popup")]

    [Header("References")]
    public MageCharacter mage;
    public CameraFollow cameraFollow;


    [Header("Control Variables")]
    public int timer;
    private bool start = false;


    void Start()
    {
        timerUI.text = timer.ToString() + " " + "Seconds";
        StartCoroutine(StartGameCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if(start)CheckWinLose();

    }

    IEnumerator StartGameCountDown()
    {
        yield return new WaitForSeconds(3);
        start = true;
        mage.canMove = true;
        cameraFollow.startFollow = true;
        UpdateCount();
    }

    void CheckWinLose()
    {
        if(manaBar.fillAmount >= 1)
        {
            //Popup Win
            Debug.Log("Win");
            start = false;
        }

        else if(manaBar.fillAmount < 1 && timer <= 0)
        {
            //Popup Lose
            Debug.Log("Lose");
            start = false;
        }
    }

    void UpdateCount()
    {
        if(start)
        {
            timer -= 1;
            timerUI.text = timer.ToString() + " " + "Seconds";
            StartCoroutine(UpdateTimer());
        }
    }

    IEnumerator UpdateTimer() 
    {
        yield return new WaitForSeconds(1);
        UpdateCount();
    }


}
