using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public Ball ball;
    public Rigidbody2D body;
    public TextScript text;
    public bool drBCmode = false;
    private void Start()
    {
        if (body == null)
        {
            Debug.Log("No Rigidbody2D was assigned to the PlayerPaddle. Please assign one.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (drBCmode)
        {
            if ((ball.body.position - body.position).x < 1) // track the ball if it is within the tracking distance
            {
                Vector2 position = body.position;
                position.y = ball.body.position.y;
                body.position = position;
            }
            else
            {
                Vector2 position = Input.mousePosition;
                position = Camera.main.ScreenToWorldPoint(position);
                position.x = body.position.x;
                body.position = position;
            }
        }
        else // otherwise, follow the mouse
        {
            Vector2 position = Input.mousePosition;
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = body.position.x;
            body.position = position;
        }
    }
}
