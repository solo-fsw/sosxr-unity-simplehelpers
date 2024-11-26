using UnityEditor;
using UnityEngine;


namespace SOSXR.SimpleHelpers.Editor
{
    [CustomEditor(typeof(Move))]
    public class MoveEditor : UnityEditor.Editor
    {
        // Cached SerializedProperties
        private SerializedProperty actionToTakeProp;
        private SerializedProperty targetProp;
        private SerializedProperty velocityProp;
        private SerializedProperty rotationSpeedProp;
        private SerializedProperty smoothTimeProp;
        private SerializedProperty offsetProp;
        private SerializedProperty bezierPointsProp;
        private SerializedProperty localMoveSpeedProp;
        private SerializedProperty orbitRadiusProp;
        private SerializedProperty orbitSpeedProp;
        private SerializedProperty amplitudeProp;
        private SerializedProperty frequencyProp;
        private SerializedProperty bounceStartPointProp;
        private SerializedProperty bounceEndPointProp;
        private SerializedProperty bounceSpeedProp;
        private SerializedProperty springForceProp;
        private SerializedProperty dampingProp;
        private SerializedProperty minimumHeightProp;
        private SerializedProperty maximumHeightProp;


        // Cache properties in OnEnable
        private void OnEnable()
        {
            // Cache all SerializedProperties
            actionToTakeProp = serializedObject.FindProperty("m_actionToTake");
            targetProp = serializedObject.FindProperty("m_target");
            velocityProp = serializedObject.FindProperty("m_velocity");
            rotationSpeedProp = serializedObject.FindProperty("m_rotationSpeed");
            smoothTimeProp = serializedObject.FindProperty("m_smoothTime");
            offsetProp = serializedObject.FindProperty("m_offset");
            bezierPointsProp = serializedObject.FindProperty("m_bezierPoints");
            localMoveSpeedProp = serializedObject.FindProperty("m_localMoveSpeed");
            orbitRadiusProp = serializedObject.FindProperty("m_orbitRadius");
            orbitSpeedProp = serializedObject.FindProperty("m_orbitSpeed");
            amplitudeProp = serializedObject.FindProperty("m_amplitude");
            frequencyProp = serializedObject.FindProperty("m_frequency");
            bounceStartPointProp = serializedObject.FindProperty("m_bounceStartPoint");
            bounceEndPointProp = serializedObject.FindProperty("m_bounceEndPoint");
            bounceSpeedProp = serializedObject.FindProperty("m_bounceSpeed");
            springForceProp = serializedObject.FindProperty("m_springForce");
            dampingProp = serializedObject.FindProperty("m_damping");
            minimumHeightProp = serializedObject.FindProperty("m_minimumHeight");
            maximumHeightProp = serializedObject.FindProperty("m_maximumHeight");
        }


        public override void OnInspectorGUI()
        {
            // Begin checking for changes
            EditorGUI.BeginChangeCheck();

            // Draw the ActionToTake enum first
            EditorGUILayout.PropertyField(actionToTakeProp);

            // Draw target field for most movement types (except MoveByOffset and MoveInLocalSpace)
            switch ((ActionToTake) actionToTakeProp.enumValueIndex)
            {
                case ActionToTake.ParentTo:
                case ActionToTake.SyncTransform:
                case ActionToTake.MoveTowards:
                case ActionToTake.LookAt:
                case ActionToTake.RotateTowards:
                case ActionToTake.SmoothMoveTowards:
                case ActionToTake.MoveInCircle:
                case ActionToTake.SmoothFollow:
                case ActionToTake.MoveWithElasticity:
                    DrawTargetField();

                    break;
            }

            // Conditionally draw fields based on selected ActionToTake
            switch ((ActionToTake) actionToTakeProp.enumValueIndex)
            {
                case ActionToTake.MoveTowards:
                case ActionToTake.SmoothMoveTowards:
                case ActionToTake.RotateTowards:
                    DrawVelocityField();

                    break;

                case ActionToTake.MoveByOffset:
                    DrawOffsetField();

                    break;

                case ActionToTake.MoveAlongPath:
                    DrawBezierPathFields();

                    break;

                case ActionToTake.MoveInLocalSpace:
                    DrawLocalMoveSpeedField();

                    break;

                case ActionToTake.MoveInCircle:
                    DrawOrbitFields();

                    break;

                case ActionToTake.MoveSinusoidally:
                    DrawSinusoidalFields();

                    break;

                case ActionToTake.BounceBackAndForth:
                    DrawBounceFields();

                    break;

                case ActionToTake.MoveWithElasticity:
                    DrawElasticityFields();

                    break;

                case ActionToTake.SmoothFollow:
                    DrawVelocityField();
                    DrawHeightConstraintsFields();

                    break;
            }

            // Apply changes
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }


        // Existing drawing methods remain the same, but use cached properties
        private void DrawTargetField()
        {
            EditorGUILayout.PropertyField(targetProp, new GUIContent("Target"));
        }


        private void DrawVelocityField()
        {
            EditorGUILayout.PropertyField(velocityProp, new GUIContent("Velocity"));

            // Rotation speed for RotateTowards
            if (actionToTakeProp.enumValueIndex == (int) ActionToTake.RotateTowards)
            {
                EditorGUILayout.PropertyField(rotationSpeedProp, new GUIContent("Rotation Speed"));
            }

            // Smooth time for SmoothFollow
            if (actionToTakeProp.enumValueIndex == (int) ActionToTake.SmoothFollow)
            {
                EditorGUILayout.PropertyField(smoothTimeProp, new GUIContent("Smooth Time"));
            }
        }


        // Other drawing methods follow the same pattern, replacing direct FindProperty calls with cached properties
        private void DrawOffsetField()
        {
            EditorGUILayout.PropertyField(offsetProp, new GUIContent("Movement Offset"));
        }


        private void DrawBezierPathFields()
        {
            EditorGUILayout.PropertyField(bezierPointsProp, new GUIContent("Bezier Points"));
        }


        private void DrawLocalMoveSpeedField()
        {
            EditorGUILayout.PropertyField(localMoveSpeedProp, new GUIContent("Local Move Speed"));
        }


        private void DrawOrbitFields()
        {
            EditorGUILayout.PropertyField(orbitRadiusProp, new GUIContent("Orbit Radius"));
            EditorGUILayout.PropertyField(orbitSpeedProp, new GUIContent("Orbit Speed"));
        }


        private void DrawSinusoidalFields()
        {
            EditorGUILayout.PropertyField(amplitudeProp, new GUIContent("Amplitude"));
            EditorGUILayout.PropertyField(frequencyProp, new GUIContent("Frequency"));
        }


        private void DrawBounceFields()
        {
            EditorGUILayout.PropertyField(bounceStartPointProp, new GUIContent("Bounce Start Point"));
            EditorGUILayout.PropertyField(bounceEndPointProp, new GUIContent("Bounce End Point"));
            EditorGUILayout.PropertyField(bounceSpeedProp, new GUIContent("Bounce Speed"));
        }


        private void DrawElasticityFields()
        {
            EditorGUILayout.PropertyField(springForceProp, new GUIContent("Spring Force"));
            EditorGUILayout.PropertyField(dampingProp, new GUIContent("Damping"));
        }


        private void DrawHeightConstraintsFields()
        {
            EditorGUILayout.PropertyField(minimumHeightProp, new GUIContent("Minimum Height"));
            EditorGUILayout.PropertyField(maximumHeightProp, new GUIContent("Maximum Height"));
        }
    }
}