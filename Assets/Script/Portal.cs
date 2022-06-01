using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // 傳送到場景幾
    [Header("傳送到場景")]
    public int Scene;

    //玩家死亡後重生在場景幾
    [Header("死亡後重生在場景")]
    public int PlayerScene;

    [Header("傳送至哪個傳送點")]
    public int PortalNumber;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.tag = "Portal";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(Scene);

        initPlayer.PlayerSpawnScene = PlayerScene;
        CheckInit.StartPlayerNumber = PortalNumber;


    }
}
