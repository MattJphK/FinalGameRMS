using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody bearRb; // Player's rigidbody
    public float JumpForce; // Base jump force
    public float gravityModifier;
    public bool standing; // Tells us if player is on the ground
    public float movePlayer;
    public float moveSpeed = 15.0f;
    public GameObject bear;

    // Remove hasJPowerUp and related methods since they will be moved to Powerups.cs
    // public bool hasJPowerUp; // Removed

    private UIManger uIManger;
    private Powerups powerups;

    void Start()
    {
        uIManger = GameObject.Find("UI Manager").GetComponent<UIManger>();
        bearRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        // Get reference to the Powerups component
        powerups = GetComponent<Powerups>();

        PlayerStartPos();
    }

    void Update()
    {
        PlayerMoveset();

        // Jumps when space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && standing)
        {
            Jump();

            // If we have a jump power-up active, use it
            if (powerups != null && powerups.hasJPowerUp)
            {
                // Call the SuperJump method from Powerups, passing in required references
                powerups.SuperJump(bearRb, JumpForce);
            }
        }

        // Stop player from going off screen
        if (transform.position.x < -135)
        {
            transform.position = new Vector3(-135, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 223)
        {
            transform.position = new Vector3(223, transform.position.y, transform.position.z);
        }

        // Limit the player's height
        if (transform.position.y > 55)
        {
            transform.position = new Vector3(transform.position.x, 55, transform.position.z);

            // Stop upward movement
            bearRb.velocity = new Vector3(bearRb.velocity.x, 0, bearRb.velocity.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        standing = true;
    }

    void PlayerStartPos()
    {
        if (uIManger.gameIsOn)
        {
            bear.transform.position = new Vector3(-102, 1, -22);
        }
    }

    private void PlayerMoveset()
    {
        movePlayer = Input.GetAxis("Horizontal");
        Vector3 moveForward = Vector3.right * movePlayer * Time.deltaTime * moveSpeed;
        moveForward.z = 0;
        transform.Translate(moveForward, Space.World);
        TurnPlayer();
    }

    private void TurnPlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    private void Jump()
    {
        bearRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        standing = false;
    }

    // SuperJump is removed from here and placed in Powerups.cs
    // PowerUpTimeLimit and OnTriggerEnter related to JumpPowerUp also moved to Powerups.cs
}
