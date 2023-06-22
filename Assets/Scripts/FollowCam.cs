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
        if (GameObject.FindObjectOfType(typeof(CameraMark)) != null)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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
        else
        {
            
            if (Input.GetMouseButton(1))
            {
                float speed = 1;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = 3;
                }
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                float mouseChange = -Input.GetAxis("Mouse Y") * 3.5f;
                if (mouseChange + transform.eulerAngles.x >= 90 && mouseChange + transform.eulerAngles.x < 180)
               {
                mouseChange = 89.9f - transform.eulerAngles.x;
               }
               if (mouseChange + transform.eulerAngles.x <= 270 && mouseChange + transform.eulerAngles.x > 180)
               {
                    mouseChange = -89.9f - transform.eulerAngles.x;
               }
               transform.rotation = Quaternion.Euler(transform.eulerAngles.x + mouseChange, transform.eulerAngles.y, transform.eulerAngles.z);
               transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + Input.GetAxis("Mouse X") * 3.5f, transform.eulerAngles.z);
               if (Input.GetKey(KeyCode.W))
               {
                   transform.position += transform.forward * Time.deltaTime * 10 * speed;
               }
               if (Input.GetKey(KeyCode.S))
               {
                   transform.position -= transform.forward * Time.deltaTime * 10 * speed;
               }
               if (Input.GetKey(KeyCode.A))
               {
                   transform.position -= transform.right * Time.deltaTime * 10 * speed;
               }
               if (Input.GetKey(KeyCode.D))
               {
                   transform.position += transform.right * Time.deltaTime * 10 * speed;
               }
            }
            else 
            {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            }
            
        }
    }
}
