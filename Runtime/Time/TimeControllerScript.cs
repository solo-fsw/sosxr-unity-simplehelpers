using System;
using SOSXR.Attributes;
using UnityEngine;
using UnityEngine.Events;


namespace SOSXR.debugging
{
    /// <summary>
    ///     This class handles time changes (for testing purposes mainly)
    ///     S = slow
    ///     P = pause
    ///     N = normal
    ///     F = fast
    /// </summary>
    public class TimeControllerScript : MonoBehaviour
    {
        [Tooltip("Whether the below bools should be set to false when in Build")]
        public bool uncheckInBuild;

        [Space(15)]
        [SerializeField] private bool allowChangingTimeScale;

        [SerializeField] private float increaseTimeScale = 2f;
        [SerializeField] private float decreaseTimeScale = 0.1f;

        private float _currentTimeScale;

        [Tooltip("Is being called whenever the timescale is changed")]
        [DisableEditing] public UnityAction ChangedTimeScale;


        private void Update()
        {
            if (allowChangingTimeScale != true)
            {
                return;
            }

            if (!Application.isEditor && uncheckInBuild)
            {
                return;
            }

            CheckForKeyboardInput();
            InvokeTimeChangeAction();
        }


        private void CheckForKeyboardInput()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (Time.timeScale > 0.1f + decreaseTimeScale)
                {
                    Time.timeScale -= decreaseTimeScale;
                }
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                Time.timeScale = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                Time.timeScale = 1f;
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                if (Time.timeScale < 100 - increaseTimeScale)
                {
                    Time.timeScale += increaseTimeScale;
                }
            }
        }


        private void InvokeTimeChangeAction()
        {
            if (Math.Abs(_currentTimeScale - Time.timeScale) < 0.01f)
            {
                return;
            }

            ChangedTimeScale?.Invoke(); // Run this UnityAction if the timescale has changed, but only if it has a listener
            _currentTimeScale = Time.timeScale;
        }
    }
}