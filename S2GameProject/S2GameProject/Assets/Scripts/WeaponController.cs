using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletLimit = 5.0f;
    private UIManger uIManger;
    private bool canShoot = true;
    private Powerups powerups;

    // Normal and reduced cooldown durations
    private float normalCooldown = 1.2f;
    private float reducedCooldown = 0.2f;

    void Start()
    {
        uIManger = GameObject.Find("UI Manager").GetComponent<UIManger>();
        powerups = GameObject.FindObjectOfType<Powerups>();
    }

    void Update()
    {
        if (uIManger.gameIsOn && canShoot)
        {
            // Check if we're in the reduced cooldown state
            bool inReducedCooldownState = (powerups != null && powerups.hasNoCooldown);

            if (Input.GetKeyDown(KeyCode.X))
            {
                int bulletCount = GameObject.FindGameObjectsWithTag("Bullet").Length;

                // No bullet limit changes made, just as before
                if (bulletCount < bulletLimit)
                {
                    Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);

                    // Apply reduced cooldown if hasNoCooldown is true, otherwise normal cooldown
                    float currentCooldown = inReducedCooldownState ? reducedCooldown : normalCooldown;
                    StartCoroutine(BulletCooldown(currentCooldown));
                }
                else
                {
                    Debug.Log("Bullet limit reached. Wait until a bullet is destroyed.");
                }
            }
        }
    }

    // Adjusted BulletCooldown to accept a duration parameter so we can set different cooldowns easily
    IEnumerator BulletCooldown(float cooldownTime)
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }
}
