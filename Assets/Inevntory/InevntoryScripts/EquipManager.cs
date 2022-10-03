using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public Inevntory MyEquip;

    public static int hp;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MyEquip.itemList[0] != null)
        {
            //Debug.Log(hp);
            hp = MyEquip.itemList[0].hp;
        }
        else
        {
            hp = 0;
        }
    }
}
