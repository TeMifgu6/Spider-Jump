using UnityEngine;

public class CameraFixedUp : MonoBehaviour
{
    [Header("�W�ɳt��")]
    public float upwardSpeed = 2f;  // ���Y�T�w�W�ɳt��

    void Update()
    {
        // �T�w�����Y�b Y �b�W�C�V�W�[ upwardSpeed * Time.deltaTime
        transform.position = new Vector3(transform.position.x, transform.position.y + upwardSpeed * Time.deltaTime, transform.position.z);
    }
}
