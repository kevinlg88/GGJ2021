using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfLayerOrder : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    GameObject character;

    private void Awake() 
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        character = GameObject.Find("Character");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetOrderLayer();
    }

    void SetOrderLayer()
    {
        if(character.transform.position.y > this.transform.position.y) sprite.sortingOrder = 4;
        else sprite.sortingOrder = 2;
    }
}
