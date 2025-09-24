using UnityEngine;

public class Star : MonoBehaviour
{
    //Game_Manager _gameManager;

    [SerializeField] private AudioClip _starSFX;

    void Awake()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();
    }

    public void Interaction()
    {
        //_gameManager.AddStar();

        Game_Manager.instance.AddStar();
        AudioManager.instance.ReproduceSound(AudioManager.instance._starSFX);
        Destroy(gameObject);
    }
}
