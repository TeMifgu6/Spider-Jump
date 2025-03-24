using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("���ʰѼ�")]
    public float moveSpeed = 5f;        // �������ʳt��
    public float jumpForce = 10f;       // ���D��l�O�q
    public float maxJumpHeight = 3f;    // �̤j���D����

    private Rigidbody2D rb;
    private bool isGrounded = true;     // �O�_�۳�
    private Vector2 jumpStartPos;       // ���D�}�l��m

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �������ʡG�ϥ� GetAxis ���o���ƿ�J
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ���D�G����U�ť���B�b�a���W��
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpStartPos = transform.position;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // ����̤j���D����
        if (!isGrounded && rb.velocity.y > 0)
        {
            if (transform.position.y - jumpStartPos.y >= maxJumpHeight)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0); // ����W��
            }
        }
    }

    // ��I���쥭�x�]���� "Platform"�^�ɵ����۳�
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}
