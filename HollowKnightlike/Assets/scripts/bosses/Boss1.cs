using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    
    public GameObject bullet;
    public GameObject player;
    public GameObject bossActive;
    public float Shotspeed;
    public float cooldown;
    public bool invinvible;
    public float jump = 0;
    
    public float AttacksPerICycle = 10;
    bool spawned;
    [Header("debugging References")]
    // these are also used in the code but are only visable for debugging
    public float DoingAttack;
    public float timer;
    public float AttacksDoneThisCycle;
    bool touchedgrass;
    public float innacuracy = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = cooldown;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (bossActive.GetComponent<BossActive>().bossActive)
        {
            touchedgrass = true;
        }

    }

    void Attacked ( )
    {
        AttacksDoneThisCycle += 1;
        if( AttacksDoneThisCycle >= AttacksPerICycle )
        {
            invinvible = false;
        }
        else
        {
            invinvible = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
      

        if ( spawned == false && bossActive.GetComponent<BossActive>().bossActive )
        {
            spawned = true;
            transform.position = new Vector3(55f, 27f, 0f);
        }
        if (touchedgrass)
        {
            
            {
            timer -= 1 * Time.deltaTime;
                if (timer <= 0)
                {
                    DoingAttack = Random.Range(1, 5);
                    if (invinvible)
                    {
                        timer = cooldown;
                    }
                    else
                    {
                        timer = cooldown * 2;
                    }
                }
            }
            if (DoingAttack == 1f)
            {
                // jump attack
                gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(jump * Random.Range(-1, 2), 10);
                DoingAttack = 0;
                Attacked();
            }
            if (DoingAttack == 2f)
            {
                // shoot attack
                Debug.Log("i am trying to shoot");

                for (int i = 0; i < 2; i++)
                {
                    
                    
                    innacuracy *= -1f;

                    Vector3 shootDir = player.transform.position - transform.position;
                    shootDir.x += innacuracy;
                    shootDir.y += innacuracy;
                    GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);

                    shootDir.Normalize();

                    shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * 10;

                    
                   
                }
                innacuracy = 3;
                    DoingAttack = 0;
                    Attacked();
                
            }
            if (DoingAttack == 3f)
            {
                // jump and shoot attack
                gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(jump * Random.Range(-1, 2), 10);
                Vector3 shootDir = player.transform.position - transform.position;

                GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);

                shootDir.Normalize();

                shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * 10;
                Destroy(shot, 10);
                DoingAttack = 0;
                Attacked();
            }
            if (DoingAttack == 4f)
            {
                // dash attack
                gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-10 * Random.Range(-1, 2), 0);
                DoingAttack = 0;
                Attacked();
            }
        }
    }

}




