using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    // Minimum camera size
    private float minSize = 5.0f;
    // Optional padding around the objects
    private float padding = 1.0f;
    // Main camera
    private Camera mainCamera;

    /// <summary>
    /// Method to define the main camera
    /// </summary>
    private void Start()
    {
        mainCamera = Camera.main;
    }

    /// <summary>
    /// Method called to adjust the camera position based on the grid size
    /// </summary>
    /// <param name="gridSizeX">Grid size X</param>
    /// <param name="gridSizeY">Grid size Y</param>
    /// <param name="sizeAdd">Optional size to add</param>
    public void CalculateCameraPosition(int gridSizeX, int gridSizeY, float sizeAdd = 0f)
    {
        // Calculates the target position based on the grid size
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

    /// <summary>
    /// Method called to adjust the camera size based on the grid size
    /// </summary>
    /// <param name="gridSizeX">Grid size X</param>
    /// <param name="gridSizeY">Grid size Y</param>
    /// <returns>New adjusted camera size</returns>
    public float CalculateCameraSize(int gridSizeX, int gridSizeY)
    {
        // Calculate the camera size to fit the grid size with padding
        float gridSizeXWithPadding = gridSizeX + padding * 2;
        float gridSizeYWithPadding = gridSizeY + padding * 2;

        return Mathf.Max(gridSizeXWithPadding, gridSizeYWithPadding);
    }
}
