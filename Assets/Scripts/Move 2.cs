using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    private GameObject currentTeleporter;
    public float speed;
    public float jumpForce;
    public bool Jump;

    private Rigidbody2D rb;
    private bool isGrounded;
    public bool isOnPlatform;
    public Rigidbody2D platform;
    public PlayerHealth player1 ,player2 ;

    //shield
    private bool shielded;
    [SerializeField] private GameObject shield;

    

    void Start()
    {
        shielded = false;

        Jump = false;
        isGrounded = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckShield();

        float h_move = Input.GetAxis("Player2_Horizontal");

        if (isOnPlatform)
        {
            rb.velocity = new Vector2((h_move * speed) + platform.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(h_move * speed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Jump && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Đặt vận tốc y về 0 trước khi nhảy
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //Shield
        

        
            
    }
    public void CheckShield()
    {
        if (Input.GetKey(KeyCode.E) && !shielded)
        {
            shield.SetActive(true);
            shielded = true;

            // code for turning off shield
            Invoke("NoShield", 3f); // thời gian có khiên
        }
    }
    public void NoShield()
    {
        shield.SetActive(false);
        shielded = false;
    }

    public bool IsShielded()
    {
        player1.GetDamage(0);
        player2.GetDamage(0);
        return shielded;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" )
        {
            Jump = true;
            isGrounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Jump = false;
            isGrounded = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
