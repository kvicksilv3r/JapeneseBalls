using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCollector : MonoBehaviour
{
    private string balltag = "Pachinko";

    int ballsCaught = 0;
    public TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(balltag))
        {
            ballsCaught++;
            textMeshProUGUI.text = ballsCaught.ToString();
            collision.GetComponent<PachinkoBall>().Collected();
        }
    }
}
