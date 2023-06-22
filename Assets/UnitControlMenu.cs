using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControlMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip openSound;
    [SerializeField]
    private AudioClip closeSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
