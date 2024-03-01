using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CollisionObj : MonoBehaviour
{
    public GameObject obj;
    public GameObject newObj;

    bool chbl = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(obj.tag == collision.gameObject.tag && !chbl)
        {
            Debug.Log(obj.tag + " dd " + collision.gameObject.tag);
            Instantiate(newObj, transform.position, Quaternion.Euler(0f, 0f, 0f));

            Destroy(collision.gameObject);
            Destroy(obj);

            chbl = true;

        }
    }
    
}
