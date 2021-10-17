using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    public float xInitialForce;
    public float yInitialForce;

    //==========For debug==========
    private Vector2 trajectoryOrigin;

    private void ResetBall()
    {
        transform.position = Vector2.zero;
        rigidBody2D.velocity = Vector2.zero;
    }

    private void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        
        //[0, 1]
        float randomDirection = Random.Range(0, 2);

        if (randomDirection < 1.0f)
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce).normalized, ForceMode2D.Impulse);
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce).normalized, ForceMode2D.Impulse);
        }
    }
    private void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);
    }

    private void Start()
    {
        //==========For debug==========
        trajectoryOrigin = transform.position;
        //====================

        rigidBody2D = GetComponent<Rigidbody2D>();

        RestartGame();
    }

    //==========For debug==========
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
