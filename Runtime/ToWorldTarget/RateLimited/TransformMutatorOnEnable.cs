using SOSXR.EditorTools;
using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    public class TransformMutatorOnEnable : MonoBehaviour
    {
        [SerializeField] private bool m_storeNewSettings;
        [Space(10)]
        [SerializeField] private Transform m_transformToChange;
        [Tooltip("AdditiveMode of course doesn't affect Scale :)")]
        [SerializeField] private bool m_additiveMode;
        [SerializeField] private Vector3 m_localPosition;
        [SerializeField] private Vector3 m_localRotation;
        [SerializeField] private Vector3 m_localScale = new(1, 1, 1);

        [Header("ORIGINAL")]
        [SerializeField] [DisableEditing] private Vector3 _oPos;
        [SerializeField] [DisableEditing] private Quaternion _oRot;
        [SerializeField] [DisableEditing] private Vector3 _oScale;


        private void Awake()
        {
            if (m_transformToChange != null)
            {
                return;
            }

            m_transformToChange = transform;
        }


        private void OnEnable()
        {
            m_storeNewSettings = false;

            StoreOriginalSettings();

            ApplyNewSettings();
        }


        private void Start()
        {
            m_storeNewSettings = false;

            StoreOriginalSettings();

            ApplyNewSettings();
        }


        private void StoreOriginalSettings()
        {
            _oPos = m_transformToChange.localPosition;
            _oRot = m_transformToChange.localRotation;
            _oScale = m_transformToChange.localScale;
        }


        private void ApplyNewSettings()
        {
            var localRotation = m_transformToChange.localRotation;

            if (m_additiveMode)
            {
                m_transformToChange.localPosition += m_localPosition;

                localRotation.eulerAngles += m_localRotation;
            }
            else
            {
                m_transformToChange.localPosition = m_localPosition;

                localRotation.eulerAngles = m_localRotation;
            }

            m_transformToChange.localRotation = localRotation;
            m_transformToChange.localScale = m_localScale;
        }


        private void Update()
        {
            if (!m_storeNewSettings)
            {
                return;
            }

            StoreNewSettings();
        }


        private void StoreNewSettings()
        {
            m_localPosition = m_transformToChange.localPosition;
            m_localRotation = m_transformToChange.localRotation.eulerAngles;
            m_localScale = m_transformToChange.localScale;
        }


        private void OnDisable()
        {
            ResetOrignalSettings();
        }


        private void ResetOrignalSettings()
        {
            m_transformToChange.localPosition = _oPos;
            m_transformToChange.localRotation = _oRot;
            m_transformToChange.localScale = _oScale;
        }
    }
}