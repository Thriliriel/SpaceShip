using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject scoreObject;
    public GameObject gameOverObject;
    private int score = 0;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroid(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function which is called every x seconds
    IEnumerator SpawnAsteroid(int x)
    {
        //while the game is running
        while (!gameOver)
        {
            //wait for x seconds
            yield return new WaitForSeconds(x);
            //code here will execute after x seconds
            CreateAsteroid();
        }
    }

    //create an asteroid
    private void CreateAsteroid()
    {
        Instantiate(asteroidPrefab);
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreObject.GetComponent<Text>().text = score.ToString();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverObject.SetActive(true);
    }
}
