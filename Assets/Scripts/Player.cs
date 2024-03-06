using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] massObj;
    public GameObject obj;
    private GameObject newObj;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 4.9)
            {
                obj.transform.Translate(transform.right * speed * Time.deltaTime);

            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -4.7)
            {
                obj.transform.Translate(transform.right * speed * Time.deltaTime * (-1));
            }
        }
        //if(Input.GetMouseButton(0))
        //{
        //    Vector3 mouse = new Vector3(Input.GetAxis("Mouse X") * speed * Time.deltaTime, 0, 0);
        //    transform.Translate(mouse * speed * 10);
        //}
        //if(Input.GetMouseButtonUp(0))
        //{
        //    this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //    this.GetComponent<Player>().enabled = false;
        //    this.GetComponent<Player>().obj = null;
        //    SpawnObj();
        //}
    }
    //IEnumerator FlareCountdown()
    //{
    //    yield return new WaitForSeconds(5f);
    //}
    //private void SpawnObj()
    //{
    //    newObj = massObj[Random.Range(0, 5)];
    //    newObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    //    newObj.GetComponent<Player>().enabled = true;
    //    newObj.GetComponent<Player>().obj = newObj;

    //    Instantiate(newObj, transform.position, Quaternion.Euler(0f, 0f, 0f));
    //}
    //private void Start()
    //{
    //    SpawnObj();
    //}

}
