using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UiManager uiManager;
    [SerializeField] private CameraEffects camEffects;
    
    private Rigidbody2D playerRigidbody;
    private float speed = 3f;
    private bool isGameOver = false;

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
        if (!isGameOver)
        {
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
            StartCoroutine(camEffects.Shake(0.3f, 0.2f));
            Debug.Log("Level Lost!");         
            uiManager.GameLost();
            isGameOver = true;
        }
        else
        {
            Debug.Log("Find the correct exit :)");
        }
       
    }
}
