using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public Weapon defaultWeaponData;
    private Weapon currentWeaponData;
    private int currentAmmo;
    private GameObject currentWeaponObject;
    public Transform weaponHolder;
    void Start()
    {
        EquipWeapon(defaultWeaponData);
    }

    void EquipWeapon(Weapon newWeaponData){
        if(currentWeaponObject != null){
            
            Destroy(currentWeaponObject);

        }
        currentWeaponData = newWeaponData;
        currentAmmo = newWeaponData.maxAmmo;

        currentWeaponObject = Instantiate(currentWeaponData.weaponPrefab, weaponHolder.position, Quaternion.identity, weaponHolder);

        Debug.Log($"Equipped {newWeaponData.weaponName} with {currentAmmo} ammo");

        foreach(Transform child in weaponHolder){
            child.gameObject.SetActive(false);
        }
        weaponHolder.Find(newWeaponData.weaponName)?.gameObject.SetActive(true);
    }
    public void UseAmmo(){
        if(currentWeaponData != null && currentAmmo > 0){
            currentAmmo --;
            if(currentAmmo <= 0){
                Debug.Log($"{currentWeaponData.weaponName} is out of ammo. Switching back to pistol.");
                EquipWeapon(defaultWeaponData);
            }
        }
    }
    public void PickUpWeapon(Weapon newWeaponData){
        EquipWeapon(newWeaponData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
