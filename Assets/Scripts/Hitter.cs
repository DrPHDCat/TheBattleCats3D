using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hitter : MonoBehaviour
{
    public bool enemy;
    public float damage;
    public GameObject hitSmoke;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log($"Collided with " + other.gameObject.name);
        if (!enemy)
        {
            Debug.Log("Sword is enemy");
            if (other.CompareTag("EnemyBase") || other.CompareTag("Enemy"))
            {
                Debug.Log("Sword collided with an enemy");
                GameObject smoke = Instantiate(hitSmoke, other.ClosestPoint(transform.position), Quaternion.identity);
                if (other.gameObject.CompareTag("EnemyBase"))
                {
                    other.gameObject.GetComponent<CatBase>().TakeDamage(damage);
                    smoke.GetComponent<AudioSource>().enabled = false;
                }
                if (other.CompareTag("Enemy"))
                {
                    other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }
        else if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerBase") || other.gameObject.CompareTag("PlayerUnit"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.gameObject.GetComponent<BattleCat>())
                {
                    other.gameObject.GetComponent<BattleCat>().TakeDamage(damage);
                    Instantiate(hitSmoke, other.ClosestPoint(transform.position), Quaternion.identity);
                }
            }
            if (other.gameObject.CompareTag("PlayerBase"))
            {
                other.GetComponent<CatBase>().TakeDamage(damage);
                GameObject smoke = Instantiate(hitSmoke, other.ClosestPoint(transform.position), Quaternion.identity);
                smoke.GetComponent<AudioSource>().enabled = false;
            }
        }
    }
}
