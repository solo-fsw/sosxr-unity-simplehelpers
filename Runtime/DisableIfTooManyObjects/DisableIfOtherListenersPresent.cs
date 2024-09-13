using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    [RequireComponent(typeof(AudioListener))]
    public class DisableIfOtherListenersPresent : DisableIfMaxNumberOfIdenticalObjectsInScene
    {
        private void OnEnable()
        {
            DisableIfTooManyObjectsFound(GetComponent<AudioListener>());
        }
    }
}