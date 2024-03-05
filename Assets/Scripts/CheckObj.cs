using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckObj : MonoBehaviour
{
    public Rigidbody2D rb;
    private void Update()
    {
        Vector2 vel = rb.velocity;
        float speed = vel.magnitude;
        if (speed < 0.1f && rb.transform.position.y > 3.27 + rb.transform.localScale.y/2)
        {
            Debug.Log("Game end");
        }
    }

}
