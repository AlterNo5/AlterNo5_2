using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject m_prefabBullet;
    public Transform m_spawnPoint;

    private float fireRate = 0.25f;
    private float nextFire = 0.0f;
    

    private GameObject bullet;
    

    public void Shoot()
    {
       
        if(Time.time > nextFire)
        {
            bullet = Instantiate(m_prefabBullet, m_spawnPoint.position, m_spawnPoint.rotation);
            nextFire = Time.time + fireRate;
        }
           
    }

    private void Update()
    {
        Destroy(bullet, 2f);
    }
}
