using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MageCharacter : MonoBehaviour
{
    [Header("Movement")]
    float moveX;
    float moveY;
    public float movementSpeed; 

    [Header("UI Reference")]
    public GameObject manaBarGO;
    private Image manaBar;

    [HideInInspector]
    public bool canMove = false; 



    // Start is called before the first frame update

    private void Awake() 
    {
        manaBar = manaBarGO.GetComponent<Image>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        MovePlayer();
    }

    void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("mana"))
        {
            Destroy(other.gameObject);
            manaBar.fillAmount += 0.1f;
        }
    }

    private void GetPlayerInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        if(canMove)
        {
            Vector3 directionVector = new Vector3(moveX,moveY, 0);
            transform.Translate(directionVector.normalized * Time.deltaTime * movementSpeed);
        }
    }
}
