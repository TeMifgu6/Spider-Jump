using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    [Header("�I���u�ʳt��")]
    public float scrollSpeed = 2f; // �I���V�U�u�ʪ��t�ס]�P���Y�W�ɬ۹�^

    [Header("�I������")]
    public float bgHeight = 10f;   // �I���Ϥ�������

    void Update()
    {
        // �I�������V�U���ʡA���ͬ۹��T�w�W�����Y���ĪG
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        // ��I�������U���W�X�@�w���׮ɡA�N�䭫�s��m��e���W��
        if (transform.position.y <= -bgHeight)
        {
            transform.position += new Vector3(0, bgHeight * 2, 0);
        }
    }
}
