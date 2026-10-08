using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingTimer : MonoBehaviour
{

    public int duration = 10;
    public TextMeshProUGUI loadingText;


    void Awake()
    {
        StartCoroutine(MyDelay(duration));
    }


    // calculate the remaining time and rounds to nearest whole number 
    void UpdateText(int elapsed)
    {
        int percent = Mathf.RoundToInt((float)elapsed / duration * 100f);
        loadingText.text = $"Loading Please Wait : {percent}%";
    }

    // a coruntine that adjusts loading time text based on how much time is left 
    IEnumerator MyDelay(int duration)
    {
        int elapsed = 0;
        UpdateText(elapsed);

        while (elapsed < duration)
        {
            yield return new WaitForSeconds(1f);
            elapsed++;
            UpdateText(elapsed);
        }

        SceneManager.LoadScene("MenuScene");

    }

}
