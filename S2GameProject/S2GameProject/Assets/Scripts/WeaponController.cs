using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletLimit = 5.0f;  // Normal bullet limit
    private UIManger uIManger;
    private bool canShoot = true;
    private Powerups powerups;

    // Normal and reduced cooldown durations
    private float normalCooldown = 1.2f;
    private float reducedCooldown = 0.4f;

    // Introduce a boosted bullet limit for the duration of the powerup
    private float boostedBulletLimit = 10f; // For example, increase from 5 to 10 bullets

    void Start()
    {
        uIManger = GameObject.Find("UI Manager").GetComponent<UIManger>();
        powerups = GameObject.FindObjectOfType<Powerups>();
    }

    void Update()
    {
        if (uIManger.gameIsOn && canShoot)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                // Determine which bullet limit to use based on powerup state
                bool inReducedCooldownState = (powerups != null && powerups.hasNoCooldown);
                float currentLimit = inReducedCooldownState ? boostedBulletLimit : bulletLimit;

                int bulletCount = GameObject.FindGameObjectsWithTag("Bullet").Length;
                if (bulletCount < currentLimit)
                {
                    Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);

                    // Apply the appropriate cooldown
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

    IEnumerator BulletCooldown(float cooldownTime)
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }
}
