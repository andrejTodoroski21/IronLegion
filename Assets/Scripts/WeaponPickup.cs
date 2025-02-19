using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    public Weapon weaponData;

    void OnTriggerWeapon2D(Collider2D other){
        if(other.CompareTag("Player")){
            
            other.GetComponent<PlayerWeaponManager>().PickUpWeapon(weaponData);
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
