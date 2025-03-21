using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("���ʰѼ�")]
    public float moveSpeed = 5f;        // �������ʳt��
    public float jumpForce = 10f;       // ��l���D�O�q
    public float maxJumpHeight = 3f;    // �̤j���D����

    private Rigidbody2D rb;
    private bool isGrounded = true;     // �O�_�b�a���W
    private Vector2 jumpStartPos;       // ���D�}�l�ɪ���m

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �������ʡ]�ϥ� Input.GetAxis �i��o�󥭷ƪ���J�^
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ����U�ť���B�b�a���W�ɶ}�l���D
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpStartPos = transform.position;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // ����b�W�ɶ��q�ɡA�ˬd�O�_�F��̤j���D����
        if (!isGrounded && rb.velocity.y > 0)
        {
            if (transform.position.y - jumpStartPos.y >= maxJumpHeight)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }

    // ��P���x�I���]���� "Platform"�^�ɡA�����۳�
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}
