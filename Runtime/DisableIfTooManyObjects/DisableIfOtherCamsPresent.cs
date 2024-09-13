using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    [RequireComponent(typeof(Camera))]
    public class DisableIfOtherCamsPresent : DisableIfMaxNumberOfIdenticalObjectsInScene
    {
        private void OnEnable()
        {
            DisableIfTooManyObjectsFound(GetComponent<Camera>());
        }
    }
}