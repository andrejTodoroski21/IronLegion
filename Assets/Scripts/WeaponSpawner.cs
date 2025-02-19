using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public Weapon weaponData;
    public GameObject weaponPrefab;
    void Start()
    {
        SpawnWeapon();
    }

    void SpawnWeapon(){
        Instantiate(weaponPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
