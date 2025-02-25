using UnityEngine;

public class CameraBoundsHelper : MonoBehaviour
{
    private static Camera cam;

    private static void FindCam ()
    {
        cam = Camera.main;
    }

    public static Vector3 GetRandomPointInBounds()
    {
        // Get the screen size in world coordinates (this is equivalent to the camera's view area size)
        if (!cam) FindCam();

        // Define the screen boundaries in world coordinates
        Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.transform.position.y));
        Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.y));

        // Generate random coordinates within the boundaries
        float randomX = Random.Range(bottomLeft.x, topRight.x);
        float randomZ = Random.Range(bottomLeft.z, topRight.z);

        return new Vector3(randomX, 0, randomZ); // Return the point with the Y-level taken into account
    }

    public static Vector3 ConvertWorldToViewport(Vector3 ObjectPosition)
    {
        if (!cam) FindCam();
        return cam.WorldToViewportPoint(ObjectPosition);
    }
}
