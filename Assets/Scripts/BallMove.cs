using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallMove : MonoBehaviour
{
    private string inthemask = "y";
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
        //if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    GetComponent<Rigidbody2D>().gravityScale = 2;
        //    inthemask = "n";
        //    Player.spawnedYet = "n";
        //}
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonUp(0))
            {
                GetComponent<Rigidbody2D>().gravityScale = 2;
                inthemask = "n";
                //Player.spawnedYet = "n";
            }
        }

    }
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
}
