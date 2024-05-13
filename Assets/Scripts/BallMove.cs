using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    private string inthemask = "y";
    private string timetocheck = "n";
    private Player odod;
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
 //       Debug.Log(sceneName);
        if(transform.position.y < 3.2)
        {
            inthemask = "n";
            GetComponent<Rigidbody2D>().gravityScale = 2;
        }
    }

    void Update()
    {
        if (inthemask == "y")
        {
            GetComponent<Transform>().position = Player.playerxPos;
        }
        if (true)
        {

            if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && (Player.singleSpaceClick == "n"))
            {

                StartCoroutine(delayBeforeSpawn());

            }
        }
        //if (!EventSystem.current.IsPointerOverGameObject())
        //{
        //    if (Input.GetMouseButtonUp(0))
        //    {
        //        GetComponent<Rigidbody2D>().gravityScale = 2;
        //        inthemask = "n";
        //        //Player.spawnedYet = "n";
        //        StartCoroutine(chkGameOver());
        //    }
        //}

    }
    
    // Сделать отдельным скриптом, чтобы была возможность отключать именно слияние (когда емкость полная, чтобы движущийся в облаке шар не сливался до падения)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag==gameObject.tag)
        {
            StartCoroutine(ForCollision());
        }
    }
    IEnumerator ForCollision()
    {
        yield return new WaitForSeconds(.15f);
        Player.spawnPos = transform.position;
        Player.newBall = "y";
        Player.whichBall = int.Parse(gameObject.tag);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name =="limit" && (timetocheck=="y"))
        {
            Player.CheckedLose = "y";
            Debug.Log("Game Over");
        }
    }
    IEnumerator chkGameOver()
    {
        yield return new WaitForSeconds(.75f);
        timetocheck = "y";
    }
    IEnumerator delayBeforeSpawn()
    {
        Debug.Log("Скрипт пробела отработал " +
                "gripIsFull = " + Player.gripIsFull
                + " singleSpaceClick = " + Player.singleSpaceClick);
        Player.singleSpaceClick = "y";
        Player.gripIsFull = "n";
        Debug.Log("Параметры пробела изменены " +
                "gripIsFull = " + Player.gripIsFull
                + " singleSpaceClick = " + Player.singleSpaceClick);

        GetComponent<Rigidbody2D>().gravityScale = 3;
        inthemask = "n";
        StartCoroutine(chkGameOver());
        yield return new WaitForSeconds(.7f);
        Player.singleSpaceClick = "n";
        Debug.Log("Можно нажимать снова " +
                "gripIsFull = " + Player.gripIsFull
                + " singleSpaceClick = " + Player.singleSpaceClick);
    }
}
