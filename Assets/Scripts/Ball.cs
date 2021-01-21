using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioManager audioManager;
    public TextScript text;
    private bool hasText;
    public int playerScore = 0;
    public int enemyScore = 0;
    public float speed = 1.0f;
    public Rigidbody2D body;
    private void Start()
    {
        hasText = text != null;
        if (body == null)
        {
            Debug.Log("A Rigidbody2D has not been assigned to Ball. Please assign one.");
        }
        else
        {
            ResetBall();
        }
        audioManager = FindObjectOfType<AudioManager>(); // get the audio manager
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "PlayerGoal") // Ball collided with far left wall
        {
            enemyScore++; // increment enemy score
            if (hasText) // update text fields
            {
                text.UpdateEnemyScore(enemyScore);
            }
            ResetBall(); // position the ball at the halfway point
            audioManager.Play("enemyScore"); // play the enemyScore sound through the audio manager
        }
        else if (collision.collider.gameObject.tag == "EnemyGoal") // Ball collided with far right wall
        {
            playerScore++; // increment player score
            if (hasText) // update text fields
            {
                text.UpdatePlayerScore(playerScore);
            }
            ResetBall(); // position the ball at the halfway point
            audioManager.Play("playerScore"); // play the playerScore sound through the audio manager
        }
        else if (collision.collider.gameObject.tag != "Wall") // Ball collided with a paddle
        {
            float paddleWidth = collision.collider.bounds.size.y;
            float collisionPoint = collision.contacts[0].point.y;
            float paddlePos = collision.collider.bounds.center.y; // position of the centerpoint of the paddle

            bool upwards;
            if (paddlePos < collisionPoint) // if the ball hit below the middle of the paddle, it will reflect downwards
            {
                upwards = true;
            }
            else
            {
                upwards = false;
            }
            bool rightwards;
            if (collision.collider.gameObject.tag == "PlayerPaddle") // if the ball hit the player's paddle, it will reflect rightwards
            {
                rightwards = true;
            }
            else
            {
                rightwards = false;
            }

            // if the ball hits the paddle in the center, it will reflect straight forward (0 degree angle)
            // if the ball hits the paddle on the edges, it will reflect at 45 degrees
            float angle = Mathf.Abs(paddlePos - collisionPoint) / (paddleWidth / 2.0f) * 45f; // 45 degrees is the max angle
            angle *= Mathf.Deg2Rad; // convert it to radians

            SetAngle(angle, upwards, rightwards); // set the velocity of the ball at a certain angle
        }
    }

    private void SetAngle(float angle, bool upwards, bool rightwards)
    {
        Vector2 newVelocity;
        newVelocity.y = speed * Mathf.Sin(angle);
        newVelocity.x = speed * Mathf.Cos(angle);
        if (!rightwards)
        {
            newVelocity.x *= -1;
        }
        if (!upwards)
        {
            newVelocity.y *= -1;
        }
        body.velocity = newVelocity;
    }

    private void ResetBall() // reset the ball to a random velocity in a random direction
    {
        Vector2 position = body.position;
        position.x = 0;
        position.y = 0;
        body.position = position;
        SetAngle(Mathf.Deg2Rad * Random.Range(0, 45), Random.Range(0f, 1f) > .5f, Random.Range(0f, 1f) > .5f);
    }

    public void Update() // there is a ball in every scene, so the ball will have the escape condition
    {
        if (Input.GetKey("escape") || Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
