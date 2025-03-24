using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    [Header("背景滾動速度")]
    public float scrollSpeed = 2f; // 背景向下滾動的速度（與鏡頭上升相對）

    [Header("背景高度")]
    public float bgHeight = 10f;   // 背景圖片的高度

    void Update()
    {
        // 背景本身向下移動，產生相對於固定上升鏡頭的效果
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        // 當背景完全下移超出一定高度時，將其重新放置到畫面上方
        if (transform.position.y <= -bgHeight)
        {
            transform.position += new Vector3(0, bgHeight * 2, 0);
        }
    }
}
