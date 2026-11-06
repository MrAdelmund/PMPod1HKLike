using UnityEngine;
using UnityEngine.InputSystem;

public class stain : MonoBehaviour
{
    public bool playerinrange = false;
    public float Filthyness = 100;

    public float ColorR;
    public float ColorG;
    public float ColorB;
    public float cleanspeed = 15;

    public ParticleSystem cleaningparticles;
    public SpriteRenderer SpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ColorR = SpriteRenderer.color.r;
        ColorB = SpriteRenderer.color.b;
        ColorG = SpriteRenderer.color.g;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerinrange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerinrange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerinrange && Keyboard.current.eKey.isPressed)
        {
            Filthyness -= cleanspeed * Time.deltaTime;

            SpriteRenderer.color = new Color(ColorR, ColorG, ColorB, Filthyness / 100);
            cleaningparticles.Play();
        }
        else
        {
            cleaningparticles.Stop();
        }


        if(Filthyness <=0)
        {
            Destroy(gameObject);
        }
    }
}
