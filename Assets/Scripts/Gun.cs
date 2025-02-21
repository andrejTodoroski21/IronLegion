using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public string gunName;
    public float fireRate;
    public int damage;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int ammoCount;
    public float bulletSpeed = 0f;
    private bool canShoot = true;

    public virtual void Shoot(){
        if(canShoot && ammoCount > 0){
            FireBullet();
            ammoCount --;
            StartCoroutine(FireRateCooldown());
        }
    }

    protected virtual void FireBullet(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private IEnumerator FireRateCooldown(){
        canShoot = false;
        yield return new WaitForSeconds(1f/fireRate);
        canShoot = true;
    }
}
