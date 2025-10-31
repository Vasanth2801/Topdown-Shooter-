using UnityEngine;

public class Ammo : MonoBehaviour
{
    Gun gun;


    private void Start()
    {
        gun = FindObjectOfType<Gun>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gun.currentAmmo += 10;
            Destroy(gameObject);
        }
    }
}
