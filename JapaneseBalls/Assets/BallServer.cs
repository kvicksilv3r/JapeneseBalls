using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallServer : MonoBehaviour
{
    [SerializeField]
    private List<BallListEntry> ballList = new List<BallListEntry>();

    [SerializeField]
    public List<BallType> availableTypes = new List<BallType>();

    public static BallServer instance;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public GameObject RequestBall()
    {
        return ReturnTotallyRandomBall();
    }

    private GameObject ReturnTotallyRandomBall()
    {
        return ballList[Random.Range(0, ballList.Count)].ball;
    }
}
