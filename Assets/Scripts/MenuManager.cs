using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Scene_Loader.Instance.ChangeScene(sceneName);
    }
}
