using UnityEditor.Build.Content;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;
    public bool invulnrable;
    float colorR;
    float ColorG;
    float ColorB;
    public bool stunned;
    public float StunDuration = 0.5f;

    private void Start()
    {
        colorR = gameObject.GetComponent<SpriteRenderer>().color.r;
        ColorG = gameObject.GetComponent<SpriteRenderer>().color.g;
        ColorB = gameObject.GetComponent<SpriteRenderer>().color.b;
    }
    void flash ()
    {
        invulnrable = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(200, 0, 0);
        Invoke(nameof(unflash), 0.125f);
    }
    void unflash ()
    {
        invulnrable = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(colorR, ColorG, ColorB);
    }
    public void TakeDamage(int damage)
    {
        if (!invulnrable)
        { 
            health -= damage;
            flash();
            stun();
        }
       

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void stun ()
    {
       if( stunned)
        {
            stunned = false;
        }
        else
        {
            stunned = true;
            Invoke(nameof(stun), StunDuration);
        }
    }
}
