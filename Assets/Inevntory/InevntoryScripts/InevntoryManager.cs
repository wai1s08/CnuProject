using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Inevntory管理器
public class InevntoryManager : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //背包管理器的靜態變數
    static InevntoryManager instance;

    [Header("背包")]//要將物品生成至哪個背包
    public Inevntory myBag;

    [Header("背包裡的網格")]//將物品依照這個格式排序生成
    public GameObject slotGrid;

    [Header("slot預製物")]
    public Slot slotPrefab;

    [Header("背包裡物品的說明欄")]
    public Text itemfromation;

    [SerializeField] private GameObject InventoryPanel;
    private RectTransform panel_rect_transform;
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

        //遊戲開始時背包說明欄為空
        instance.itemfromation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemfromation.text = itemDescription;
    }

    //創建新物品的方法 | 獲取item.cs裡的所有訊息，將訊息傳輸給slot.cs
    public static void CreateNewItem(Item item)
    {
        //生成一個Slot類的物品
        Slot newItme = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);

        // SetParent 設置父級 | 將物品生成於instance.slotGrid的子級
        newItme.gameObject.transform.SetParent(instance.slotGrid.transform);

        //傳輸數據
        newItme.slotItem = item;
        newItme.slotImage.sprite = item.itemimage;
        newItme.slotNum.text = item.itemHeld.ToString();
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
        }

        //重新生成物品 | 檢查myBag.itemList裡有多少物品就生成幾次
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            // 生成myBag.itemList的所有數據
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    panel_rect_transform = InventoryPanel.GetComponent<RectTransform>();
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    panel_rect_transform.anchoredPosition += eventData.delta;
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{

    //}
}
