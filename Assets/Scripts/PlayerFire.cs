using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    GameObject bullet, firePoint;

    [SerializeField]
    int shootingForce = 100;

    [SerializeField]
    float lifeTime = 4f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject currentBulelt = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        Rigidbody bulletRB = currentBulelt.GetComponent<Rigidbody>();
        bulletRB.AddForce(firePoint.transform.forward * shootingForce, ForceMode.Impulse);
        Destroy(currentBulelt, lifeTime);
    }
}
