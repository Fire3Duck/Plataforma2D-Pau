using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Loader : MonoBehaviour
{
    public static Scene_Loader Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {

            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
