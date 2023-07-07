using UnityEngine;

public static class Utils
{
    private static Vector3 tmpVector;

    public static Vector3 ScreenToWorld(Camera camera, Vector2 screenPosition)
    {
        tmpVector = new Vector3(screenPosition.x, screenPosition.y, camera.nearClipPlane);
        return camera.ScreenToWorldPoint(tmpVector);
    }

    public static Vector3 ScreenToViewportPoint(Camera camera, Vector2 screenPosition)
    {
        tmpVector = new Vector3(screenPosition.x, screenPosition.y, camera.nearClipPlane);
        return camera.ScreenToViewportPoint(tmpVector);
    }
}
