using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject prologuePopup;
    Image fade;

    //Control Variables
    bool prologue = false;
    float fadeAlpha = 1;

    private void Awake() 
    {
        fade = prologuePopup.transform.Find("fade").GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputStart();
    }

    void InputStart()
    {
        if(Input.GetButtonDown("Jump") && prologue)
        {
            StartCoroutine(HidePrologue());
        }

        else if(Input.GetButtonDown("Jump") && !prologue)
        {
            prologue = true;
            prologuePopup.SetActive(true);
            StartCoroutine(ShowPrologue());
        }
    }

    IEnumerator ShowPrologue()
    {
        fade.color = new Color(fade.color.r,fade.color.g, fade.color.b, fadeAlpha);
        if(fadeAlpha > 0)fadeAlpha -= 0.1f;
        else
        { 
            fadeAlpha = 0;
            StopCoroutine(ShowPrologue());
            yield break; 
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ShowPrologue());
    }

    IEnumerator HidePrologue()
    {
        fade.color = new Color(fade.color.r,fade.color.g, fade.color.b, fadeAlpha);
        if(fadeAlpha < 1)fadeAlpha += 0.1f;
        else
        { 
            fadeAlpha = 1;
            StopCoroutine(HidePrologue());
            SceneManager.LoadScene("Game",LoadSceneMode.Single);
            yield break;
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(HidePrologue());
    }
}
