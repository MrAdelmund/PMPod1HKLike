using Unity.VisualScripting;
using UnityEngine;

public class Chaserenemyai : MonoBehaviour
{

    public float speed;
    public GameObject player;
    public Rigidbody2D RB;
    public bool RunningAway;
    float running = 1;

    [Header("jumping stuff")]
    public bool JumpEnabled = true;
    public float JumpForce = 3;
    public float jumpDelay = 3;
    public float doubleJumpDelay;
    public int totalJumps = 1;
    public int jumps;
    

    [Header ("References")]

    public float direction;
    public bool Canjump = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(RunningAway)
        {
            Fear();
        }
    }
    void Fear()
    {
        running *= -1;
    }
   
       
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            //Debug.Log("touched grass");
            RB.linearVelocity = new Vector2(RB.linearVelocity.x, 0);
            Canjump = true;
            jumps = totalJumps; 
            
        }
    }
   
    void jump()
    {
        jumps -= 1;
        Debug.Log("jumped");
        RB.linearVelocity = new Vector2(RB.linearVelocity.x, JumpForce);
        //double jumps
        if ((player.transform.position.y > gameObject.transform.position.y + 0.5f) && jumps > 0)
        {
            Invoke(nameof(jump), doubleJumpDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //jumping
        if ((player.transform.position.y > gameObject.transform.position.y + 0.5f) && JumpEnabled && Canjump)
        {
            Canjump = false;
           
            Invoke(nameof(jump), jumpDelay);

            
           
        }
        //walking
        if (player.transform.position.x > gameObject.transform.position.x)
        {
            direction = 1;
        }
        else if (player.transform.position.x < gameObject.transform.position.x)
        {
            direction = -1;
        }
        else
        {
            direction = 0;
        }
        float yVel = RB.linearVelocity.y;
        RB.linearVelocity = new Vector2(speed * 100 * direction * Time.deltaTime, yVel);


    }
}
