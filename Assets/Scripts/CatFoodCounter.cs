using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFoodCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerPrefs.HasKey("CatFood") || PlayerPrefs.GetInt("CatFood") < 0)
        {
            PlayerPrefs.SetInt("CatFood", 0);
        }
        GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetInt("CatFood").ToString();
    }
}
