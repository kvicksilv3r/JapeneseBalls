using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugBallCount : MonoBehaviour
{
    public static DebugBallCount Instance;

    int ballcCount = 0;

    public TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddBall()
    {
        ballcCount++;
        textMeshProUGUI.text = ballcCount.ToString();
    }
}
