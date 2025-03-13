using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEffects : MonoBehaviour
{
    // These are for hovering the power ups.
    [SerializeField] private float hoverHeight = 0.5f;
    [SerializeField] private float hoverSpeed = 2f;

    // thise are for rotating the power ups.
    [SerializeField] private float rotationSpeed = 50f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        // This is for hovering
        float hoverY = Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        // Hover in original position
        transform.position = startPosition + new Vector3(0f, hoverY, 0f);
        // Rotation effect
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
