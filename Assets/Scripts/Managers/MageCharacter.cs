using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MageCharacter : MonoBehaviour
{
    [Header("Movement")]

    Vector2 movement;
    public float movementSpeed; 

    [Header("UI Reference")]
    public GameObject manaBarGO;
    private Image manaBar;

    [HideInInspector]
    public bool canMove = false; 

    private bool moving = false;

    private Animator animator;



    // Start is called before the first frame update

    private void Awake() 
    {
        manaBar = manaBarGO.GetComponent<Image>();
        animator = GetComponent<Animator>();
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
            AudioManager.instance.ManaGet(true);
        }
    }

    private void GetPlayerInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("moveX",movement.x);
        animator.SetFloat("moveY",movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        // Debug.Log("Vector Movement: " + movement + " " + "\n" +
        //             "Speed " + movement.sqrMagnitude);
        
        if(movement != new Vector2(0,0))
        {
            if(!moving && canMove)
            {
                AudioManager.instance.Footstep(true);
            }
            moving = true;
            animator.SetFloat("moveLateX",movement.x);
            animator.SetFloat("moveLateY",movement.y);
        }
        else
        {
            if(moving || !canMove)
            {
                AudioManager.instance.Footstep(false);
                moving = false;
            }
        }
    }

    private void MovePlayer()
    {
        if(canMove)
        {
            Vector3 directionVector = new Vector3(movement.x,movement.y, 0);
            transform.Translate(directionVector.normalized * Time.deltaTime * movementSpeed);
        }
    }
}
