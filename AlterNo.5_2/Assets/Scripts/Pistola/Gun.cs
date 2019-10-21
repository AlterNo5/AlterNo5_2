using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject m_prefabBullet;
    public Transform m_spawnPoint;
    

    public void Shoot()
    {            
            Instantiate(m_prefabBullet, m_spawnPoint.position, m_spawnPoint.rotation);           
    }
}
