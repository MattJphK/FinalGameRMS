using System.Collections;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public bool hasJPowerUp = false;
    public float powerUpDuration = 9f;

    // This method is called by PlayerController when the player has a jump power-up and space is pressed
    public void SuperJump(Rigidbody bearRb, float baseJumpForce)
    {
        // Apply double jump force
        bearRb.AddForce(Vector3.up * baseJumpForce * 2, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JumpPowerUp"))
        {
            hasJPowerUp = true;
            Destroy(other.gameObject);
            Debug.Log("HasJPUP");
            StartCoroutine(PowerUpTimeLimit());
        }
    }

    IEnumerator PowerUpTimeLimit()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasJPowerUp = false;
        Debug.Log("PowerUp Gone");
    }
}
