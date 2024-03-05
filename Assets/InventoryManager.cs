using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Dictionary<string, int> itemDictionary = new Dictionary<string, int>();

    public void AddItem(string itemName)
    {
        if (itemDictionary.ContainsKey(itemName))
        {
            itemDictionary[itemName]++;
        }
        else
        {
            itemDictionary[itemName] = 1;
        }
    }

    public void RemoveItem(string itemName)
    {
        if (itemDictionary.ContainsKey(itemName))
        {
            itemDictionary[itemName]--;
            if (itemDictionary[itemName] <= 0)
            {
                itemDictionary.Remove(itemName);
            }
        }
    }

    public List<string> GetItemList()
    {
        List<string> itemList = new List<string>(itemDictionary.Keys);
        return itemList;
    }

    public int GetItemCount(string itemName)
    {
        if (itemDictionary.ContainsKey(itemName))
        {
            return itemDictionary[itemName];
        }
        else
        {
            return 0;
        }
    }
}
