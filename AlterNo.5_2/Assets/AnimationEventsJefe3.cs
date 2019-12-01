using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventsJefe3 : MonoBehaviour
{
    public GameObject secondForm;
    public void ChangeForm()
    {
        Invoke("activateForm", 1);
        
        this.gameObject.SetActive(false);
        transform.parent.GetComponent<BallBoss>().m_anim = secondForm.GetComponent<Animator>();
    }

    private void activateForm()
    {
        secondForm.SetActive(true);
    }
}

