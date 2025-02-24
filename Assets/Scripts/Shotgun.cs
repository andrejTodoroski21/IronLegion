using UnityEngine;

public class Shotgun : Gun
{
    public int pelletCount = 5;

    protected override void FireBullet()
    {
        for (int i = 0; i < pelletCount; i++){
            float spreadAngle =Random.Range(-bulletSpread, bulletSpread);
            Quaternion spreadRotation = Quaternion.Euler(0,0, spreadAngle);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * spreadRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
