using UnityEngine;


public class RotateAroundWorldYAxis : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 10f; // Rotation speed in degrees per second


    private void Update()
    {
        // Rotate the object around the world Y axis at the specified speed
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}