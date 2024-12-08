using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletLimit = 5.0f;
    private UIManger uIManger;
    // Start is called before the first frame update
    void Start()
    {
        uIManger = GameObject.Find("UI Manager").GetComponent<UIManger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(uIManger.gameIsOn){
            bulletLimit = bulletLimit - 0.1f;
            if(Input.GetKeyDown(KeyCode.X) && bulletLimit <= 0.0f)//gets the x key input to fire bullets
            {
                Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                bulletLimit = 5.0f;
            }

        }

    }
    
}
