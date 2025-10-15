using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private Animator _animator;
    private AudioSource _audioSource;
    private float _enemyVelocity = 2;

    [SerializeField] private float DirectionEnemy = 1;
    [SerializeField] private Vector2 _hitboxSide = new Vector2(1, 1);
    private float velocity;

    public float maxHealth;
    private float currentHealth;
    public AudioClip deathSFX;

    private Player_Controler _playerControl;
    [SerializeField] private float _mimicDamage = 0.25f;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector2(DirectionEnemy * _enemyVelocity, _rigidBody.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Limite")
        {
            Debug.Log("Pera");

            if (DirectionEnemy == 1)
            {
                DirectionEnemy = -1;
            }
            else
            {
                DirectionEnemy = 1;
            }
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            {
                Player_Controler _playerControl = other.gameObject.GetComponent<Player_Controler>();
                _playerControl.TakeDamage(_mimicDamage);

            }
    }

    public void TakeDamage(float damage)
    {
        currentHealth-= damage;
        
        if(currentHealth <= 0)
        {
            Death();
        }
        
    }

    void Death()
    {
        DirectionEnemy = 0;
        _rigidBody.gravityScale = 0;
        _boxCollider.enabled = false;
        _audioSource.PlayOneShot(deathSFX);
        //_animator.SetTrigger("EnDeath");
        Destroy(gameObject, 1.05f);
    }
}
