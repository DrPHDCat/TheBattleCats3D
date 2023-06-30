using UnityEngine;

public class BattleCanvas : MonoSingleton<BattleCanvas>
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ResetCameraPos()
    {
        Camera.main.transform.position = FightManager.instance.transform.position;
        Camera.main.transform.rotation = FightManager.instance.transform.rotation;
    }
    //thefollowingfunction is called with an animation event
    public void BuyBack()
    {
        Instantiate(CatHeroManager.GetCatHero(FightManager.instance.CatHeroType), FightManager.instance.PlayerBase.transform.position + -FightManager.instance.PlayerBase.transform.right * 3, Quaternion.identity);
        Camera.main.transform.rotation = Quaternion.identity;
        
        
    }
}
