using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject obj;

    void Update()
    {
        if(Input.GetKey(KeyCode.D)) // ���� ����� �������� ������� D
        {
            if(transform.position.x < 4.9)
            {
                obj.transform.Translate(transform.right * speed * Time.deltaTime);

            }
            //rb.velocity = new Vector2(speed, rb.velocity.y);
            // velocity - ��������
            // rb.velocity.y - ���������� �������� �� ������
        }
        if(Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -4.7)
            {
                obj.transform.Translate(transform.right * speed * Time.deltaTime * (-1));
            }
            //rb.velocity = new Vector2(-speed, rb.velocity.y);

        }


    }
}
