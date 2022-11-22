using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoToMouse : MonoBehaviour
{
    Rigidbody2D RB;
    [SerializeField] Transform PlayerBod;
    [SerializeField] float speed = 5;
    Vector2 MoveDir;


    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        MoveDir.x = speed;
    }
    void Update()
    {
        PlayerBod.rotation = Quaternion.Euler(0, 0, -RB.velocity.x * 0.5f);
    }


    void FixedUpdate()
    {
        if (transform.position.x <= Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            RB.AddForce(MoveDir * 6, ForceMode2D.Force);
        }

        if (transform.position.x >= Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            RB.AddForce(-MoveDir * 6, ForceMode2D.Force);
        }
    }

}
