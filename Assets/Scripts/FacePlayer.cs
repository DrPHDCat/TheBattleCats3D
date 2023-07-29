using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public bool faceOtherWay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!faceOtherWay)
        {
            transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }
}
