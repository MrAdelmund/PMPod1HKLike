using UnityEngine;

public class OnlyAppearWhileBossActive : MonoBehaviour
{

    public GameObject BossActive;
    public bool OppositeDay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool BA = BossActive.GetComponent<BossActive>().bossActive;
        if ((OppositeDay == false && BA ) || (OppositeDay && BA == false))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
