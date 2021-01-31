using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image manaBar;

    public TextMeshProUGUI timerUI;

    [Header("Popup")]
    public GameObject popupWin;
    public GameObject popupLose;

    [Header("References")]
    public MageCharacter mage;
    public CameraFollow cameraFollow;

    public GameObject lightFollow;


    [Header("Control Variables")]
    public int timer;
    private bool start = false;
    private bool popup = false;


    void Start()
    {
        lightFollow.SetActive(true);
        timerUI.text = timer.ToString() + " " + "Seconds";
        StartCoroutine(StartGameCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if(start)CheckWinLose();
        InputStart();

    }

    IEnumerator StartGameCountDown()
    {
        yield return new WaitForSeconds(3);
        lightFollow.SetActive(false);
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
            popupWin.SetActive(true);
            popup = true;
            Debug.Log("Win");
            mage.canMove = false;
            start = false;
        }

        else if(manaBar.fillAmount < 1 && timer <= 0)
        {
            //Popup Lose
            popupLose.SetActive(true);
            popup = true;
            Debug.Log("Lose");
            mage.canMove = false;
            start = false;
        }
    }

    void InputStart()
    {
        if(Input.GetButtonDown("Jump") && popup)
        {
            SceneManager.LoadScene("Menu",LoadSceneMode.Single);
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
