using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject mage;
    public float speedFollow;
    public float normalSpeed;

    [HideInInspector]
    public bool startFollow = false;

    [Header("Zoom")]
    public float zoomOffset = -10;

    Camera cameraGame;
    // Start is called before the first frame update
    void Start()
    {
        cameraGame = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if(startFollow)
        {
            FollowCharacter();
        }
    }

    void FollowCharacter()
    {
        Vector3 myPos = transform.position; 
        Vector3 newPos = new Vector3(mage.transform.position.x, mage.transform.position.y, zoomOffset);
        transform.position = Vector3.MoveTowards(myPos, newPos, speedFollow * Time.deltaTime);
        if(this.transform.position.z == zoomOffset)
        {
            speedFollow = normalSpeed;
        }
    }

}
