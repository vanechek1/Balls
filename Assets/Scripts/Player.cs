using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] balls;
    public GameObject obj;
    static public string spawnedYet = "n";
    static public Vector2 playerxPos;
    static public Vector2 spawnPos;
    static public string newBall = "n";
    static public int whichBall = 0;
    static public GameObject nextBall;
    public GameObject nextPos;
    static public GameObject timeBall;
    private void Start()
    {
        ShowNextBall();
    }

    void Update()
    {
        SpawnBall();
        replaceFruit();
        //if(Input.GetKey(KeyCode.D))
        //{
        //    if(transform.position.x < 4.9)
        //    {
        //        obj.transform.Translate(transform.right * speed * Time.deltaTime);
        //    }
        //}
        //if(Input.GetKey(KeyCode.A))
        //{
        //    if (transform.position.x > -4.7)
        //    {
        //        obj.transform.Translate(transform.right * speed * Time.deltaTime * (-1));
        //    }
        //}
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = new Vector3(Input.GetAxis("Mouse X") * speed * Time.deltaTime, 0, 0);
            transform.Translate(mouse * speed * 10);
        }
        playerxPos = transform.position;
    }
    void SpawnBall()
    {
        if(spawnedYet == "n")
        {
            StartCoroutine(SpawnTimer());
            spawnedYet = "y";
        }
    }
    void replaceFruit()
    {
        if(newBall == "y")
        {
            newBall = "n";
            Instantiate(balls[whichBall+1], spawnPos, Quaternion.Euler(0f, 0f, 0f));
        }
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(.75f);
        //nextBall.transform.Translate(obj.transform.position);
        nextBall.GetComponent<BallMove>().enabled = true;
        Destroy(timeBall);
        Instantiate(nextBall, obj.transform.position, Quaternion.Euler(0f, 0f, 0f));
        ShowNextBall();
    }
    void ShowNextBall()
    {
        nextBall = balls[Random.Range(0, 5)];
        nextBall.GetComponent<BallMove>().enabled = false;
        timeBall = Instantiate(nextBall, nextPos.transform.position, Quaternion.Euler(0f, 0f, 0f));
    }
}
