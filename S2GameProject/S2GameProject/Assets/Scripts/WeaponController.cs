using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletLimit = 3.0f;
    private UIManger uIManger;
    private bool canShoot = true;

    void Start()
    {
        uIManger = GameObject.Find("UI Manager").GetComponent<UIManger>();
    }

    void Update()
    {
        if (uIManger.gameIsOn && canShoot)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                // Count current bullets
                int bulletCount = GameObject.FindGameObjectsWithTag("Bullet").Length;

                // Check if under the limit
                if (bulletCount < bulletLimit)
                {
                    Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                    StartCoroutine(BulletCooldown());
                }
                else
                {
                    Debug.Log("Bullet limit reached. Wait until a bullet is destroyed before firing again.");
                }
            }
        }
    }

    IEnumerator BulletCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(1.2f);
        canShoot = true;
    }
}