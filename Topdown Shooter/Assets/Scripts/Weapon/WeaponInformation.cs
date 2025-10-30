using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon",menuName = "Weapons")]
public class WeaponInformation : ScriptableObject
{
    public int weaponSize;
    public int damage;
    public float fireRate;
}
