using UnityEngine;

public class bosstrigger : MonoBehaviour
{
    public GameObject BossActive;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("boss where are you?");
            BossActive.GetComponent<BossActive>().bossActive = true;
            Destroy(gameObject);
        }
    }
}
