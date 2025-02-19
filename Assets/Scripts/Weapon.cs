using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public int maxAmmo;
    public GameObject weaponPrefab; // Add this

    public GameObject projectilePrefab;
}

