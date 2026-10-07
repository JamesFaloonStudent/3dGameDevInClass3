using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainSceneScript : MonoBehaviour
{
    public TextMeshProUGUI instructionsText;
    public Button button;
    public Canvas canvas;

    int getNumberOfClicks()
    {
        return PlayerPrefs.GetInt("Clicks", 0);
    }

    void addClick()
    {
        PlayerPrefs.SetInt("Clicks", getNumberOfClicks() + 1);
    }

    void Start()
    {
        instructionsText.text = "";
    }

    // three if statements if the user has yet to click say that the user clicked button 
    // if they have clicked less then 3 times say how many times they have clicked 
    // if they have clcked three or more turn off canvas and isntructions text 
    public void clickButton()
    {
        if (!PlayerPrefs.HasKey("Clicks"))
        {
            PlayerPrefs.SetInt("Clicks", 1);
            instructionsText.text = "you clicked button";
        }
        else if (getNumberOfClicks() < 3)
        {
            addClick();
            instructionsText.text = $"you clicked button {getNumberOfClicks()} times";
        }
        else
        {
            instructionsText.text = "";
            canvas.gameObject.SetActive(false);
        }
    }
}
