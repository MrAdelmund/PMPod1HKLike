using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsScene : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
