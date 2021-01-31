using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    // Start is called before the first frame update

    public AudioSource footstep;
    public AudioSource manaGet;
    private void Awake() 
    {
        if(instance == null)instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Footstep(bool condicao)
    {
        if(condicao)footstep.Play();
        else footstep.Stop();
    }

    public void ManaGet(bool condicao)
    {
        if(condicao)manaGet.Play();
        else manaGet.Stop();
    }
}
