using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitControlMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip openSound;
    [SerializeField]
    private AudioClip closeSound;
    [SerializeField]
    public GameObject[] units;
    public float[] cooldowns;
    public AudioClip purchaseSound;
    public AudioClip notEnoughFundsSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < units.Length; i++)
        {
            cooldowns[i] = Mathf.MoveTowards(cooldowns[i], 0, Time.deltaTime);
            if (units[i].GetComponent<Enemy>().cost <= FightManager.instance.catMoney)
            {
                transform.GetChild(i).GetChild(0).localScale = new Vector3(cooldowns[i] / units[i].GetComponentInChildren<Enemy>().cooldown, 1, 1);
            }
            else
            {
                
                transform.GetChild(i).GetChild(0).localScale = new Vector3(1, 1, 1);
            }
            transform.GetChild(i).GetComponent<Image>().sprite = units[i].GetComponentInChildren<Enemy>().portrait;
            transform.GetChild(i).GetComponentInChildren<Text>().text = units[i].GetComponentInChildren<Enemy>().cost.ToString();
        }
        if (!FightManager.instance.FightEnded) {
        if (transform.parent.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("UnitMenuOpen"))
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                transform.parent.GetComponent<Animator>().Play("UnitMenuClose"); 
                GetComponent<AudioSource>().PlayOneShot(openSound);
            }
        }
        else if (!transform.parent.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("UnitMenuOpen"))
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                transform.parent.GetComponent<Animator>().Play("UnitMenuOpen");        
                GetComponent<AudioSource>().PlayOneShot(closeSound);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BuyUnit(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BuyUnit(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BuyUnit(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            BuyUnit(3);
        }
        if  (Input.GetKeyDown(KeyCode.Alpha5))
        {
            BuyUnit(4);
        }
        if  (Input.GetKeyDown(KeyCode.Alpha6))
        {
            BuyUnit(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            BuyUnit(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            BuyUnit(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            BuyUnit(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            BuyUnit(9);
        }}
    }
    public void BuyUnit(int index)
    {
        if (units[index] != null && cooldowns[index] <= 0 && FightManager.instance.BuySomething(units[0].GetComponentInChildren<Enemy>().cost) && index >= 0 && index < units.Length)
        {
            Instantiate(units[index], FightManager.instance.PlayerBase.transform.position + FightManager.instance.transform.right * 3, Quaternion.identity);
            cooldowns[index] = units[index].GetComponentInChildren<Enemy>().cooldown;
            GetComponent<AudioSource>().PlayOneShot(purchaseSound);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(notEnoughFundsSound);
        }
    }
}
