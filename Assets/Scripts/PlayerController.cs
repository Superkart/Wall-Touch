using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UiManager uiManager;
    
    private Rigidbody2D playerRigidbody;
    private float speed = 3f;
    

    private void Awake()
    {
        playerRigidbody = this.gameObject.GetComponent<Rigidbody2D>();   
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
            if (Input.GetAxis("Horizontal") > 0)
            {
                playerRigidbody.velocity = new Vector2(speed, 0);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                playerRigidbody.velocity = new Vector2(-speed, 0);
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                playerRigidbody.velocity = new Vector2(0, speed);
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                playerRigidbody.velocity = new Vector2(0, -speed);
            }
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                playerRigidbody.velocity = Vector2.zero;
            }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Door")
        {
            Debug.Log("Level Completed!");
            uiManager.GameWon();
            Time.timeScale = 0f;
        }
        if(collision.tag == "ToxicWall")
        {
            Debug.Log("Level Lost!");
            uiManager.GameLost();
            Time.timeScale = 0f;
        }
        else
        {
            Debug.Log("Find the correct exit :)");
        }
       
    }
}
