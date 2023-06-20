using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FightManager : MonoSingleton<FightManager>
{
    public CatBase PlayerBase;
    public CatBase EnemyBase;
    public List<Enemy> PlayerUnits;
    public List<Enemy> EnemyUnits;
    public bool FightEnded;
    public bool EnemyWon;
    public bool PlayerWon;
    public GameObject CatHero;
    public GameObject deathEffect;
    public float posBoundX;
    public float negBoundX;
    public float posBoundZ;
    public float negBoundZ;
    public CatHeroType CatHeroType;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (EnemyWon)
        {
            BattleCanvas.instance.GetComponent<Animator>().SetTrigger("Loss");
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (CatHero != null)

        {
            if (CatHero.transform.position.z > posBoundZ)
            {
                CatHero.transform.position = new Vector3(CatHero.transform.position.x, CatHero.transform.position.y, posBoundZ);
            }
            if (CatHero.transform.position.z < negBoundZ)
            {
                CatHero.transform.position = new Vector3(CatHero.transform.position.x, CatHero.transform.position.y, negBoundZ);
            }
            if (CatHero.transform.position.x > posBoundX)
            {
                CatHero.transform.position = new Vector3(posBoundX, CatHero.transform.position.y, CatHero.transform.position.z);
            }
            if (CatHero.transform.position.x < negBoundX)
            {
                CatHero.transform.position = new Vector3(negBoundX, CatHero.transform.position.y, CatHero.transform.position.z);
            }
        }

    }
}
