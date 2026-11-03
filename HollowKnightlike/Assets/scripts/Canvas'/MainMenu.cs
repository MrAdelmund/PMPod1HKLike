using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}
