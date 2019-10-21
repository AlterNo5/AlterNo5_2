using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Text pecent;
    public Text Text;
    public int count;

    public CraftingSystem mc;


    public void Start()
    {
        mc.m_callbackCrafting += Count;
    }

    // Update is called once per frame
    void Update()
    {
        pecent.text = (mc.CompletionCraftPercent * 100).ToString() + "%";
    }


    public void Count(int id)
    {
        count++;
        Text.text = count.ToString();
    }
}
