using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private Animator _animator;
    [SerializeField] private float _enemyVelocity = 2;

    [SerializeField] private float DirectionEnemy = 1;
    [SerializeField] private Vector2 _hitboxSide = new Vector2(1, 1);
    private float velocity;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

    public void Damage()
    {
        Debug.Log("Daño");
        Dead();

    }

    void Dead()
    {
        /*if (_life <= 0)
        {
            Debug.Log("Muerto");
        }*/
    }
}
