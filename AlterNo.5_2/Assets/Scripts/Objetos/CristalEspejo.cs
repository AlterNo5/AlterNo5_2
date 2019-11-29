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
            m_Camara.transform.position = new Vector3(m_Camara.transform.position.x, m_Camara.transform.position.y, -m_Camara.transform.position.z);
            m_Camara.transform.Rotate(0, 180, 0);
            if (!other_side)
            {
                other.gameObject.transform.Translate(0, 0, 1.2f);
                other_side = true;
            }
            else if (other_side)
            {
                other.gameObject.transform.Translate(0, 0, -1.2f);
                other_side = false;
            }

            
        }
    }
}
