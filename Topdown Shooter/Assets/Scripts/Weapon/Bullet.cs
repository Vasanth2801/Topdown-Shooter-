using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject particleEffect;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(particleEffect, 1f);
            Destroy(gameObject);
        }
        

        Destroy(gameObject);
    }
}
