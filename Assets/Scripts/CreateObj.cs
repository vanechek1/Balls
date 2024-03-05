using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObj : MonoBehaviour
{
    public GameObject[] obj;
    private GameObject newObj;

    private void Update()
    {
        //GameObject objNext = obj[Random.Range(0, 5)]; 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            newObj = obj[Random.Range(0, 5)];
            Instantiate(newObj, transform.position, Quaternion.Euler(0f, 0f, 0f));
        }
    }
}
