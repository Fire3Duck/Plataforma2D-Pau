using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _coinsSFX;

    void Awake()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();
    }

    public void Interaction()
    {
        //_gameManager.AddStar();

        Game_Manager.instance.AddCoin();
        AudioManager.instance.ReproduceSound(AudioManager.instance._coinsSFX);
        Destroy(gameObject);
    }
}
