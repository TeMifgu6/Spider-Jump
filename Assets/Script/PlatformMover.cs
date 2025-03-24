using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [Header("下降速度")]
    public float fallSpeed = 2f;

    [Header("銷毀閾值")]
    public float destroyThreshold = -5f; // 超過此值則銷毀

    void Update()
    {
        // 平台向下移動
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // 當平台超出視野，下移過低則銷毀
        if (transform.position.y < destroyThreshold)
        {
            Destroy(gameObject);
        }
    }
}
