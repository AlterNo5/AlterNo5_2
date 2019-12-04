using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalEspejo : MonoBehaviour
{
    public GameObject m_Camara;
    static bool other_side=false;

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra");
        if (other.tag == "Player")
        {
            Debug.Log("Player Entra");
                
            m_Camara.transform.Rotate(0, 180, 0);
          
            if (!other_side)
            {
                m_Camara.transform.position = new Vector3(m_Camara.transform.position.x, m_Camara.transform.position.y, 5);
                other.gameObject.transform.position=new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, -6);
                other_side = true;
            }
            else if (other_side)
            {
                m_Camara.transform.position = new Vector3(m_Camara.transform.position.x, m_Camara.transform.position.y, -23);
                other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, -12);
                other_side = false;
            }
        }
    }
}
