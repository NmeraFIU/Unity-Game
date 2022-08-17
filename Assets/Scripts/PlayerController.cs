using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float speed = 3.0f;

    float horizontal;
    float vertical;

    Vector2 movement;
    Vector2 lookDirection = new Vector2(1, 0);

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //talk to NPC
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    Debug.Log("Inside if statement");
                    character.DisplayDialog();
                }
            }
        }
    }

    void FixedUpdate()
    {
        rigidbody2d.MovePosition(rigidbody2d.position + movement * speed * Time.fixedDeltaTime);
    }
}