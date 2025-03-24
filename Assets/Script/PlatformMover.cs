using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [Header("�U���t��")]
    public float fallSpeed = 2f;

    [Header("�P���H��")]
    public float destroyThreshold = -5f; // �W�L���ȫh�P��

    void Update()
    {
        // ���x�V�U����
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // ���x�W�X�����A�U���L�C�h�P��
        if (transform.position.y < destroyThreshold)
        {
            Destroy(gameObject);
        }
    }
}
