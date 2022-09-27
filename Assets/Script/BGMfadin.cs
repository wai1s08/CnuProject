using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMfadin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        bGMfadin();
    }

    void bGMfadin()
    {
        if (GetComponent<AudioSource>().volume <= 0.4f)
        {
            GetComponent<AudioSource>().volume += 0.001f;
        }
    }
}
