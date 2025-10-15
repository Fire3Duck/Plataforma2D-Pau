using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Scene_Loader : MonoBehaviour
{
    public static Scene_Loader Instance;

    [SerializeField] private GameObject _loadingCanvas;
    [SerializeField] private Image _loadingBar;
    [SerializeField] private Text _loadingText;

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
        StartCoroutine(LoadNewScene(sceneName));
    }


    IEnumerator LoadNewScene(string sceneName)
    {
        yield return null;

        _loadingCanvas.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        float fakeLoadPercentage = 0;

        while (!asyncLoad.isDone)
        {
            //_loadingBar.fillAmount = asyncLoad.progress;

            fakeLoadPercentage += 0.01f;
            Mathf.Clamp01(fakeLoadPercentage);
            _loadingBar.fillAmount = fakeLoadPercentage;
            _loadingText.text = (fakeLoadPercentage * 100).ToString("F0") + "%";

            if (asyncLoad.progress >= 0.9f && fakeLoadPercentage >= 0.99f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return new WaitForSecondsRealtime(0.1f);
        }

        Time.timeScale = 1;
        Game_Manager.instance.playerInputs.FindActionMap("Player").Enable();
        Game_Manager.instance._isPaused = false;
        _loadingCanvas.SetActive(false);
    }
}
