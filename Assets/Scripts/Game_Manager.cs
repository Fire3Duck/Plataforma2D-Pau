using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance { get; private set; } //sirve para acceder (get) sea publico y que cuando quiera cambiarlo es privado (private set)
    int _stars = 0;
    [SerializeField] public InputActionAsset playerInputs;
    public InputAction _pauseInput;
    public bool _isPaused = false;
    
    private AudioManager _audioManager;
    public bool isPlaying = true;

    public Text starText;

    private int star = 0;
    
    void Start()
    {
        starText.text = star.ToString();
    }
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        _pauseInput = InputSystem.actions["Pause"];
        
        _audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
        starText.text = star.ToString();
    }

    public void AddStar()
    {
        _stars++;
        Debug.Log("Estrellas recogidas: " + _stars);
        starText.text = star.ToString();
    }

    void Update()
    {
        if (_pauseInput.WasPressedThisFrame())
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (_isPaused)
        {
            Time.timeScale = 1;
            GUI_manager.Instance.ChangeCanvasStatus(GUI_manager.Instance._pauseCanvas, false);
            playerInputs.FindActionMap("Player").Enable();
            _isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            GUI_manager.Instance.ChangeCanvasStatus(GUI_manager.Instance._pauseCanvas, true);
            playerInputs.FindActionMap("Player").Disable();
            _isPaused = true;
        }


    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    
    
}
