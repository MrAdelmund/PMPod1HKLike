using Unity.VisualScripting;
using UnityEngine;

public class StupidEnemyAi : MonoBehaviour 
{
    [Header("Everything the enemy Bounces off of needs the Wall tag")]
       
    
    public float direction = 1;
   public Rigidbody2D rb;
        public float speed;
    


    [Header("ranged enemy stuff")]

    public GameObject player;
    public bool ranged = false;
    public float range = 5;
    public GameObject bullet;
    public float Shotspeed;
    public float cooldown;
    float time = 0;
    float lastDirection;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "enemy" || collision.gameObject.tag == "Player")
            {
                direction = direction * -1;
            }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float yVel = rb.linearVelocity.y;
        rb.linearVelocity = new Vector2(speed *100 * direction * Time.deltaTime, yVel );

        //other stuff it does if its ranged
        if (ranged)
        {
            time += Time.deltaTime;
            if (time >= cooldown)
            {
                Vector3 shootDir = player.transform.position - transform.position;

                if (shootDir.magnitude < range)
                {
                    lastDirection = direction;

                    
                    
                    GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
                    Debug.Log("i am shooting");
                    direction = 0f;
                    time = 0;

                    shootDir.Normalize();

                    shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * Shotspeed;
                    Destroy(shot, 10);
                }
                else
                {
                    direction = lastDirection; 
                }
               
            }

        }
        

    }
    }

