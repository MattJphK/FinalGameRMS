using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletLimit = 5.0f;
    private UIManger uIManger;
    private bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        uIManger = GameObject.Find("UI Manager").GetComponent<UIManger>();
    }

    // Update is called once per frame
void Update()
{
    if (uIManger.gameIsOn && canShoot)
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            StartCoroutine(BulletCooldown());
        }
    }
}

IEnumerator BulletCooldown()
{
    canShoot = false;
    yield return new WaitForSeconds(1.2f); // wait 5 seconds
    canShoot = true;
}
    
}
