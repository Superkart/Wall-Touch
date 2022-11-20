using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
     private float speed = 4f;


    private void Awake()
    {
        playerRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            playerRigidbody.velocity = new Vector2(speed, 0);
        }
        if(Input.GetAxis("Horizontal") < 0)
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
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Door")
        {
            Debug.Log("Level Completed!");
        }
        else
        {
            Debug.Log("Find the correct exit :)");
        }
       
    }
}
