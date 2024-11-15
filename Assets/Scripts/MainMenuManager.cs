
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;   
    public GameObject creditsPanel;    

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    // Function for the Start button
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Bank front");
    }

    public void OnCreditsButtonClick()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void OnBackButtonClick()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void OnExitButtonClick()
    {

        Application.Quit();
    }
    
}
