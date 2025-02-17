// using UnityEngine;
// using System.Collections.Generic;

// public class Shooting : MonoBehaviour
// {
//     public Vector3 mousePosition;
//     private Camera mainCam;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         mainCam = Camera.main;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         mousePosition = mainCam.WorldToScreenPoint(Input.mousePosition);
//         mousePosition.z = 0f;

//         Vector3 direction = (mousePosition - transform.position).normalized;

//         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
//         transform.rotation = Quaternion.Euler(0, 0, angle);
        
//         Debug.Log(mousePosition);
//     }
// }
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Transform aimTransform;
    private Camera mainCamera;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10.0f;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        mainCamera = Camera.main; // Assign the main camera once at the start

        if (aimTransform == null)
        {
            Debug.LogError("Aim object not found! Make sure it's a child of " + gameObject.name);
        }
    }

    private void Update()
    {
        Aim();
        Shoot();
    }
     void Aim(){
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
        
        mousePos.z = 0f;
        
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.rotation = Quaternion.Lerp(aimTransform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * 10f);

        Vector3 localScale = aimTransform.localScale;
        localScale.y = (angle > 90 || angle < -90) ? -1 : 1;
        aimTransform.localScale = localScale;
     }
     void Shoot(){
        if(Input.GetMouseButtonDown(0)){
            GameObject bullet = Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if(rb != null){
                Vector2 shootDirection = (firePoint.position - aimTransform.position).normalized;
                rb.linearVelocity = shootDirection * bulletSpeed; // Apply movement forward
            }
        }
     }
}

