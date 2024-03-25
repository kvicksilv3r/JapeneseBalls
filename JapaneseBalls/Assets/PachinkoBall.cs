using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PachinkoBall : MonoBehaviour
{
    protected float baseValue = 0f;
    protected float currentValue = 0f;

    protected bool canCollideWithOtherBall = false;

    protected void CheckOutOfBounds()
    {
        if (transform.position.y < -6)
        {
            KillBall();
        }
    }

    private void Update()
    {
        CheckOutOfBounds();
        //CheckStaleBall();  
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
        gameObject.SetActive(false);
    }
}
