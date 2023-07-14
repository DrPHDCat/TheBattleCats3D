using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NormalCatUnits
{
    AxeCat,
    Cat,
    TankCat,
    TitanCat
}

public class CatFetcher
{
    static public GameObject GetCatById(NormalCatUnits CatType)
    {   
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Cats/" + CatType.ToString());
        prefab.GetComponentInChildren<Enemy>().singletargetdamage *= 1 + (PlayerPrefs.GetInt(CatType.ToString() + "Level") * 0.20f);
        prefab.GetComponentInChildren<Enemy>().maxHealth *= 1 + (PlayerPrefs.GetInt(CatType.ToString() + "Level") * 0.20f);
        if (prefab.GetComponentInChildren<Hitter>())
            {
                prefab.GetComponentInChildren<Hitter>().damage *= 1 + (PlayerPrefs.GetInt(CatType.ToString() + "Level") * 0.20f);
            }
        return prefab;
    }
}
