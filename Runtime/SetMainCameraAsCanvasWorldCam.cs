using UnityEngine;


namespace SOSXR.SimpleHelpers
{
    [RequireComponent(typeof(Canvas))]
    public class SetMainCameraAsCanvasWorldCam : MonoBehaviour
    {
        [SerializeField] [HideInInspector] private Canvas _canvas;


        private void OnValidate()
        {
            if (_canvas != null)
            {
                return;
            }

            _canvas = GetComponent<Canvas>();

            FindWorldCamera();
        }


        private void Awake()
        {
            FindWorldCamera();
        }


        private void Update()
        {
            FindWorldCamera();
        }


        private void FindWorldCamera()
        {
            if (_canvas.worldCamera == null && Camera.main != null)
            {
                _canvas.worldCamera = Camera.main;

                return;
            }

            enabled = false; // Disable this component as soon as we find a camera
        }
    }
}