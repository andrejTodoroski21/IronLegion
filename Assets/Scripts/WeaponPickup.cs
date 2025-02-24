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
}
