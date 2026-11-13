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
     bool stop;

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
        stop = gameObject.GetComponent<Enemy>().stunned;
        if (!stop)
        { 
            float yVel = rb.linearVelocity.y;
            rb.linearVelocity = new Vector2(speed * 100 * direction * Time.deltaTime, yVel);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        //other stuff it does if its ranged
        if (ranged && !stop )
        {
            time += Time.deltaTime;
            if (time >= cooldown)
            {
                Vector3 shootDir = player.transform.position - transform.position;

                if (shootDir.magnitude < range)
                {

                    GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
                    Debug.Log("i am shooting");
                    
                    time = 0;

                    shootDir.Normalize();

                    shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * Shotspeed;
                    Destroy(shot, 10);
                }
                
               
            }

        }
        

    }
    }

