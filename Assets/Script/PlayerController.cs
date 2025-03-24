using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("移動參數")]
    public float moveSpeed = 5f;        // 水平移動速度
    public float jumpForce = 10f;       // 跳躍初始力量
    public float maxJumpHeight = 3f;    // 最大跳躍高度

    private Rigidbody2D rb;
    private bool isGrounded = true;     // 是否著陸
    private Vector2 jumpStartPos;       // 跳躍開始位置

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 水平移動：使用 GetAxis 取得平滑輸入
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 跳躍：當按下空白鍵且在地面上時
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpStartPos = transform.position;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // 控制最大跳躍高度
        if (!isGrounded && rb.velocity.y > 0)
        {
            if (transform.position.y - jumpStartPos.y >= maxJumpHeight)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0); // 停止上升
            }
        }
    }

    // 當碰撞到平台（標籤 "Platform"）時視為著陸
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}
