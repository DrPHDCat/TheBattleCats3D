using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfCompleted : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("CompletedAmongUsInvasion") != 1)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
