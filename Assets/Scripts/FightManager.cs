using System.Collections.Generic;
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
    public float catMoney;
    public float catMoneyCap;
    // Start is called before the first frame update
    void Start()
    {
        catMoney = 0;
        catMoneyCap = 16500;
    }

    private void Update()
    {
        if (EnemyWon)
        {
            BattleCanvas.instance.GetComponent<Animator>().SetTrigger("Loss");
        }
        //increase cat money by 10 per second unless at the cap number
        if (catMoney < catMoneyCap) {
            catMoney += 5 * Time.deltaTime;
        }
        // if cat money bigger than cap then make it the same as cap
        if (catMoney > catMoneyCap)
        {
            catMoney = catMoneyCap;
        }
        // if cat money less than 0 then make it 0
        if (catMoney < 0)   {
            catMoney = 0;
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
    public bool BuySomething( int spent)
    {
        if (catMoney >= spent)
        {
            catMoney -= spent;
            return true;
        }
        else
        {
            return false;
        }
    }


}
