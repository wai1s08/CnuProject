using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//創建背包

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/new Inventory")]
public class Inevntory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
