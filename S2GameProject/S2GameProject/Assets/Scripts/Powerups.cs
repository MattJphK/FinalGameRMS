using System.Collections;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public bool hasNoCooldown = false;
    public float noCooldownDuration = 5f; // lasts 5 seconds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JumpPowerUp"))
        {
            hasNoCooldown = true;
            Destroy(other.gameObject);
            StartCoroutine(NoCooldownTimeLimit());
        }
    }

    IEnumerator NoCooldownTimeLimit()
    {
        yield return new WaitForSeconds(noCooldownDuration);
        hasNoCooldown = false;
    }
}
