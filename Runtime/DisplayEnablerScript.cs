using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    /// <summary>
    ///     Turns on all available screens
    /// </summary>
    public class DisplayEnablerScript : MonoBehaviour
    {
        [SerializeField] private bool m_useAllScreens = true;


        private void Awake()
        {
            if (m_useAllScreens != true)
            {
                return;
            }

            foreach (var display in Display.displays)
            {
                display.Activate();
            }
        }
    }
}