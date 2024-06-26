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
    private string wasClicked = "n";
    void Start()
    {
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
            if (Input.GetKeyDown(KeyCode.Space) && wasClicked == "n")
            {
                wasClicked = "y";
                GetComponent<Rigidbody2D>().gravityScale = 2;
                inthemask = "n";
                StartCoroutine(chkGameOver());
                Invoke("delay", 1f);
                
               // Player.readyForSpawn = "n";
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
     //   Debug.Log("wasClicked = " + wasClicked);
    }
    
    // ������� ��������� ��������, ����� ���� ����������� ��������� ������ ������� (����� ������� ������, ����� ���������� � ������ ��� �� �������� �� �������)
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

    void delay()
    {
        wasClicked = "n";
    }
}
