using UnityEngine;
using System.Collections;

public class BurstRifle : Gun
{
    public int burstCount = 3;
    public float burstDelay = 0.2f;

    public override void Shoot(){
        if(canShoot && ammoCount >= burstCount){
            StartCoroutine(BurstFire());
        }
    }

    private IEnumerator BurstFire(){
        canShoot = false;
        for(int i = 0; i < burstCount; i++){
            FireBullet();
            ammoCount --;
            yield return new WaitForSeconds(burstDelay);
        }
        yield return new WaitForSeconds(1f/fireRate);
        canShoot = true;
    }
    
}
