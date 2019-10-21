using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{

    public int vidas = 4;
    UIManager _uiManager;
   

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
      
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(vidas);
        }
    }

    public void Vida()
    {
        vidas = vidas - 1;
        _uiManager.UpdateLives(vidas);
    }

    public void RestaurarVida()
    {
        if(vidas == 3)
        {
            vidas = vidas + 1;
            _uiManager.UpdateLives(vidas);
        }
        else
        {
            vidas = vidas + 2;
            _uiManager.UpdateLives(vidas);

        }
            
     
    }
  

   
}
