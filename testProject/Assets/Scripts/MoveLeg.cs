using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeg : MonoBehaviour
{
    public int moveLegSpeed;
    private int isMovingLeft = 1;
    private PlayerController playerController;
    private bool playerIsOnGround;

  
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGameActive == true)
        {
             playerIsOnGround = playerController.isOnGround;
        
            if (transform.rotation.z <-0.5 )
            {
                isMovingLeft = 1;
            }
            else if (transform.rotation.z >0.9)
            {
                isMovingLeft = -1;
            }
            
            if (playerIsOnGround){
                transform.Rotate(new Vector3(0,0,-isMovingLeft) * Time.deltaTime * moveLegSpeed);}
        
        }
       
    }
   
}
