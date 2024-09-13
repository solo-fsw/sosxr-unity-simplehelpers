using UnityEngine;


namespace SOSXR.debugging
{
    /// <summary>
    ///     Make the clip respond to time scale changes. Basically only used for testing.
    /// </summary>
    public class MatchAudioSpeedToTimeSpeed : MonoBehaviour
    {
        private AudioSource[] _sources;
        private TimeControllerScript _tcs;


        private void Awake()
        {
            _tcs = FindObjectOfType<TimeControllerScript>();
        }


        private void Start()
        {
            _tcs.ChangedTimeScale += HighSpeedAudioEnabler; // Subscribe to UnityAction on the tcs, which fires if the timescale has changed
            HighSpeedAudioEnabler();
        }


        private void OnDisable()
        {
            if (_tcs.ChangedTimeScale != null)
            {
                _tcs.ChangedTimeScale -= HighSpeedAudioEnabler; // Unsubscribe
            }
        }


        private void HighSpeedAudioEnabler()
        {
            _sources = FindObjectsOfType<AudioSource>();

            foreach (var s in _sources)
            {
                s.pitch = Time.timeScale;
            }
        }
    }
}