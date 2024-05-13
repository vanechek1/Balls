using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] balls;
    public int[] points;
    public TextMeshProUGUI SumPoints;
    public GameObject obj;
    static public string gripIsFull = "n";
    static public string singleSpaceClick = "n";
    static public Vector2 playerxPos;
    static public Vector2 spawnPos;
    static public string newBall = "n";
    static public int whichBall = 0;
    static public GameObject nextBall;
    public GameObject nextPos;
    static public GameObject timeBall;
    public GameObject effect;
    public GameObject DeathScreen;
    public TextMeshProUGUI scoreD;
    static public string CheckedLose = "n";
    static public string loseCheckForGameOver = "n";
    private void Start()
    {
        //int StartCoins = PlayerPrefs.GetInt("GameCoins");
        //int coins = PlayerPrefs.GetInt("coins");
        //PlayerPrefs.SetInt("GameCoins", coins);

        //SumPoints.text = coins.ToString();
        PlayerPrefs.SetInt("GameCoins", 0);

        loseCheckForGameOver = "n";
        DeathScreen.SetActive(false);
        gripIsFull = "n";
        ShowNextBall();
    }
    void Update()
    {
        SpawnBall();
        replaceFruit();
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < 3.5)
            {
                obj.transform.Translate(transform.right * speed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -3.5)
            {
                obj.transform.Translate(transform.right * speed * Time.deltaTime * (-1));
            }
        }
        //if (!EventSystem.current.IsPointerOverGameObject())
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        Vector3 mouse = new Vector3(Input.GetAxis("Mouse X") * speed * Time.deltaTime, 0, 0);
        //        transform.Translate(mouse * 30f);
        //    }
        //    if (Input.GetMouseButtonUp(0) && spawnedYet == "y")
        //    {
        //        spawnedYet = "n";
        //    }
        //}
        playerxPos = transform.position;

        if (CheckedLose == "y") ShowDeathScreen();
    }
    void SpawnBall()
    {
        
        if (gripIsFull == "n" && singleSpaceClick == "n")
        {
            gripIsFull = "y";
            StartCoroutine(SpawnTimer());
            Debug.Log("Скрипт спавна отработал " +
                "gripIsFull = " + gripIsFull
                + " singleSpaceClick = " + singleSpaceClick);
        }
        
    }
    void replaceFruit()
    {
        if(newBall == "y")
        {
            newBall = "n";
            //SumPoints.text = (int.Parse(SumPoints.text) + points[whichBall]).ToString();
            Instantiate(effect, spawnPos, Quaternion.Euler(0f, 0f, 0f));
            GameObject nb = Instantiate(balls[whichBall+1], spawnPos, Quaternion.Euler(0f, 0f, 0f));
            nb.GetComponent<Rigidbody2D>().gravityScale = 2;

            //int coins = PlayerPrefs.GetInt("coins");
            //PlayerPrefs.SetInt("coins", coins + points[whichBall]);
            //coins = PlayerPrefs.GetInt("coins");
            //SumPoints.text = coins.ToString();
            int OneGameCoins = PlayerPrefs.GetInt("GameCoins");
            PlayerPrefs.SetInt("GameCoins", OneGameCoins + points[whichBall]);
            OneGameCoins = PlayerPrefs.GetInt("GameCoins");
            SumPoints.text = OneGameCoins.ToString();
        }
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(.75f);
        //nextBall.transform.Translate(obj.transform.position);
        nextBall.GetComponent<BallMove>().enabled = true;
        Destroy(timeBall);
        Instantiate(nextBall, obj.transform.position, Quaternion.Euler(0f, 0f, 0f));
       // gripIsFull = "y";
        ShowNextBall();
    }
    void ShowNextBall()
    {
        nextBall = balls[Random.Range(0, 5)];
        nextBall.GetComponent<BallMove>().enabled = false;
        timeBall = Instantiate(nextBall, nextPos.transform.position, Quaternion.Euler(0f, 0f, 0f));

    }

    public void ShowDeathScreen()
    {
        if(loseCheckForGameOver=="n")
        {
            DeathScreen.SetActive(true);
            int coins = PlayerPrefs.GetInt("coins");
            int OneGameCoins = PlayerPrefs.GetInt("GameCoins");
            PlayerPrefs.SetInt("coins", coins + OneGameCoins);
            coins = PlayerPrefs.GetInt("coins");
            SumPoints.text = (coins).ToString();
            scoreD.text = (OneGameCoins).ToString();
            loseCheckForGameOver = "y";
        }
    }


}
