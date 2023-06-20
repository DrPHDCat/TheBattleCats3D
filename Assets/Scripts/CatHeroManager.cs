using System;
using UnityEngine;

public enum CatHeroType
{
    SwordCat,
    Valkyrie
}

public static class CatHeroManager
{
    private const string CatHeroesPath = "Prefabs/CatHeroes/";
    public static GameObject GetCatHero(CatHeroType type)
    {
        string prefabPath = CatHeroesPath + type.ToString();
        Debug.Log(prefabPath);
        GameObject prefab = Resources.Load<GameObject>(prefabPath);

        if (prefab == null)
        {
            Debug.LogError($"Failed to load prefab for cat type: {type}");
            return null;
        }

        return prefab;
    }
}