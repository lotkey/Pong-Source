using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPaddle : MonoBehaviour
{
    public Ball ball; // for tracking
    public Rigidbody2D body;
    public float posFromBall;
    public float scanDistance = 3.0f;
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Vector2 distance = body.position - ball.body.position;
        posFromBall = distance.x;
        if (posFromBall < scanDistance) // if the ball is within scanning distance...
        {
            // move towards it at a set speed
            bool isAbove = ball.body.position.y > body.position.y;
            Vector2 velocity;
            velocity.x = 0;
            if (isAbove)
            {
                velocity.y = speed;
            }
            else
            {
                velocity.y = -speed;
            }
            body.velocity = velocity;
        }
        else
        {
            Vector2 velocity = body.velocity;
            velocity.y = 0;
            body.velocity = velocity;
        }
    }
}
