using UnityEngine;

public class ShadowBox : MonoBehaviour
{
    public bool PlayerInside = false;

     float ColorR;
     float ColorG;
     float ColorB;

    float transperency;

    public SpriteRenderer SpriteRenderer;

    private void Start()
    {
        ColorR = SpriteRenderer.color.r;
        ColorB = SpriteRenderer.color.b;
        ColorG = SpriteRenderer.color.g;
        transperency = SpriteRenderer.color.a;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        { 
            PlayerInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerInside = false;
        }
    }
    private void Update()
    {
        if (PlayerInside)
        {
            if (transperency > 1)
            {
                transperency = 1;

            }
            if (transperency !<= 0)
            {
                SpriteRenderer.color = new Color(ColorR, ColorG, ColorB, transperency - 0.3f);
            }
        }
        else
        {
            if (transperency < 0)
            {
                transperency = 0;

            }
            if (transperency! >= 1)
            {
                SpriteRenderer.color = new Color(ColorR, ColorG, ColorB, transperency + 0.3f);
            }
        }
    }
}
