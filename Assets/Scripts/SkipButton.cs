using UnityEngine;
using UnityEngine.EventSystems;

public class SkipButton : MonoBehaviour,
    IPointerClickHandler
{
    public bool isASkipButton;
    public bool isAMainMenuStartButton;
    public bool isAQuitButton;
    public bool isABuyBackButton;
    public float cost;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void IPointerClickHandler.OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {

        if (isASkipButton)
        {
            GetComponent<AudioSource>().Play();
            transform.parent.GetChild(4).GetComponent<Animator>().Play("skip");
        }
        if (isAMainMenuStartButton)
        {
            GetComponent<AudioSource>().Play();
            transform.parent.GetComponent<Animator>().Play("start");
        }
        if (isAQuitButton)
        {
            GetComponent<AudioSource>().Play();
            Application.Quit();
        }
        if (isABuyBackButton)
        {
            if (true)
            {
                BattleCanvas.instance.GetComponent<Animator>().Play("Buyback");
                GetComponent<AudioSource>().Play();
            }
        }

    }
}
