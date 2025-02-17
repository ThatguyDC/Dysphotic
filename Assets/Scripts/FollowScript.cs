using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowScript : MonoBehaviour
{
    public GameObject follow;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, follow.transform.position, Time.deltaTime * 10);

        float targetRotation = Mathf.Atan2((follow.transform.parent.position.y - transform.position.y), (follow.transform.parent.position.x - transform.position.x));
        transform.rotation = Quaternion.Euler(0, 0, (targetRotation * Mathf.Rad2Deg) - 90);
    }

    public void setFollow(GameObject follow)
    {
        this.follow = follow;
    }
}