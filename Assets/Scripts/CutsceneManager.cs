using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector tl;
    public bool isPaused;

    public void TimelineManip()
    {
        isPaused = !isPaused;

        if (isPaused) tl.Play();
        else tl.Pause();
    }
}
