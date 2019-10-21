using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class CraftingSystem : MonoBehaviour
{

    public Stack<CraftingItems> craftingQueue = new Stack<CraftingItems>();
    [SerializeField]
    public CraftingItems[] craftingItems;

    public int currentMatA = 0;
    public int currentMatB = 0;

    public int level = 1;
    public bool mali = true;

    public float craftingTime = 2.0f;

    private float currentCraft = 0;

    private CraftingItems m_currentlyCraftingItem;
    public Action<int> m_callbackCrafting;

    private void Start()
    {
        Debug.Log(m_currentlyCraftingItem);


    }

    public float CompletionCraftPercent
    {
        get { return Mathf.Abs((currentCraft / craftingTime) - 1); }
    }

    public void CheckCraft()
    {
        if (mali)
        {
            if (craftingItems[level - 1].costMaterialA <= currentMatA && craftingItems[level - 1].costMaterialB <= currentMatB)
            {
                currentMatA -= craftingItems[level - 1].costMaterialA;
                currentMatB -= craftingItems[level - 1].costMaterialB;
                craftingQueue.Push(craftingItems[level - 1]);   // push add an object on the stack
            }
        }
        else    // scott and sanyin
        {
            if (craftingItems[level - 1].boysA <= currentMatA && craftingItems[level - 1].boysB <= currentMatB)
            {
                currentMatA -= craftingItems[level - 1].boysA;
                currentMatB -= craftingItems[level - 1].boysB;
                craftingQueue.Push(craftingItems[level - 1]);
            }
        }

    }

    public void ProcessQueue()
    {
        if (craftingQueue.Count > 0)
        {

            if (currentCraft <= 0 && m_currentlyCraftingItem == null)
            {
                currentCraft = craftingTime;
                m_currentlyCraftingItem = craftingQueue.Peek();  //Pop: remove and return the first object on the stack. Peek: get the first object without removing it.
                Debug.Log("craftingQueue:" + craftingQueue.Count);
            }
            else
            {
                currentCraft -= Time.deltaTime;
                if (currentCraft <= 0 && m_currentlyCraftingItem != null)
                {
                    m_callbackCrafting?.Invoke(m_currentlyCraftingItem.iconID);
                    m_currentlyCraftingItem = null;
                }
            }
        }
    }


    public void Update()
    {
        CheckCraft();
        ProcessQueue();
    }

}
