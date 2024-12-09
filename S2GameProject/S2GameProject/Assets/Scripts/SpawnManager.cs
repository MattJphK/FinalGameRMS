using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject jumpPowerUpPrefab;
    public GameObject bearPlayer;
    private float spawnMinX = 50;
    private float spawnMaxX = 200;
    private float spawnZ = -22; 
    public int enemyNum;//keeps track of the enemies currently in the game
    public int powerUpNum;//keeps track of the enemies currently in the game
    public int enemiesToBeSpawned;//set the amount spawned at a time
    public bool stopSpawn;//stops everything from spawning when you win
    private UIManger uIManger;


    
   

    // Start is called before the first frame update
    void Start()
    {  
       uIManger = GameObject.Find("UI Manager").GetComponent<UIManger>();
       stopSpawn = false; 
    }

    // Update is called once per frame
    void Update()
    {
        enemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        powerUpNum = GameObject.FindGameObjectsWithTag("JumpPowerUp").Length;

        if(enemyNum == 0 && stopSpawn == false)
        {
            SpawnEnemies(enemiesToBeSpawned);
            enemiesToBeSpawned = enemiesToBeSpawned + 2;
        }

        if(powerUpNum == 0 && stopSpawn == false)
        {
            SpawnPowerUp();
        }

        if(Enemy.enemiesKilled == 10)
        {
            stopSpawn = true;
            Debug.Log("YOU WIN!!!");
        }
        
    }

    Vector3 GenerateSpawnPosition(bool fromLeft)
    {
        float xPos = fromLeft ? -Random.Range(spawnMinX, spawnMaxX) : Random.Range(spawnMinX, spawnMaxX);
        return new Vector3(xPos, 0, spawnZ);
    }

    Vector3 GeneratePowerUpSpawnPosition()
    {
        float xPos = Random.Range(spawnMinX, spawnMaxX);
        return new Vector3(xPos, 37, spawnZ);
    }

    void SpawnEnemies(int enemiesToBeSpawned)
{
    if(uIManger.gameIsOn)
    {
        for(int i = 0; i < enemiesToBeSpawned; i++)
        {
            bool fromLeft = (i % 2 == 0); // Alternate spawn side
            GameObject newEnemy = Instantiate(enemyPrefab, GenerateSpawnPosition(fromLeft), enemyPrefab.transform.rotation);

            // If coming from the left, rotate the enemy to face right
            if (fromLeft)
            {
                newEnemy.transform.rotation = Quaternion.Euler(0, 90f, 0);
            }
            else
            {
                // If coming from the right, rotate it to face left
                newEnemy.transform.rotation = Quaternion.Euler(0, -90f, 0);
            }
        }
    }
}


    void SpawnPowerUp()
    {
        
        Instantiate(jumpPowerUpPrefab, GeneratePowerUpSpawnPosition(), jumpPowerUpPrefab.transform.rotation);
        
    }


}
