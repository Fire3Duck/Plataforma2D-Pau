using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class GUI_manager : MonoBehaviour
{
    public static GUI_manager Instance;
    public GameObject _pauseCanvas;

    private Image _healthBar;


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
    }
    public void ChangeCanvasStatus(GameObject canvas, bool status)
    {
        canvas.SetActive(status);
    }

    public void UpdateHealthBar(int _currentHealth, int _maxHealth)
    {
        _healthBar.fillAmount = _currentHealth / _maxHealth;
    }

    public void Resume()
    {
        Game_Manager.instance.Pause();
    }

    public void ChangeScene(string sceneName)
    {
        Scene_Loader.Instance.ChangeScene(sceneName);
    }
}
