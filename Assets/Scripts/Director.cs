using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Director : MonoBehaviour
{
    public PlayableDirector timeline1;
    public PlayableDirector timeline2;
    public PlayableDirector timeline3;
    public PlayableDirector timeline4;
    public PlayableDirector timeline5;

    void Start()
    {
        // Set up event listeners for each timeline
        timeline1.stopped += OnTimeline1Stopped;
        timeline2.stopped += OnTimeline2Stopped;
        timeline3.stopped += OnTimeline3Stopped;
        timeline4.stopped += OnTimeline4Stopped;

        // Start playing the first timeline
        timeline1.Play();
    }

    private void OnTimeline1Stopped(PlayableDirector director)
    {
        // Unsubscribe to prevent multiple calls
        timeline1.stopped -= OnTimeline1Stopped;
        // Play the second timeline
        timeline2.Play();
    }

    private void OnTimeline2Stopped(PlayableDirector director)
    {
        timeline2.stopped -= OnTimeline2Stopped;
        timeline3.Play();
    }

    private void OnTimeline3Stopped(PlayableDirector director)
    {
        timeline3.stopped -= OnTimeline3Stopped;
        timeline4.Play();
    }
    private void OnTimeline4Stopped(PlayableDirector director)
    {
        timeline3.stopped -= OnTimeline4Stopped;
        timeline5.Play();
    }
}
