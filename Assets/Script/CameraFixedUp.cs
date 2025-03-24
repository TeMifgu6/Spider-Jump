using UnityEngine;

public class CameraFixedUp : MonoBehaviour
{
    [Header("上升速度")]
    public float upwardSpeed = 2f;  // 鏡頭固定上升速度

    void Update()
    {
        // 固定讓鏡頭在 Y 軸上每幀增加 upwardSpeed * Time.deltaTime
        transform.position = new Vector3(transform.position.x, transform.position.y + upwardSpeed * Time.deltaTime, transform.position.z);
    }
}
