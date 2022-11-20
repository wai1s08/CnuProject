using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSSROOM : MonoBehaviour
{
    private bool Boss = true;
    void FindBoss()
    {
        if (!GameObject.Find("Boss01") && Boss == true)
        {

            GameObject.Find("B-HP").GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GameObject.Find("B-HP1").GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GameObject.Find("B_HPText").GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }
}


