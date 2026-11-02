using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("I hit an Enemy!");
            health -= 1;
            if (health <= 0)
            {
                Debug.Log("I'm dead!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}