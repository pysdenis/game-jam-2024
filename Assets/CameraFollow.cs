using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float minX, maxX, minY, maxY;

    void Update()
    {
        float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(player.position.y, minY, maxY);
        
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
