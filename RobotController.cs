using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RobotController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("hHorizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

    }
}
