using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject gameWonPanel;
    private Rigidbody2D playerRigidbody;
    private float speed = 4f;
    private bool gameOver = false;

    private void Awake()
    {
        playerRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        if (gameWonPanel.activeSelf)
        {
            gameWonPanel.SetActive(false);
        }
    }
    private void Update()
    {
        if (!gameOver)
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
            gameWonPanel.SetActive(true);
            gameOver= true;
            Time.timeScale = 0f;
        }
        else
        {
            Debug.Log("Find the correct exit :)");
        }
       
    }
}
