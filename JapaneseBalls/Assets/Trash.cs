using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameObject pachinko;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(pachinko, MousePos(), Quaternion.identity);
        }
    }

    private Vector3 MousePos()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // zero z
        return mouseWorldPos;
    }
}
