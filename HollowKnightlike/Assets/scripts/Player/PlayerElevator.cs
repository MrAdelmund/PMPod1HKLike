using UnityEngine;

public class PlayerElevator : MonoBehaviour
{
    public float transpearency;
    
    public GameObject Elevator;

    public SpriteRenderer SpriteRender;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void StopMoving()
    {
        
        gameObject.GetComponent<PlayerMovement>().CanMove = false;
        gameObject.GetComponent<PlayerHealth>().stopUpdating = true;
        
    }
    void Vanishframe()
    {
        transpearency -= 0.1f;
        SpriteRender.color = new Color(255, 255, 255, transpearency);
        Debug.Log("vanishing");
        Invoke(nameof(Vanish), 0.1f);
    }
    void Vanish()
    {
        if (SpriteRender.color.a > 0)
        {
            Invoke(nameof(Vanishframe), 0.1f);
        }
        else
        {
            Elevator.BroadcastMessage("E3");
        }


    }
}
