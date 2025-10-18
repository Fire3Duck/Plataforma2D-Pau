using UnityEngine;

public class Heart_Item : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Player_Controler _playerControl;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip HealthSFX;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerControl = GameObject.Find("Player").GetComponent<Player_Controler>();
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            //_playerControl.RestoreHealth();
            _audioSource.PlayOneShot(HealthSFX);
            Death();
        }
    }

    void Death()
    {
        _spriteRenderer.enabled = false;
        _boxCollider.enabled = false;
        Destroy(gameObject, 1.5f);
    }

    

    /*void Awake()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();
    }

    public void Interaction()
    {
        //_gameManager.AddStar();

        Game_Manager.instance.AddStar();
        AudioManager.instance.ReproduceSound(AudioManager.instance._starSFX);
        Destroy(gameObject);
    }*/
}
