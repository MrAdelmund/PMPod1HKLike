using UnityEngine;

public class jJumpPower : MonoBehaviour
{
    public GameObject player;
    public float Walljumps;
    public float doublejumps;

    public bool PlayerGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // if(CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().CurrentDoubleJumps += doublejumps;
            player.GetComponent<PlayerMovement>().CurrentWallJumps += Walljumps;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

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
