using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindObjectOfType(typeof(CameraMark))  != null)
        {
            float mouseChange = -Input.GetAxis("Mouse Y") * 3.5f;
            if (mouseChange + transform.eulerAngles.x >= 90 && mouseChange + transform.eulerAngles.x < 180)
            {
                mouseChange = 89.9f - transform.eulerAngles.x;
            }
            if (mouseChange + transform.eulerAngles.x <= 270 && mouseChange + transform.eulerAngles.x > 180)
            {
                mouseChange = -89.9f - transform.eulerAngles.x;
            }
            transform.SetPositionAndRotation(MonoSingleton<CameraMark>.instance.transform.position, Quaternion.Euler(transform.eulerAngles.x + mouseChange, MonoSingleton<CameraMark>.instance.transform.eulerAngles.y - 54, transform.eulerAngles.z));
        }
    }
}
