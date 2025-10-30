using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public WeaponInformation weaponInfo;
    int currentAmmo;
    float fireRate;
    public TextMeshProUGUI ammoText;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce = 20f;


    private void Start()
    {
        currentAmmo = weaponInfo.weaponSize;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        UpdateUI();
    }




    void Shoot()
    {

        if (Time.time < fireRate)
        {
            return;
        }

        if (currentAmmo > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            currentAmmo--;
            fireRate = Time.time + 1f / weaponInfo.fireRate;            
            Destroy(bullet, 3f);
        }
        else
        {
            Debug.Log("Out of Ammo");
        }
    }

    void UpdateUI()
    {
        ammoText.text = "AmmoCount: " + currentAmmo.ToString();
    }
}
