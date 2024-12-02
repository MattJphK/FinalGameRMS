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
    public Button resetButton;
    public Button winButton;//set because using the same button caused errors
    // Start is called before the first frame update
    void Start()
    {

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

    public void ResetWinGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Victory()
    {
        winText.gameObject.SetActive(true);
        winButton.gameObject.SetActive(true);
    }
}
