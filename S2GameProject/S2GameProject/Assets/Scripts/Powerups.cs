using System.Collections;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public bool hasJPowerUp = false; // Tracks if player currently has the jump power-up
    public float jumpPowerUpMultiplier = 2f; // How much stronger the jump is with the power-up

    // Call this method when the player picks up the jump power-up
    public void ActivateJumpPowerUp(float duration)
    {
        hasJPowerUp = true;
        StartCoroutine(PowerUpTimeLimit(duration));
    }

    private IEnumerator PowerUpTimeLimit(float duration)
    {
        yield return new WaitForSeconds(duration);
        hasJPowerUp = false;
        Debug.Log("PowerUp Gone");
    }
}