using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatMoneyDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // sets the component text of the object to say the amount of money and the limit of the money located in FightManager's instance, rounding them up to the nearest whole number to make them look nice
        GetComponent<Text>().text = Mathf.Round(FightManager.instance.catMoney) + "/" + Mathf.Round(FightManager.instance.catMoneyCap);
}
}