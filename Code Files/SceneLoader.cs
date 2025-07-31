using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadInitialScene()
    {
        SceneManager.LoadScene("InitialScene");
    }

    public void LoadObstacleScene()
    {
        SceneManager.LoadScene("ObstacleScene");
    }

    public void LoadGaryScene()
    {
        SceneManager.LoadScene("GaryOh");
    }

    public void LoadTargetScene()
    {
        SceneManager.LoadScene("TargetScene");
    }
}

