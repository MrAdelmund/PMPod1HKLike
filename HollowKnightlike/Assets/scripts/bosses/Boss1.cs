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
    bool spawned;
    [Header("debugging References")]
    public float DoingAttack;
    public float timer;
    
    bool touchedgrass;
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
            timer -= 1 * Time.deltaTime;
            if (timer <= 0)
            {
                DoingAttack = Random.Range(1, 4);
                timer = cooldown;
            }
            if (DoingAttack == 1f)
            {
                gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(jump * Random.Range(-1, 2), 10);
                DoingAttack = 0;
            }
            if (DoingAttack == 2f)
            {
                Debug.Log("i am trying to shoot");
                Vector3 shootDir = player.transform.position - transform.position;

                    GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
                 
                    shootDir.Normalize();

                    shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * 10;
                   Destroy(shot, 10);
                DoingAttack = 0;
            }
            if (DoingAttack == 3f)
            {
                gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(jump * Random.Range(-1, 2), 10);
                Vector3 shootDir = player.transform.position - transform.position;

                GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);

                shootDir.Normalize();

                shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * 10;
                Destroy(shot, 10);
                DoingAttack = 0;
            }
        }
    }

}




