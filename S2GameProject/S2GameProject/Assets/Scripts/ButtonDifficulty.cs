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
        Enemy.speed = 60.0f;
        uIManger = GameObject.Find("UI Manager").GetComponent<UIManger>();
        enemyScript = GameObject.Find("Enemy").GetComponent<Enemy>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

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
