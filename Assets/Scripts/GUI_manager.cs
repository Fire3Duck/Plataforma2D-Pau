using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class GUI_manager : MonoBehaviour
{
    public static GUI_manager Instance;
    public GameObject _pauseCanvas;

    private Image _healthBar;

    int _stars = 0;
    int _coins = 0;

    public Text starText;
    public Text coinText;


    void Start()
    {
        starText.text = _stars.ToString();
    }
     
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

    public void UpdateHealthBar(float _currentHealth, float _maxHealth)
    {
        _healthBar.fillAmount = _currentHealth / _maxHealth;
    }

    public void AddStar()
    {
        _stars++;
        Debug.Log("Estrellas recogidas: " + _stars);
        starText.text = _stars.ToString();
    }

    public void AddCoin()
    {
        _coins++;
        Debug.Log("Monedas recogidas: " + _coins);
        coinText.text = _coins.ToString();
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
