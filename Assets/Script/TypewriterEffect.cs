using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TypewriterEffect : MonoBehaviour
{
    public float delay = 0.1f;
    private string[] fullTexts = {
        "打敗這座城堡主人的你，解決這裡最大的危機。\n\n出色地完成了此次的任務。",
        "感謝遊玩!"};
    private string currentText = "";
    private int currentIndex = 0;

    public GameObject end;

    private void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        while (true)
        {
            for (int i = 0; i <= fullTexts[currentIndex].Length; i++)
            {
                currentText = fullTexts[currentIndex].Substring(0, i);
                GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }

            while (!Input.anyKeyDown)
            {
                yield return null;
            }

            currentIndex++;
            if (currentIndex >= fullTexts.Length)
            {
                currentIndex = 0;
                end.SetActive(true);
                break;
            }

            currentText = "";
            GetComponent<Text>().text = currentText;
        }
    }

    public void Returntomenu()
    {
        SceneManager.LoadScene(0);
    }
}
