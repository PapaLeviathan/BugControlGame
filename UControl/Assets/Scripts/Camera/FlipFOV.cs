using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFOV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Camera.HorizontalToVerticalFieldOfView(140,1080);
            Debug.Log("Flipped cam");
        }
    }
}
