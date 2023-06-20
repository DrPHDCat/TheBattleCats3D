using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    public bool isEnemy;
    public int knockbacks;
    public float speed;
    public List<Transform> possibletargets;
    float lowestRange;
    float health;
    public float maxHealth;
    int remainingKnockbacks;
    float knockbackThreshold;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        if (isEnemy)
        {
            FightManager.instance.EnemyUnits.Add(this);
        }
        else
        {
            FightManager.instance.PlayerUnits.Add(this);
        }

        health = maxHealth;
        remainingKnockbacks = knockbacks;
        knockbackThreshold = maxHealth / (knockbacks + 1);
    }

    // Update is called once per frame
    void Update()
    {
        possibletargets?.Clear();
        if (isEnemy)
        {
            for (int i = 0; i < FightManager.instance.PlayerUnits.Count; i++)
            {
                possibletargets.Add(FightManager.instance.PlayerUnits[i].transform);

            }
            possibletargets.Add(FightManager.instance.PlayerBase.transform);
            if (FightManager.instance.CatHero != null)
            {
                possibletargets.Add(FightManager.instance.CatHero.transform);
            }

            lowestRange = Mathf.Infinity;
            for (int i = 0; i < possibletargets.Count; i++)
            {
                if (Vector3.Distance(possibletargets[i].position, transform.position) < lowestRange && possibletargets[i].GetComponent<Collider>().enabled)
                {
                    lowestRange = Vector3.Distance(possibletargets[i].position, transform.position);
                    target = possibletargets[i];
                }
            }
        }
        else
        {
            for (int i = 0; i < FightManager.instance.EnemyUnits.Count; i++)
            {
                possibletargets.Add(FightManager.instance.EnemyUnits[i].transform);

            }
            possibletargets.Add(FightManager.instance.EnemyBase.transform);
            

            lowestRange = Mathf.Infinity;
            for (int i = 0; i < possibletargets.Count; i++)
            {
                if (Vector3.Distance(possibletargets[i].position, transform.position) < lowestRange && possibletargets[i].GetComponent<Collider>().enabled)
                { 
                    
                    lowestRange = Vector3.Distance(possibletargets[i].position, transform.position);
                    target = possibletargets[i];
                }
            }
        }
        if (target != null && Vector3.Distance(transform.position, target.GetComponent<Collider>().ClosestPoint(transform.position)) > range && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Knockback"))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z), Time.deltaTime * speed);

        }
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Knockback"))
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position, Vector3.up);
            
        }



    }
    private void OnDestroy()
    {
        if (isEnemy)
        {
            FightManager.instance.EnemyUnits.Remove(this);
        }
        else
        {
            FightManager.instance.PlayerUnits.Remove(this);
        }
    }
    public void DestroyCheck()
    {
        if (health <= 0)
        {
            Instantiate(FightManager.instance.deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (knockbacks > 0 && remainingKnockbacks > 0)
        {
            for (; health <= knockbackThreshold * remainingKnockbacks; remainingKnockbacks--)
            {

                
                transform.GetComponent<Animator>().Play("Knockback", 0);
            }
        }
    }
}
