using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public TMP_Text healthText;
    public bool DashGivesIFrames;
    public PlayerMovement PlayerMovement;
    public bool PlayerDashing;

    private void Start()
    {
        healthText.text = "Health: " + health;
    }
    private void Update()
    {
        if (PlayerMovement.isDashing)
        {
            PlayerDashing = true;
        }
        else
        {
            PlayerDashing = false;
        }

        if (health <= 0)
        {
            Debug.Log("I'm dead!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void updateText()
    {
        healthText.text = "Health: " + health;
    }
    void Hurt()
    {
        if ((PlayerDashing == false && DashGivesIFrames) || DashGivesIFrames == false)
        {
            Debug.Log("owch");
            health -= 1;
            healthText.text = "Health: " + health;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((PlayerDashing == false && DashGivesIFrames) || DashGivesIFrames == false)
     
        if (collision.gameObject.CompareTag("enemy"))
        {
            Hurt();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
            Hurt();
    }


}
