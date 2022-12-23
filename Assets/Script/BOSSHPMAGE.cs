using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSSHPMAGE : MonoBehaviour
{

    public int B_HPCurrent;
    public int B_HPMAX;
    private Image BOSS_Image;



    // Start is called before the first frame update
    void Start()
    {
        B_HPCurrent = GameObject.Find("Boss_Mage").GetComponent<EnemyMageAI>().health;
        B_HPMAX = B_HPCurrent;
        BOSS_Image = GetComponent<Image>();

    }


    void Update()
    {
        B_HPCurrent = GameObject.Find("Boss_Mage").GetComponent<EnemyMageAI>().health;
        BOSS_Image.fillAmount = (float)B_HPCurrent / (float)B_HPMAX;

    }
}
