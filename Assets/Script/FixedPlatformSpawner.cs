using UnityEngine;

public class FixedPlatformSpawner : MonoBehaviour
{
    [Header("��K���x�w�s��")]
    public GameObject branchPrefab;

    [Header("�W��𸭹w�s��")]
    public GameObject upperLeafPrefab;

    [Header("�U��𸭹w�s��")]
    public GameObject lowerLeafPrefab;

    [Header("�T�w���x��m")]
    public Vector2 leftUpperPos;
    public Vector2 rightUpperPos;
    public Vector2 leftLowerPos;
    public Vector2 rightLowerPos;

    void Start()
    {
        // �b�T�w��m�ͦ��|�ӥ��x
        SpawnPlatform(leftUpperPos, true);
        SpawnPlatform(rightUpperPos, true);
        SpawnPlatform(leftLowerPos, false);
        SpawnPlatform(rightLowerPos, false);
    }

    // isUpper �� true ��ܦ����x�ݩ�W��A���[�W��𸭡F�_�h���[�U���
    void SpawnPlatform(Vector2 pos, bool isUpper)
    {
        GameObject branch = Instantiate(branchPrefab, pos, Quaternion.identity);
        branch.tag = "Platform"; // �]�w����

        // �N���x���ʸ}�� PlatformMover.cs �]���Ӫ��[�쥭�x�W�A�Ϩ�V�U����
        // �`�N�G�p�G�Ʊ業�x�b�S�w�ɾ��~�}�l�U���A�A�i�H�b�ͦ���y��ҰʸӸ}��
        // �o�̪������]���x�@�}�l�N�|�U��
        //�]�Y�w�s�󤤤w�]�t PlatformMover.cs�A���B�J�i�ٲ��^

        // �ھڥ��x��m���[�𸭡G�W�襭�x���[�W��𸭡A�U�襭�x���[�U���
        if (isUpper)
        {
            Instantiate(upperLeafPrefab, pos, Quaternion.identity, branch.transform);
        }
        else
        {
            Instantiate(lowerLeafPrefab, pos, Quaternion.identity, branch.transform);
        }
    }
}
