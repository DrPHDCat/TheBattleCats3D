using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BattleCat : MonoBehaviour
{
    int goRight;
    int goLeft;
    int goForward;
    int goBack;
    float health;
    float maxHealth;
    bool knockedBack;
    bool zerohealthknockedback;
    public int Speed;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        FightManager.instance.CatHero = gameObject;
        FightManager.instance.CatHeroType = CatHeroType.SwordCat;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject parentObject = transform.parent.gameObject;
        transform.parent = null;
        parentObject.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + Input.GetAxis("Mouse X") * 3.5f, transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + Input.GetAxis("Mouse X") * 3.5f, transform.eulerAngles.z);
        transform.parent = parentObject.transform;
        
        if (Input.GetKey(KeyCode.W))
        {
            goForward = Speed;
        }
        else
        {
            goForward = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            goLeft = Speed;
        }
        else
        {
            goLeft = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            goRight = Speed;
        }
        else
        {
            goRight = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            goBack = Speed;
        }
        else
        {
            goBack = 0;
        }
        if (!transform.parent.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Knockback"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3((transform.right.x * goForward) + (-transform.right.x * goBack) + (transform.forward.x * goLeft) + (-transform.forward.x * goRight), GetComponent<Rigidbody>().velocity.y, (transform.right.z * goForward) + (-transform.right.z * goBack) + (transform.forward.z * goLeft) + (-transform.forward.z * goRight));
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (Input.GetMouseButtonDown(0) && !transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Slash"))
        {
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("Slash");
        }

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < (maxHealth / 2) && !knockedBack)
        {
            knockedBack = true;
            transform.parent.GetComponent<Animator>().Play("Knockback");

        }
        if (health <= 0 && !zerohealthknockedback)
        {
            zerohealthknockedback = true;
            transform.parent.GetComponent<Animator>().Play("Knockback");

        }

    }
    public void DestroyCheck()
    {
        if (health <= 0)
        {
            Instantiate(FightManager.instance.deathEffect, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
            BattleCanvas.instance.GetComponent<Animator>().Play("ResetCamPos");
        }
    }
    public void DisableLockToY(int huh)
    {
        if (huh != 1)
        {
            GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionY;

        }
        else
        {
            GetComponent<Rigidbody>().constraints &= RigidbodyConstraints.FreezePositionY;
        }

    }
    public void DisableRootMotion(int guh)
    {
        if (guh != 1)
        {
            GetComponent<Animator>().applyRootMotion = true;
        }
        else
        {
            GetComponent<Animator>().applyRootMotion = false;
        }
    }
    public void StopPlayback()
    {
        GetComponent<Animator>().StopPlayback();
    }
    public void OnDestroy()
    {
        FightManager.instance.CatHero = null;
    }
}

//GetComponent<Rigidbody>().velocity = new Vector3(transform.right.x * 5, transform.right.y * 5, transform.right.z * 5);