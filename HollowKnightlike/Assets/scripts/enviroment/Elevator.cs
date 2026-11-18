using UnityEngine;
using UnityEngine.SceneManagement;
public class Elevator : MonoBehaviour
{
    public GameObject player;
    public int SceneNumber;
    public float OpenAnimationLength = 0.5f;
    public float Closeanimationlength;

    [Header ("animation references")]
    public bool opening;
    public bool open;
    public bool closing;
    public bool closed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void E1()
    {
        opening = true;
        Invoke("E2", OpenAnimationLength);

    }
    void E2()
    {
        opening = false;
        open = true;
        player.BroadcastMessage("Vanish");
    }
    void E3()
    {
        open = false;
        closing = true;
        Invoke("E4", Closeanimationlength);
    }
    void E4 ()
    {
        closing = false;
        closed = true;
        SceneManager.LoadScene(SceneNumber);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.BroadcastMessage("StopMoving");
      
            E1();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
