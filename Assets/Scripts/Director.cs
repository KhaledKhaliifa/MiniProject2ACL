using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Director : MonoBehaviour
{
    
    public PlayableDirector timeline1;
    public PlayableDirector timeline2;
    public PlayableDirector timeline3;
    public PlayableDirector timeline4;
    public PlayableDirector timeline5;
    public PlayableDirector timeline6;
    public PlayableDirector timeline7;

    [SerializeField] public GameObject uiPanel; 
    public GameObject winPanel;
    public GameObject losePanel;
    public Button button1; 
    public Button button2; 
    bool kill = false;
    private void Start()
    {

        // Set up event listeners for each timeline
        timeline1.stopped += OnTimeline1Stopped;
        timeline2.stopped += OnTimeline2Stopped;
        timeline3.stopped += OnTimeline3Stopped;
        timeline4.stopped += OnTimeline4Stopped;
        timeline5.stopped += OnTimeline5Stopped;
        timeline6.stopped += OnTimeline6Stopped;
        timeline7.stopped += OnTimeline7Stopped;

        uiPanel.SetActive(false);

        button1.onClick.AddListener(PlayHostage);
        button2.onClick.AddListener(PlayKillPolice);

        timeline1.Play();
        AudioManagerForLoud.Instance.PlayMusic();
    }

    private void OnTimeline1Stopped(PlayableDirector director)
    {
        timeline1.stopped -= OnTimeline1Stopped;
        timeline2.Play();
    }

    private void OnTimeline2Stopped(PlayableDirector director)
    {
        timeline2.stopped -= OnTimeline2Stopped;
        PauseGameAndShowUI();
    }

    private void OnTimeline3Stopped(PlayableDirector director)
    {
        timeline3.stopped -= OnTimeline3Stopped;
        timeline7.Play();
    }

    private void OnTimeline4Stopped(PlayableDirector director)
    {
        timeline4.stopped -= OnTimeline4Stopped;
        timeline7.Play();

    }
    private void OnTimeline5Stopped(PlayableDirector director)
    {
        timeline5.stopped -= OnTimeline4Stopped;
        winPanel.SetActive(true);
        // Show win
    }
    private void OnTimeline6Stopped(PlayableDirector director)
    {
        timeline4.stopped -= OnTimeline4Stopped;
        losePanel.SetActive(true);
        //show lose
    }
    private void OnTimeline7Stopped(PlayableDirector director)
    {
        timeline7.stopped -= OnTimeline4Stopped;
        if (kill)
        {
            timeline6.Play();
        }
        else
        {
            timeline5.Play();
        }
    }

    private void PauseGameAndShowUI()
    {
        // Pause the game and music, show the UI panel
        Time.timeScale = 0;
        AudioManagerForLoud.Instance.PauseMusic();
        uiPanel.SetActive(true);
    }

    private void ResumeGame()
    {
        // Resume the game and music, hide the UI panel
        Time.timeScale = 1;
        AudioManagerForLoud.Instance.ResumeMusic();
        uiPanel.SetActive(false);
    }

    private void PlayHostage()
    {
        kill = false;
        ResumeGame();
        timeline3.Play();
    }

    private void PlayKillPolice()
    {
        kill = true;
        ResumeGame();
        timeline4.Play();
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
