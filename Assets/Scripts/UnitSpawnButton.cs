using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSpawnButton : MonoBehaviour,
    IPointerClickHandler

{
    [SerializeField]
    private int index;
    private UnitControlMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = transform.parent.GetComponent<UnitControlMenu>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (index == 0)
        {
            menu.BuyUnit(0);

        }
        if (index == 1)
        {
            menu.BuyUnit(1);

        }
        if (index == 2)
        {
            menu.BuyUnit(2);

        }
        if (index == 3)
        {
            menu.BuyUnit(4);

        }
        if (index == 5)
        {
            menu.BuyUnit(5);

        }
        if (index == 6)
        {
            menu.BuyUnit(6);
        }
        if (index == 7)
        {
            menu.BuyUnit(7);
        }
        if (index == 8)
        {
            menu.BuyUnit(8);
        }
        if (index == 9)
        {
            menu.BuyUnit(9);
        }
    }
}
