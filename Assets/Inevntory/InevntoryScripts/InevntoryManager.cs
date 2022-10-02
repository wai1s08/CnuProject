using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Inevntory管理器
public class InevntoryManager : MonoBehaviour
{
    //背包管理器的靜態變數
    static InevntoryManager instance;

    [Header("背包")]//要將物品生成至哪個背包
    public Inevntory myBag;

    public Inevntory myEquip;

    [Header("背包裡的網格")]//將物品依照這個格式排序生成
    public GameObject slotGrid;

    public GameObject EquipGrid;

    [Header("Slot預製物")]
    public GameObject emptySlot;

    public GameObject EquipemptySlot;

    [Header("背包裡物品的說明欄")]
    public Text itemfromation;

    public Text itemtype;

    public List<GameObject> slots = new List<GameObject>();

    public List<GameObject> Equipslots = new List<GameObject>();

    public Slot slot;

 
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }


    //在遊戲開始時就刷新整個背包物品
    private void OnEnable()
    {
        RefreshItem();
        RefreshEquip();

        //遊戲開始時背包說明欄為空
        instance.itemfromation.text = "";
    }


    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemfromation.text = itemDescription;
    }
   


    //刷新物品的方法
    public static void RefreshItem()
    {
        //當i < instance.slotGrid.transform.childCount這個目錄下的子級 = 將所有目錄刪除
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            //如果子級數量為0 結束這個方法
            if (instance.slotGrid.transform.childCount == 0)
                break;

            //銷毀gameObject
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        //重新生成物品 | 檢查myBag.itemList裡有多少物品就生成幾次
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            // 生成myBag.itemList的所有數據
            //CreateNewItem(instance.myBag.itemList[i]);

            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);

            instance.slots[i].GetComponent<Slot>().slotID = i;
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);

            instance.slots[i].GetComponent<Slot>().itemEquip = false;

        }
        
    }

    public static void RefreshEquip()
    {
        //裝備
        for (int i = 0; i < instance.emptySlot.transform.childCount; i++)
        {
            //如果子級數量為0 結束這個方法
            if (instance.EquipGrid.transform.childCount == 0)
                break;

            //銷毀gameObject
            Destroy(instance.EquipGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for (int i = 0; i < instance.myEquip.itemList.Count; i++)
        {
            // 生成myBag.itemList的所有數據
            //CreateNewItem(instance.myBag.itemList[i]);

            instance.Equipslots.Add(Instantiate(instance.EquipemptySlot));

            instance.Equipslots[i].transform.SetParent(instance.EquipGrid.transform);

            instance.Equipslots[i].GetComponent<Slot>().slotID = i;
            instance.Equipslots[i].GetComponent<Slot>().equipID = i;

            instance.Equipslots[i].GetComponent<Slot>().SetupSlot(instance.myEquip.itemList[i]);

            instance.Equipslots[i].GetComponent<Slot>().itemEquip = true;

        }

    }

    
}
