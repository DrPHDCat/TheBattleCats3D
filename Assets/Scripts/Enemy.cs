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
    public float singletargetdamage;
    public GameObject hitSmoke;
    public bool singleTarget;
    public float netWorth;
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
        // if is a single target and is in range of the target, and is not being knocked back or attacking it will play an animation called Attack
       
        if (Vector3.Distance(transform.position, target.GetComponent<Collider>().ClosestPoint(transform.position)) <= range && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Knockback") && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            GetComponent<Animator>().SetTrigger("Attack");
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
                if (isEnemy)
            {
                FightManager.instance.GainMoney(netWorth);
            }
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
    // this is ran by an animation event in an attack animation in the frame you want the entity to hit its target, it deals the health damage to the target if its in range, it checks if the target has a BattleCat component in it and its children, if so runs the battleCat's take damage, if no looks for enemy component and yeah
    public void DealSingleTargetDamage()
    {
        if (target != null && Vector3.Distance(transform.position, target.GetComponent<Collider>().ClosestPoint(transform.position)) <= range )
        {
            if (!isEnemy)
        {
            
            if (target.CompareTag("EnemyBase") || target.CompareTag("Enemy"))
            {
                
                GameObject smoke = Instantiate(hitSmoke, target.GetComponentInChildren<Collider>().ClosestPoint(transform.position), Quaternion.identity);
                if (target.gameObject.CompareTag("EnemyBase"))
                {
                    target.gameObject.GetComponent<CatBase>().TakeDamage(singletargetdamage);
                    smoke.GetComponent<AudioSource>().enabled = false;
                }
                if (target.CompareTag("Enemy"))
                {
                    target.gameObject.GetComponent<Enemy>().TakeDamage(singletargetdamage);
                }
            }
        }
        else if (target.gameObject.CompareTag("Player") || target.gameObject.CompareTag("PlayerBase") || target.gameObject.CompareTag("PlayerUnit"))
        {
            if (target.gameObject.CompareTag("Player"))
            {
                if (target.gameObject.GetComponent<BattleCat>())
                {
                    target.gameObject.GetComponent<BattleCat>().TakeDamage( singletargetdamage);
                    Instantiate(hitSmoke, target.GetComponentInChildren<Collider>().ClosestPoint(transform.position), Quaternion.identity);
                }
            }
            if (target.gameObject.CompareTag("PlayerBase"))
            {
                target.GetComponent<CatBase>().TakeDamage(singletargetdamage);
                GameObject smoke = Instantiate(hitSmoke, target.GetComponentInChildren<Collider>().ClosestPoint(transform.position), Quaternion.identity);
                smoke.GetComponent<AudioSource>().enabled = false;
            }
            if (target.gameObject.CompareTag("PlayerUnit"))
            {
                target.GetComponent<Enemy>().TakeDamage(singletargetdamage);
                GameObject smoke = Instantiate(hitSmoke, target.GetComponentInChildren<Collider>().ClosestPoint(transform.position), Quaternion.identity);
            }
        }
        }
    }
}
