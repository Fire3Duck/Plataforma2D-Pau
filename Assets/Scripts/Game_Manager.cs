using UnityEngine;
using UnityEngine.InputSystem;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance { get; private set; } //sirve para acceder (get) sea publico y que cuando quiera cambiarlo es privado (private set)
    int _stars = 0;

    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private InputActionAsset playerInputs;
    private InputAction _pauseInput;
    private bool _isPaused = false;


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
    }

    public void AddStar()
    {
        _stars++;
        Debug.Log("Estrellas recogidas: " + _stars);
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
            _pauseCanvas.SetActive(false);
            playerInputs.FindActionMap("Player").Enable();
            _isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            _pauseCanvas.SetActive(true);
            playerInputs.FindActionMap("Player").Disable();
            _isPaused = true;
        }
        
        
    }
}
