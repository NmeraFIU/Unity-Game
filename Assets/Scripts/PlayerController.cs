using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int exJumps = 2;
    public LayerMask groundLayer;
    public Transform feet;
    bool isGrounded;
    int jumpCount;
    float jumpCoolDown;
    float jumpPower = 7.0f;

    private Rigidbody2D rb;

    private Vector3 respawnPoint;
    public GameObject damageDetector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(dirX * 5f, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            //rb.velocity = new Vector3(0, 7f, 0);
            Jump();
        }
        CheckGrounded();
        if (Input.GetButtonUp("Jump"))
        {
            rb.velocity = new Vector3(0, -2f, 0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = respawnPoint;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            //*****Player dying and respawning*****
            Debug.Log("You died!");
            transform.position = respawnPoint;
        } else if (collision.gameObject.CompareTag("Checkpoint"))
        {
            //I believe this is redundant code. Will worry about deleting later.
            Debug.Log(collision.gameObject.transform.position);
            Debug.Log("Checkpoint reached!");
            respawnPoint = collision.gameObject.transform.position;
        }
    }

    void Jump()
    {
        if (isGrounded || jumpCount < exJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
        }
    }

    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        } else if (Time.time < jumpCoolDown)
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //*****update player's spawn point at checkpoint*****
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log(collision.gameObject.transform.position);
            Debug.Log("Checkpoint reached!");
            respawnPoint = collision.gameObject.transform.position;
        }
    }
}
