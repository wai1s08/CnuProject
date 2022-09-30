using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip Jump_sound;
    public static AudioClip Sword_sound;
    public static AudioClip Step_sound;
    
  

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        Jump_sound = Resources.Load<AudioClip>("30_Jump_03");
        Sword_sound = Resources.Load<AudioClip>("S_Whoosh_Stereo_2");
        Step_sound = Resources.Load<AudioClip>("12_Step_wood_03"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlayJump_sound()
    {
        audioSrc.PlayOneShot(Jump_sound);
    }

    public static void PlaySword_sound()
    {
        audioSrc.PlayOneShot(Sword_sound);
    }
    public static void PlayStep_sound()
    {
        audioSrc.PlayOneShot(Step_sound);
    }
}
