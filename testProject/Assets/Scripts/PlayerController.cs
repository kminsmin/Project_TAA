using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float JumpForce;
    public GameObject bullet;
    private float time;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI lifeText;
    public bool isOnGround = true;
    private bool readyHit = true;
    private float coolDown = 0.0f;
    private bool isOnAir = false;
    public float gravityMultiplier;
    public float moveSpeed;
    public int health = 3;
    public bool isGameActive = false;
 
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityMultiplier;
     
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            if(coolDown < 1.0f)
        {coolDown += Time.deltaTime;
        }
        
        if(coolDown > 1)
        {
            readyHit = true;
            //Debug.Log("Hit Ready");
        }
        if(Input.GetKeyDown(KeyCode.W)&& isOnGround && !isOnAir)
        {
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGround = false;
            isOnAir = true;
            
        }
        else if(Input.GetKeyDown(KeyCode.W)&& !isOnGround && isOnAir)
        {
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGround = false;
            isOnAir = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
        
        
        transform.Translate(new Vector3(1,0,0) * Time.deltaTime * moveSpeed* Input.GetAxis("Horizontal"));
        if (transform.position.x < -12)
        {
            transform.position = new Vector3(-12, transform.position.y, transform.position.z);
        }
        time += Time.deltaTime;
        timeText.text = "Time : " + time;
        
        }
        
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            isOnAir = false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (readyHit && other.CompareTag("Obstacle"))
        {
            health -= 1;
            Debug.Log("Health : " + health);
            readyHit = false;
            coolDown = 0;
            if (health==2)
            {
                lifeText.text ="HP" + "######";
            }
            else if (health == 1)
            {
                lifeText.text ="HP" + "###";
            }
            
            if (health == 0)
            {
                isGameActive = false;
                lifeText.text ="HP X";
                Debug.Log("Game Over!");
                gameOverText.gameObject.SetActive(true);
                Physics.gravity /= gravityMultiplier;
            }
        }
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        playerRb = GetComponent<Rigidbody>();
        
        time = 0;
        timeText.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
        isGameActive = true;
        lifeText.text ="HP" + "#########";
    }
}
