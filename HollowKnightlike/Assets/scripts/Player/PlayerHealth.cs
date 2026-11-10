using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    
    public bool DashGivesIFrames;
    public float IFrames;
  
    [Header("ref")]
    public TMP_Text healthText;
    public bool PlayerDashing;
    public bool Invincible;
    public PlayerMovement PlayerMovement;
    public SpriteRenderer PlayerSpriteRenderer;

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

        if (Invincible)
        {
            PlayerSpriteRenderer.color = new UnityEngine.Color(PlayerSpriteRenderer.color.r,PlayerSpriteRenderer.color.g,PlayerSpriteRenderer.color.b, 0.5f);
        }
        else
        {
            PlayerSpriteRenderer.color = new UnityEngine.Color(PlayerSpriteRenderer.color.r, PlayerSpriteRenderer.color.g, PlayerSpriteRenderer.color.b, 1f);
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
    void IFrame()
    {
        if (Invincible)
        {
            Invincible = false;
        }
        else
        {
            Invoke(nameof(IFrame), IFrames);
            Invincible = true;

        }
    }
        
    void Hurt()
    {
        if (!Invincible)
        if ((PlayerDashing == false && DashGivesIFrames) || DashGivesIFrames == false)
        {
            Debug.Log("owch");
            health -= 1;
                updateText();
                IFrame();
                
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.CompareTag("enemy"))
        {
            Hurt();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Hurt();
        }
    }

}