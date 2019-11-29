using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEvents : MonoBehaviour
{
    public InputGun inputGun;
    // Start is called before the first frame update
    void Start()
    {
        inputGun = GetComponentInParent<InputGun>();
    }

    void finishedAnimation()
    {
        inputGun.playingAnim = false;
    }
}
