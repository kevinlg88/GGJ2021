using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageCharacter : MonoBehaviour
{
    float moveX;
    float moveY;
     
    public float movementSpeed; 

    // Start is called before the first frame update
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

    private void GetPlayerInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        Vector3 directionVector = new Vector3(moveX,moveY, 0);
        transform.Translate(directionVector.normalized * Time.deltaTime * movementSpeed);
    }
}
