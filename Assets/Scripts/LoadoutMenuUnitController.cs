using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadoutMenuUnitController : MonoBehaviour
{
    public GameObject unitBox;
    public GameObject raritySwapButton;
    // Start is called before the first frame update
    void Start()
    {
        //set unit levels to 1 to unlock
        PlayerPrefs.SetInt("CatLevel", 1);
        PlayerPrefs.SetInt("AxeCatLevel", 1);
        //tankcat
        //PlayerPrefs.SetInt("TankCatLevel", 1);
        for (int i = 0; i < Enum.GetNames(typeof(NormalCatUnits)).Length; i++)
        {
            if (PlayerPrefs.HasKey(Enum.GetNames(typeof(NormalCatUnits))[i] + "Level") && PlayerPrefs.GetInt(Enum.GetNames(typeof(NormalCatUnits))[i] + "Level") > 0)
            {
                GameObject box = Instantiate(unitBox, transform);
                box.transform.GetChild(4).GetComponent<UnityEngine.UI.Text>().text = CatFetcher.GetCatById((NormalCatUnits)Enum.Parse(typeof(NormalCatUnits), Enum.GetNames(typeof(NormalCatUnits))[i])).GetComponent<Enemy>().unitName;
                box.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = CatFetcher.GetCatById((NormalCatUnits)Enum.Parse(typeof(NormalCatUnits), Enum.GetNames(typeof(NormalCatUnits))[i])).GetComponent<Enemy>().portrait;
                box.transform.GetChild(3).GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetInt(Enum.GetNames(typeof(NormalCatUnits))[i] + "Level").ToString();
                box.transform.GetChild(2).GetComponent<UnityEngine.UI.Text>().text = CatFetcher.GetCatById((NormalCatUnits)Enum.Parse(typeof(NormalCatUnits), Enum.GetNames(typeof(NormalCatUnits))[i])).GetComponent<Enemy>().cost.ToString();
            }
        }
    }

}
