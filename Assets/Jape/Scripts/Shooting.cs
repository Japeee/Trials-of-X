using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform rotation;
    public GameObject bulletPrefab;
    private bool canShoot = true;
    Vector2 mousePos;
    public Camera cam;
    public Rigidbody2D rbfp;

    public float bulletForce = 20f;

    void Update()
    {
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rbfp.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbfp.rotation = angle;

        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(FireRate());
        }
    }
    private IEnumerator FireRate()
    {
        canShoot = false;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.35f);
        canShoot = true;
    }
}
