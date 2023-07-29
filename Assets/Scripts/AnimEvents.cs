using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DeleteGameObject()
    {
        Destroy(gameObject);
    }
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
