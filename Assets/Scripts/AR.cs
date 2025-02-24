using UnityEngine;
using System.Collections;

public class AR : Gun
{
    private bool isShooting = false;

    public void StartFiring(){
        isShooting = true;
        StartCoroutine(AutoFire());
    }

    public void StopFiring(){
        isShooting = false;
    }

    private IEnumerator AutoFire(){
        while (isShooting && ammoCount > 0 ) {
            FireBullet();
            ammoCount--;
            yield return new WaitForSeconds(1f/fireRate);
        }
    }
}
