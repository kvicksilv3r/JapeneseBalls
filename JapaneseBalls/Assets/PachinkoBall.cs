using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallType
{
    None,
    Vanilla
}

public class PachinkoBall : MonoBehaviour
{
    private static string BALL_COLLISION_LAYER = "BallCollision";
    private static int BALL_KILL_HEIGHT = -10;

    [SerializeField]
    protected float baseValue = 0f;
    protected float currentValue = 0f;
    protected float pickWeight = 0f;

    [SerializeField]
    protected BallType ballType;

    private Rigidbody2D ballRb;

    [SerializeField]
    protected bool canCollideWithOtherBall = false;

    public Rigidbody2D BallRb { get => ballRb; set => ballRb = value; }

    protected virtual void Awake()
    {
        if (!ballRb)
        {
            ballRb = GetComponentInChildren<Rigidbody2D>();
        }

        if (canCollideWithOtherBall)
        {
            gameObject.layer = LayerMask.NameToLayer(BALL_COLLISION_LAYER);
        }
    }

    protected virtual void Update()
    {
        CheckOutOfBounds();
        //CheckStaleBall();  
    }

    protected void CheckOutOfBounds()
    {
        if (transform.position.y < BALL_KILL_HEIGHT)
        {
            KillBall();
        }
    }

    protected void CheckStaleBall()
    {
        //If ball no movement for a while, kill ball
    }

    protected void KillBall()
    {
        //Handle remove ball
        Collected();
    }

    internal void Collected()
    {
        //Handle controlled destruction
        Destroy(gameObject);
    }
}
