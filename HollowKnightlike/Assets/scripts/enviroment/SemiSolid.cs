using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class SemiSolid : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().isJumping || Keyboard.current.sKey.isPressed)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
