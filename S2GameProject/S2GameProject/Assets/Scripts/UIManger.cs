using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManger : MonoBehaviour
{
    public TextMeshProUGUI killText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public GameObject titleScreen;
    public Button resetButton;
    public bool gameIsOn = false;
    public int totalKills;
    // Start is called before the first frame update
    public void GameStart(int difficulty)
    {
        if(difficulty > 0){
            Enemy.speed = Enemy.speed * difficulty;
        }
        else{
            Enemy.speed = 40.0f;
        }
        gameIsOn = true;
        //StartCoroutine(SpawnTarget());
        totalKills = 0;
        UpdateKill(0);
        titleScreen.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
       
    }


    public void UpdateKill(int totalKills)
    {
        totalKills += 1;
        killText.text = "KILLS: " + totalKills;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Victory()
    {
        winText.gameObject.SetActive(true);
    }
}
