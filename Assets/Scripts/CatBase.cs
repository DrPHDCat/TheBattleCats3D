using System.Collections.Generic;
using UnityEngine;

public class CatBase : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool enemy;
    public AudioClip victoryClip;
    public List<GameObject> enemyList;
    public List<float> spawntimeList;
    public List<float> percentageList;
    public List<bool> bossWaveList;
    public float time;
    public GameObject bossWave;
    public AudioClip bossClip;
    // Start is called before the first frame update
    void Start()
    {
        if (!enemy)
        {
            FightManager.instance.PlayerBase = this;
        }
        else
        {
            FightManager.instance.EnemyBase = this;
        }
        time = 0;

    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<UnityEngine.UI.Text>().text = Mathf.Round(health) + " / " + maxHealth;
        time += Time.deltaTime;
        if (enemy)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i] != null && spawntimeList[i] <= time && !FightManager.instance.FightEnded)
                {
                    GameObject latestEnemy = Instantiate<GameObject>(enemyList[i], transform.position + -transform.right * 3, Quaternion.identity);
                    if (bossWaveList[i])
                    {
                        Instantiate<GameObject>(bossWave, transform.position + -transform.right * 3, Quaternion.identity);
                        if (Camera.main.GetComponent<AudioSource>().clip != bossClip)
                        {
                            Camera.main.GetComponent<AudioSource>().clip = bossClip;
                            Camera.main.GetComponent<AudioSource>().Play();
                        }
                    }
                    if (latestEnemy.GetComponentInChildren<Enemy>())
                    {
                        latestEnemy.GetComponentInChildren<Enemy>().maxHealth *= percentageList[i] / 100;
                        latestEnemy.GetComponentInChildren<Enemy>().netWorth *= percentageList[i] / 100;
                        latestEnemy.GetComponentInChildren<Enemy>().singletargetdamage *= percentageList[i] / 100;
                    }
                    if (latestEnemy.GetComponentInChildren<Hitter>())
                    {
                        latestEnemy.GetComponentInChildren<Hitter>().damage *= percentageList[i] / 100;
                    }

                    enemyList.Remove(enemyList[i]);
                    spawntimeList.Remove(spawntimeList[i]);
                    percentageList.Remove(percentageList[i]);
                    bossWaveList.Remove(bossWaveList[i]);
                }
            }
        }
    }
    public void TakeDamage(float damage)
    {
        if (!FightManager.instance.FightEnded)
        {
            GetComponent<AudioSource>().Play();
        }
        if (health > 0)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
            }
        }

        if (health <= 0 && !FightManager.instance.FightEnded)
        {
            health = 0;
            Camera.main.gameObject.GetComponent<AudioSource>().playOnAwake = false;
            Camera.main.gameObject.GetComponent<AudioSource>().clip = victoryClip;
            Camera.main.gameObject.GetComponent<AudioSource>().loop = false;
            Camera.main.gameObject.GetComponent<AudioSource>().Play();
            FightManager.instance.FightEnded = true;
            if (enemy)
            {
                FightManager.instance.PlayerWon = true;
                for (int i = 0; i < FightManager.instance.EnemyUnits.Count; i++)
                {
                    FightManager.instance.EnemyUnits[i].TakeDamage(99999999);
                }
            }
            if (!enemy)
            {
                FightManager.instance.EnemyWon = true;
                for (int i = 0; i < FightManager.instance.PlayerUnits.Count; i++)
                {
                    FightManager.instance.PlayerUnits[i].health = 0;
                    FightManager.instance.PlayerUnits[i].DestroyCheck();
                }
                if (FightManager.instance.CatHero != null)
                {
                    if (FightManager.instance.CatHero.GetComponentInChildren<BattleCat>())
                    {
                        FightManager.instance.CatHero.GetComponent<BattleCat>().health = 0;
                        FightManager.instance.CatHero.GetComponent<BattleCat>().DestroyCheck();
                    }
                }
            }

        }
    }
}
