using UnityEngine;

public class BossHP : MonoBehaviour
{
    public GameObject BossActive;
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
    void flash()
    {
        
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 30, 200);
        invulnrable = true;
    }
    void unflash()
    {
        
        gameObject.GetComponent<SpriteRenderer>().color = new Color(colorR, ColorG, ColorB);
        invulnrable = false;
    }
    public void TakeDamage(int damage)
    {
        if (!invulnrable)
        {
            health -= damage;
            flash();
            gameObject.GetComponent<Boss1>().AttacksDoneThisCycle = 0;
            gameObject.GetComponent<Boss1>().invinvible = true;
            invulnrable = true;
        }


        if (health <= 0)
        {
            BossActive.GetComponent<BossActive>().bossActive = false;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (gameObject.GetComponent<Boss1>().invinvible)
        {
            flash();
        }
        else
        {
            unflash();
        }
    }
}
