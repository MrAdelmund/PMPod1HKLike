using UnityEngine;
using TMPro;

public class Healthreader : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI HpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float PlayerHP = player.GetComponent<PlayerHealth>().health
    }
}
