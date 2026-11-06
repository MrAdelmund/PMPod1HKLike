using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScene : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
