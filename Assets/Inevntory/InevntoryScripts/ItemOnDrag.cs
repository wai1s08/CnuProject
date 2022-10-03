using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    static InevntoryManager instance;

    public Inevntory myBag;

    public Inevntory MyEquip;

    public int currentItemID; // 當前物品ID

    public string currentItemType; //當前物品type

    public bool currentItemEquipStatus;

    public string lookItemType; // 當前指著的物品類

    public Transform originalParent; //原本的父級

    public Slot slot;

    public bool IsEquiping = false;


    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;

        currentItemID = originalParent.GetComponent<Slot>().slotID;

        currentItemType = originalParent.GetComponent<Slot>().itemtype;

        currentItemEquipStatus = originalParent.GetComponent<Slot>().Equiping;

        transform.SetParent(transform.parent.parent.parent.parent.parent);

        transform.position = eventData.position;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

        lookItemType = eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().itemtype;

        //Debug.Log("格子" + eventData.pointerCurrentRaycast.gameObject.name);

        //Debug.Log(currentItemType);

        // Debug.Log("格子" + eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().itemEquip);

        // Debug.Log(eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().itemEquip);

        Debug.Log(currentItemEquipStatus);

        Debug.Log("原本的類" + lookItemType);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            //如果射線 = item Image //物品互換
            if (eventData.pointerCurrentRaycast.gameObject.name == "item Image")
            {
                //如果這個item Image是裝備欄的話
                if (eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().itemEquip == true)
                {
                    if (currentItemType == "hat" && eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().equipID == 0)
                    {
                        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                        //數據交換
                        var temp = myBag.itemList[currentItemID];

                        myBag.itemList[currentItemID] = MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];

                        MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

                        eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                        eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);


                        GetComponent<CanvasGroup>().blocksRaycasts = true;

                        return;
                    }

                    if (currentItemType == "sword" && eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().equipID == 1)
                    {
                        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                        //數據交換
                        var temp = myBag.itemList[currentItemID];

                        myBag.itemList[currentItemID] = MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];

                        MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

                        eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                        eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);


                        GetComponent<CanvasGroup>().blocksRaycasts = true;
                        return;
                    }

                    if (currentItemType == "top" && eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().equipID == 2)
                    {
                        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                        var temp = myBag.itemList[currentItemID];

                        myBag.itemList[currentItemID] = MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];

                        MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

                        eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                        eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);


                        GetComponent<CanvasGroup>().blocksRaycasts = true;
                        return;
                    }

                    if (currentItemType == "shield" && eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().equipID == 4)
                    {
                        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                        //數據交換
                        var temp = myBag.itemList[currentItemID];

                        myBag.itemList[currentItemID] = MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];

                        MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;


                        eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                        eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);


                        GetComponent<CanvasGroup>().blocksRaycasts = true;
                        return;
                    }

                    if (currentItemType == "bottom" && eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().equipID == 5)
                    {
                        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                        //數據交換
                        var temp = myBag.itemList[currentItemID];

                        myBag.itemList[currentItemID] = MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];

                        MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;


                        eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                        eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);


                        GetComponent<CanvasGroup>().blocksRaycasts = true;
                        return;
                    }

                    if (currentItemType == "pendant" && eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().equipID == 6)
                    {
                        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                        //數據交換
                        var temp = myBag.itemList[currentItemID];

                        myBag.itemList[currentItemID] = MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];

                        MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;


                        eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                        eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);


                        GetComponent<CanvasGroup>().blocksRaycasts = true;
                        return;
                    }

                    if (currentItemType == "shoes" && eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().equipID == 7)
                    {
                        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                        //數據交換
                        var temp = myBag.itemList[currentItemID];

                        myBag.itemList[currentItemID] = MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];

                        MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;


                        eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                        eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);


                        GetComponent<CanvasGroup>().blocksRaycasts = true;
                        return;
                    }

                    if (currentItemType == "ring" && eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().equipID == 8)
                    {
                        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                        //數據交換
                        var temp = myBag.itemList[currentItemID];

                        myBag.itemList[currentItemID] = MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];

                        MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;


                        eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                        eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);


                        GetComponent<CanvasGroup>().blocksRaycasts = true;
                        return;
                    }
                }

                //如果是物品欄的處理方式
                if (eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().itemEquip == false)
                {
                    //物品互換
                    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;



                    //臨時變量 = 背包當前物品格的ID
                    var temp = myBag.itemList[currentItemID];

                    // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
                    myBag.itemList[currentItemID] = myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];

                    //回傳
                    myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

                    //
                    eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                    eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);

                    //我指向的這個格子的itemtype 更改為 我原先的itemtype
                    eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().itemtype = currentItemType;

                    //將原先父級的itemtype 更改為 我看著的這個物品的itemtype
                    originalParent.gameObject.GetComponent<Slot>().itemtype = lookItemType;

                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }

            }

            //放到空格
            if (eventData.pointerCurrentRaycast.gameObject.name == "Slot(Clone)")
            {
                if (currentItemEquipStatus == true)
                {
                    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                    //將我放置那格的物品種類 更改為 我原來物品的種類
                    eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().itemtype = currentItemType;

                    myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = MyEquip.itemList[currentItemID];

                    //如果我放下的那格不是原先的位子
                    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID != currentItemID)
                    {
                        MyEquip.itemList[currentItemID] = null;
                        originalParent.gameObject.GetComponent<Slot>().itemtype = null;
                    }

                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;

                }
                else
                {
                    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                    //將我放置那格的物品種類 更改為 我原來物品的種類
                    eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().itemtype = currentItemType;


                    myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = myBag.itemList[currentItemID];


                    //如果我放下的那格不是原先的位子
                    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID != currentItemID)
                    {
                        myBag.itemList[currentItemID] = null;
                        originalParent.gameObject.GetComponent<Slot>().itemtype = null;
                    }

                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }
                



            }

            if (eventData.pointerCurrentRaycast.gameObject.name == "EquipemptySlot(Clone)")
            {
                if (currentItemType == "hat" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID == 0)
                {
                    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                    // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
                    MyEquip.itemList[0] = myBag.itemList[currentItemID];

                    //將我放置那格的物品種類 更改為 我原來物品的種類
                    eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().itemtype = currentItemType;

                    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID != currentItemID)
                    {
                        myBag.itemList[currentItemID] = null;
                    }

                    eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().Equiping = true;
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }

                if (currentItemType == "sword" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID == 1)
                {
                    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                    // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
                    MyEquip.itemList[1] = myBag.itemList[currentItemID];

                    //將我放置那格的物品種類 更改為 我原來物品的種類
                    eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().itemtype = currentItemType;

                    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID != currentItemID)
                    {
                        myBag.itemList[currentItemID] = null;
                    }

                    eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().Equiping = true;
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }

                if (currentItemType == "top" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID == 2)
                {
                    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                    // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
                    MyEquip.itemList[2] = myBag.itemList[currentItemID];

                    //將我放置那格的物品種類 更改為 我原來物品的種類
                    eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().itemtype = currentItemType;

                    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID != currentItemID)
                    {
                        myBag.itemList[currentItemID] = null;
                    }

                    eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().Equiping = true;
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }

                if (currentItemType == "shield" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID == 3)
                {
                    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                    // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
                    MyEquip.itemList[3] = myBag.itemList[currentItemID];

                    //將我放置那格的物品種類 更改為 我原來物品的種類
                    eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().itemtype = currentItemType;

                    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID != currentItemID)
                    {
                        myBag.itemList[currentItemID] = null;
                    }

                    eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().Equiping = true;
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }

                if (currentItemType == "bottom" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID == 4)
                {
                    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                    // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
                    MyEquip.itemList[4] = myBag.itemList[currentItemID];

                    //將我放置那格的物品種類 更改為 我原來物品的種類
                    eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().itemtype = currentItemType;

                    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID != currentItemID)
                    {
                        myBag.itemList[currentItemID] = null;
                    }

                    eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().Equiping = true;
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }

                if (currentItemType == "pendant" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID == 5)
                {
                    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                    // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
                    MyEquip.itemList[5] = myBag.itemList[currentItemID];

                    //將我放置那格的物品種類 更改為 我原來物品的種類
                    eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().itemtype = currentItemType;

                    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID != currentItemID)
                    {
                        myBag.itemList[currentItemID] = null;
                    }

                    eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().Equiping = true;
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }

                if (currentItemType == "shoes" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID == 6)
                {
                    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                    // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
                    MyEquip.itemList[6] = myBag.itemList[currentItemID];

                    //將我放置那格的物品種類 更改為 我原來物品的種類
                    eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().itemtype = currentItemType;

                    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID != currentItemID)
                    {
                        myBag.itemList[currentItemID] = null;
                    }

                    eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().Equiping = true;
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }

                if (currentItemType == "ring" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID == 7)
                {
                    transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                    // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
                    MyEquip.itemList[7] = myBag.itemList[currentItemID];

                    //將我放置那格的物品種類 更改為 我原來物品的種類
                    eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().itemtype = currentItemType;

                    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID != currentItemID)
                    {
                        myBag.itemList[currentItemID] = null;
                    }

                    eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().Equiping = true;
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }
            }
        }


        //其他位子都復原
        transform.SetParent(originalParent);
        transform.position = originalParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }


}