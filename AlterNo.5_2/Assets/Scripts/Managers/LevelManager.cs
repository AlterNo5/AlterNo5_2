using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform m_limiteSuperior_obj;
    public Transform m_limiteInferior_obj;


    

    // Start is called before the first frame update


    public void Awake()
    {
        GameManager.Instance.InitLevel(this);

       
    }
}
