using UnityEngine;

public class Finish_Star : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    public AudioClip KeySFX;
    private SpriteRenderer _renderer;
    private AudioManager _soundManager;
    public GameObject canvasMostrar;
    public Game_Manager _gameManager;
    private Animator _animator;

    void Awake()
    
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _soundManager = GameObject.Find("BGM Manager").GetComponent<AudioManager>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        _animator = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
       if (canvasMostrar != null)
        {
            canvasMostrar.SetActive(false); // Asegura que empieza desactivado
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Death();
            //Destroy(Collision.gameObject);
            Player_Controler playerScript = collider.gameObject.GetComponent<Player_Controler>();
            playerScript.inputHorizontal = 0;
            _gameManager.isPlaying = false;
            
            if (canvasMostrar != null)
            {
                canvasMostrar.SetActive(true); // Muestra el canvas
            }
        }
    }

    public void Death()
    {
        //_gameManager.AddCoins();

        _boxCollider.enabled = false;
        _renderer.enabled = false;
        _audioSource.PlayOneShot(KeySFX);
        Destroy(gameObject, 3);
        //_soundManager.StopMusic();
        //_soundManager.Victory();
        _gameManager.isPlaying = false;
    }
}