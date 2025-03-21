using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("預製件設定")]
    public GameObject branchPrefab;       // 樹枝平台預製件
    public GameObject upperLeafPrefab;      // 上方樹葉預製件
    public GameObject lowerLeafPrefab;      // 下方樹葉預製件

    [Header("平台位置設定")]
    [Tooltip("上方平台位置，例如：左上、右上")]
    public Vector2[] upperPositions;        // 例如：(-3, 2)、(3, 2)
    [Tooltip("下方平台位置，例如：左下、右下")]
    public Vector2[] lowerPositions;        // 例如：(-3, -2)、(3, -2)

    void Start()
    {
        // 生成上方平台
        foreach (Vector2 pos in ShuffleArray(upperPositions))
        {
            SpawnPlatform(pos, true);
        }

        // 生成下方平台
        foreach (Vector2 pos in ShuffleArray(lowerPositions))
        {
            SpawnPlatform(pos, false);
        }
    }

    // 根據位置生成平台，isUpper 為 true 則附加上方樹葉，否則附加下方樹葉
    void SpawnPlatform(Vector2 pos, bool isUpper)
    {
        GameObject branch = Instantiate(branchPrefab, pos, Quaternion.identity);
        branch.tag = "Platform";  // 設定標籤以供 PlayerController 識別

        if (isUpper)
        {
            // 將上方樹葉作為子物件附加到平台上，位置可根據需要微調
            Instantiate(upperLeafPrefab, pos, Quaternion.identity, branch.transform);
        }
        else
        {
            // 附加下方樹葉
            Instantiate(lowerLeafPrefab, pos, Quaternion.identity, branch.transform);
        }
    }

    // Fisher-Yates 洗牌：打亂 Vector2 陣列順序
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
