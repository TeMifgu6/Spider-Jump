using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("�w�s��]�w")]
    public GameObject branchPrefab;       // ��K���x�w�s��
    public GameObject upperLeafPrefab;      // �W��𸭹w�s��
    public GameObject lowerLeafPrefab;      // �U��𸭹w�s��

    [Header("���x��m�]�w")]
    [Tooltip("�W�襭�x��m�A�Ҧp�G���W�B�k�W")]
    public Vector2[] upperPositions;        // �Ҧp�G(-3, 2)�B(3, 2)
    [Tooltip("�U�襭�x��m�A�Ҧp�G���U�B�k�U")]
    public Vector2[] lowerPositions;        // �Ҧp�G(-3, -2)�B(3, -2)

    void Start()
    {
        // �ͦ��W�襭�x
        foreach (Vector2 pos in ShuffleArray(upperPositions))
        {
            SpawnPlatform(pos, true);
        }

        // �ͦ��U�襭�x
        foreach (Vector2 pos in ShuffleArray(lowerPositions))
        {
            SpawnPlatform(pos, false);
        }
    }

    // �ھڦ�m�ͦ����x�AisUpper �� true �h���[�W��𸭡A�_�h���[�U���
    void SpawnPlatform(Vector2 pos, bool isUpper)
    {
        GameObject branch = Instantiate(branchPrefab, pos, Quaternion.identity);
        branch.tag = "Platform";  // �]�w���ҥH�� PlayerController �ѧO

        if (isUpper)
        {
            // �N�W��𸭧@���l������[�쥭�x�W�A��m�i�ھڻݭn�L��
            Instantiate(upperLeafPrefab, pos, Quaternion.identity, branch.transform);
        }
        else
        {
            // ���[�U���
            Instantiate(lowerLeafPrefab, pos, Quaternion.identity, branch.transform);
        }
    }

    // Fisher-Yates �~�P�G���� Vector2 �}�C����
    Vector2[] ShuffleArray(Vector2[] array)
    {
        Vector2[] newArray = (Vector2[])array.Clone();
        for (int i = 0; i < newArray.Length; i++)
        {
            int rnd = Random.Range(i, newArray.Length);
            Vector2 temp = newArray[rnd];
            newArray[rnd] = newArray[i];
            newArray[i] = temp;
        }
        return newArray;
    }
}
