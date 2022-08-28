using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
            rb.velocity = new Vector3(0, 7f, 0);
        }
        if (Input.GetButtonUp("Jump"))
        {
            rb.velocity = new Vector3(0, -2f, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            Debug.Log("You died!");
            transform.position = respawnPoint;
        } else if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log(collision.gameObject.transform.position);
            Debug.Log("Checkpoint reached!");
            respawnPoint = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log(collision.gameObject.transform.position);
            Debug.Log("Checkpoint reached!");
            respawnPoint = collision.gameObject.transform.position;
        }
    }
}
