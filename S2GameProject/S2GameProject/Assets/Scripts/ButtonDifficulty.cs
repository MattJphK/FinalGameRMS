using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDifficulty : MonoBehaviour
{
    private Button button;
    private UIManger uIManger;
    private Enemy enemyScript;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        uIManger = GameObject.Find("UI Manager").GetComponent<UIManger>();
        enemyScript = GameObject.Find("Enemy").GetComponent<Enemy>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        if(difficulty == 0){
            Enemy.speed = 40.0f;

        }
        else if(difficulty == 1){
            Enemy.speed = Enemy.speed * 2;
        }
        else if(difficulty == 2){
            Enemy.speed = Enemy.speed * 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        uIManger.GameStart(difficulty);
    }
}
