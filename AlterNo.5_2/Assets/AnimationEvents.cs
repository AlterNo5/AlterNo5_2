using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public GameObject secondForm;
    public void ChangeForm()
    {
        Invoke("activateForm", 2);
        
        this.gameObject.SetActive(false);

    }

    private void activateForm()
    {
        secondForm.SetActive(true);
    }
}

