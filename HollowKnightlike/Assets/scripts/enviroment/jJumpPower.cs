using UnityEngine;
using TMPro;
public class jJumpPower : MonoBehaviour
{
    public GameObject player;
    public float Walljumps;
    public float doublejumps;
    public int Health;

    [Header("Upgrade Stuff")]
    public bool IsUpgrade; 
    public float MaxWallJumps = 0;
    public float MaxDoubleJumps = 0;
    public bool usesDashes;
    public bool CanDash;
    public bool PlayerGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // if(CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().CurrentDoubleJumps += doublejumps;
            player.GetComponent<PlayerMovement>().CurrentWallJumps += Walljumps;
            player.GetComponent<PlayerMovement>().MaxDoubleJumps += MaxDoubleJumps;
            player.GetComponent<PlayerMovement>().MaxWallJumps += MaxWallJumps;
            player.GetComponent<PlayerHealth>().health += Health;
            player.BroadcastMessage("updateText");
            if (IsUpgrade)
            {
                player.GetComponent<PlayerMovement>().dashEnabled = CanDash;
            }
                if (usesDashes)
            {
                Destroy(gameObject);
            }
            else
            {

                gameObject.GetComponent<SpriteRenderer>().enabled = false;

            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerGrounded = player.GetComponent<PlayerMovement>().isGrounded;
      if   (PlayerGrounded == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
