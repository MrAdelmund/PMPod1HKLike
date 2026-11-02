using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public TMP_Text healthText;

    private void Start()
    {
        healthText.text = "Health: " + health;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("I hit an Enemy!");
            health -= 1;
            healthText.text = "Health: " + health;
            if (health <= 0)
            {
                Debug.Log("I'm dead!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}