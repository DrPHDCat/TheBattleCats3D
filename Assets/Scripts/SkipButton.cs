using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour,
    IPointerClickHandler
{
    public bool isASkipButton;
    public bool isAMainMenuStartButton;
    public bool isAQuitButton;
    public bool isABuyBackButton;
    public float cost;
    public bool isAGoBackToMenuButton;
    public bool isAResumeButton;
    public bool isAGoToCampaignMenuButton;
    public AudioClip purchaseSound;
    public AudioClip notEnoughFundsSound;
    public bool isALoadoutButton;
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
            if (FightManager.instance.BuySomething(cost))
            {
                BattleCanvas.instance.GetComponent<Animator>().Play("Buyback");
                GetComponent<AudioSource>().clip = purchaseSound;
                GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<AudioSource>().clip = notEnoughFundsSound;
                GetComponent<AudioSource>().Play();

            }
        }
        if (isAResumeButton)
        {
            FightManager.instance.Pause(PauseOption.Unpause);
            GetComponent<AudioSource>().Play();
        }
        if (isAGoBackToMenuButton)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        if (isAGoToCampaignMenuButton)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("EOCMenu", LoadSceneMode.Single);
        }
        if (isALoadoutButton)
        {
            Camera.main.transform.GetChild(0).GetComponent<Animator>().Play("LoadoutOpen");
            GetComponent<AudioSource>().Play();
        }
    }
}
