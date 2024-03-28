using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEjector : MonoBehaviour
{
    [SerializeField]
    private Transform ejectLocation;

    [SerializeField]
    private float LaunchForce = 100f;

    [SerializeField]
    private float forceVariation = 0.01f;

    public bool fullAuto = false;

    private void Update()
    {
        if (fullAuto && Input.GetKey(KeyCode.Space))
        {
            EjectBall();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            EjectBall();
        }
    }

    public void EjectBall()
    {
        var ball = BallServer.instance.RequestBall();
        var spawnedBall = SpawnBall(ball);
        LaunchBall(spawnedBall);
    }

    private GameObject SpawnBall(GameObject ball)
    {
        return Instantiate(ball, ejectLocation.position, Quaternion.identity);
    }

    private void LaunchBall(GameObject ball)
    {
        var force = LaunchForce * Random.Range(1 - forceVariation, 1 + forceVariation);
        ball.GetComponent<PachinkoBall>().BallRb.AddForce(ejectLocation.up * force);

        //debugpiss
        DebugBallCount.Instance.AddBall();
    }

    private void OnDrawGizmos()
    {
        if (ejectLocation == null)
        {
            return;
        }

        Gizmos.color = Color.magenta;

        Gizmos.DrawLine(ejectLocation.position, ejectLocation.position + ejectLocation.up);

        var from = ejectLocation.position + ejectLocation.up;
        Gizmos.DrawLine(from, ejectLocation.position + (ejectLocation.up / 2) + (ejectLocation.right / 3));
        Gizmos.DrawLine(from, ejectLocation.position + (ejectLocation.up / 2) - (ejectLocation.right / 3));
    }
}
