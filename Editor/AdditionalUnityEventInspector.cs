using UnityEditor;
using UnityEngine;


namespace SOSXR.AdditionalUnityEvents.Editor
{
    [CustomEditor(typeof(AdditionalUnityEvent))]
    public class AdditionalUnityEventInspector : UnityEditor.Editor
    {
        private SerializedProperty m_triggerEventOn;
        private SerializedProperty m_autoStart;
        private SerializedProperty m_secondsToWaitAfterCalling;
        private SerializedProperty m_tagsToCheckAgainst;
        private SerializedProperty m_inputAction;
        private SerializedProperty m_initialFireInterval;
        private SerializedProperty m_perIntervalChange;
        private SerializedProperty m_minMax;


        private void OnEnable()
        {
            m_triggerEventOn = serializedObject.FindProperty("m_triggerEventOn");
            m_autoStart = serializedObject.FindProperty("m_autoStart");
            m_secondsToWaitAfterCalling = serializedObject.FindProperty("m_secondsToWaitAfterCalling");
            m_tagsToCheckAgainst = serializedObject.FindProperty("m_tagsToCheckAgainst");
            m_inputAction = serializedObject.FindProperty("m_inputAction");
            m_initialFireInterval = serializedObject.FindProperty("m_initialFireInterval");
            m_perIntervalChange = serializedObject.FindProperty("m_perIntervalChange");
            m_minMax = serializedObject.FindProperty("m_minMax");
        }


        public override void OnInspectorGUI()
        {
            CustomInspectorContent();
        }


        protected void CustomInspectorContent()
        {
            serializedObject.Update();

            // Get the value of m_triggerEventOn as the enum value
            var triggerEventOnValue = (UnityEventTrigger) m_triggerEventOn.intValue;

            // Display the triggerEventOn field
            EditorGUILayout.PropertyField(m_triggerEventOn);

            // Only show autoStart and other settings if VariableIntervalLoop is selected
            if (triggerEventOnValue.HasFlag(UnityEventTrigger.VariableIntervalLoop))
            {
                EditorGUILayout.PropertyField(m_autoStart);
                EditorGUILayout.PropertyField(m_initialFireInterval);
                EditorGUILayout.PropertyField(m_perIntervalChange);
                EditorGUILayout.PropertyField(m_minMax);

                serializedObject.ApplyModifiedProperties();

                return;
            }

            if (triggerEventOnValue.HasFlag(UnityEventTrigger.Update) ||
                triggerEventOnValue.HasFlag(UnityEventTrigger.FixedUpdate) ||
                triggerEventOnValue.HasFlag(UnityEventTrigger.LateUpdate) ||
                triggerEventOnValue.HasFlag(UnityEventTrigger.VariableIntervalLoop) ||
                triggerEventOnValue.HasFlag(UnityEventTrigger.OnCollisionStay) ||
                triggerEventOnValue.HasFlag(UnityEventTrigger.OnTriggerStay))
            {
                m_secondsToWaitAfterCalling.floatValue = 0;

                using (new EditorGUI.DisabledGroupScope(true))
                {
                    EditorGUILayout.PropertyField(m_secondsToWaitAfterCalling);
                }
            }
            else
            {
                EditorGUILayout.PropertyField(m_secondsToWaitAfterCalling);
            }

            // Show tags only if one of the trigger/collider flags is set
            if (triggerEventOnValue.HasFlag(UnityEventTrigger.OnTriggerEnter) ||
                triggerEventOnValue.HasFlag(UnityEventTrigger.OnTriggerStay) ||
                triggerEventOnValue.HasFlag(UnityEventTrigger.OnTriggerExit) ||
                triggerEventOnValue.HasFlag(UnityEventTrigger.OnCollisionEnter) ||
                triggerEventOnValue.HasFlag(UnityEventTrigger.OnCollisionStay) ||
                triggerEventOnValue.HasFlag(UnityEventTrigger.OnCollisionExit))
            {
                EditorGUILayout.PropertyField(m_tagsToCheckAgainst);
            }

            if (triggerEventOnValue.HasFlag(UnityEventTrigger.OnInputAction))
            {
                EditorGUILayout.PropertyField(m_inputAction);
            }

            if (GUILayout.Button(nameof(AdditionalUnityEvent.FireEvent)))
            {
                ((AdditionalUnityEvent) target).FireEvent();
            }

            if (GUILayout.Button(nameof(AdditionalUnityEvent.StopFiring)))
            {
                ((AdditionalUnityEvent) target).StopFiring();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}