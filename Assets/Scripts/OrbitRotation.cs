using UnityEngine;

public class OrbitRotation : MonoBehaviour
{
    [SerializeField] private float fRotationSpeed;

    [SerializeField] private Transform Earth;
    [SerializeField] private Vector3 Orbit;


    private void Update()
    {
        transform.RotateAround(Earth.position, Orbit, fRotationSpeed * Time.deltaTime);
    }
}
