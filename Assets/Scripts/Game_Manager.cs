using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance{ get; private set; } //sirve para acceder (get) sea publico y que cuando quiera cambiarlo es privado (private set)
    int _stars = 0;

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
    }

    public void AddStar()
    {
        _stars++;
        Debug.Log("Estrellas recogidas: " + _stars);
    }
}
