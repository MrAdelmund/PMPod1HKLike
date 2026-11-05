using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;
    public StupidEnemyAi AI;
    public void TakeDamage(int damage)
    {
        AI.direction *= -1;
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
