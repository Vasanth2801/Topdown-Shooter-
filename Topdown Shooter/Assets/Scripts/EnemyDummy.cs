using UnityEngine;

public class EnemyDummy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthBar.instance.Takedamage(20);
        }
    }
}
