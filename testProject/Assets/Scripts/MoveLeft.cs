using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public int health;
    private float  xBoundary = -15;
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGameActive == true)
        {
            transform.Translate(new Vector3(-1,0,0) * Time.deltaTime * moveSpeed);
        }
        if (transform.position.x < xBoundary)
        {
            Destroy(gameObject);
        }
        
    
    }
    private void OnTriggerEnter(Collider other) 
        
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
            Destroy(other.gameObject);
            Debug.Log("Enemy Hit!");
            if ( health < 1)
            {
                Destroy(gameObject);
                
            }
        }
        
    }
}
