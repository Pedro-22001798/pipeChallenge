using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    private float minSize = 5.0f; // Minimum camera size
    private float padding = 1.0f; // Optional padding around the objects

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Call this method to adjust the camera size and position based on the grid size
    public void CalculateCameraPosition(int gridSizeX, int gridSizeY, float sizeAdd = 0f)
    {
        // Calculate the target position based on the grid size
        //float targetX = (float)(gridSizeX + 1) / 2; // Grid center in X-axis
        // float targetY = (float)(-gridSizeY -1) / 2; // Grid center in Y-axis
        // float targetX = (float)Mathf.Min(gridSizeX/2);
        float targetX = (float)Math.Ceiling((float)gridSizeY/2f);
        float targetY = (float)-Math.Ceiling((float)gridSizeX/2f);
        Vector3 targetPosition = new Vector3(targetX, targetY, mainCamera.transform.position.z);

        // Set the camera position directly to the target position
        mainCamera.transform.position = targetPosition;

        // Calculate the camera's new size based on the grid size
        float newSize = CalculateCameraSize(gridSizeX,gridSizeY) + sizeAdd;

        // Ensure the camera size is not below the minimum size
        newSize = Mathf.Max(newSize, minSize);

        // Set the camera size directly to the new size
        mainCamera.orthographicSize = newSize;
    }

    public float CalculateCameraSize(int gridSizeX, int gridSizeY)
    {
        // Calculate the camera size to fit the grid size with padding
        float gridSizeXWithPadding = gridSizeX + padding * 2;
        float gridSizeYWithPadding = gridSizeY + padding * 2;

        return Mathf.Max(gridSizeXWithPadding, gridSizeYWithPadding);
    }
}
