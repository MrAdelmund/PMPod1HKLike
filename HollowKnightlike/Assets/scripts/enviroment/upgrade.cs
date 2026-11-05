using UnityEngine;

public class upgrade : MonoBehaviour
{
    public GameObject player;
    public float Walljumps;
    public float doublejumps;

    public bool PlayerGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if(CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().MaxDoubleJumps += doublejumps;
            player.GetComponent<PlayerMovement>().MaxWallJumps += Walljumps;
            Destroy(gameObject);

        }
    }
}
    
