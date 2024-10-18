using UnityEngine;

public class FollowPlayerController : MonoBehaviour
{
    public Transform player;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -10f);
    }
}
