using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class CreateObj : MonoBehaviour
{
    public GameObject[] obj;
    static private GameObject newObj;
    public GameObject prnt;
    private void Update()
    {
        //GameObject objNext = obj[Random.Range(0, 5)]; 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            newObj = newO();

            newObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            newObj.GetComponent<Player>().obj = null;
            newObj.GetComponent<Player>().enabled = false;
        }

    }

    private GameObject newO()
    {
        newObj = obj[Random.Range(0, 5)];
        newObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        newObj.GetComponent<Player>().enabled = true;
        newObj.GetComponent<Player>().obj = newObj;

        Instantiate(newObj, transform.position, Quaternion.Euler(0f, 0f, 0f));
        return newObj;
    }
    private void Start()
    {
        newO();
    }

}
