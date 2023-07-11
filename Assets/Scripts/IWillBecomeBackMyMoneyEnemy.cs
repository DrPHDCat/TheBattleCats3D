using UnityEngine;

public class IWillBecomeBackMyMoneyEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DestroyCheck()
    {
        transform.GetChild(0).GetComponent<Enemy>().DestroyCheck();
    }
}
