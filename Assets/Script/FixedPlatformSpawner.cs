using UnityEngine;

public class FixedPlatformSpawner : MonoBehaviour
{
    [Header("樹枝平台預製件")]
    public GameObject branchPrefab;

    [Header("上方樹葉預製件")]
    public GameObject upperLeafPrefab;

    [Header("下方樹葉預製件")]
    public GameObject lowerLeafPrefab;

    [Header("固定平台位置")]
    public Vector2 leftUpperPos;
    public Vector2 rightUpperPos;
    public Vector2 leftLowerPos;
    public Vector2 rightLowerPos;

    void Start()
    {
        // 在固定位置生成四個平台
        SpawnPlatform(leftUpperPos, true);
        SpawnPlatform(rightUpperPos, true);
        SpawnPlatform(leftLowerPos, false);
        SpawnPlatform(rightLowerPos, false);
    }

    // isUpper 為 true 表示此平台屬於上方，附加上方樹葉；否則附加下方樹葉
    void SpawnPlatform(Vector2 pos, bool isUpper)
    {
        GameObject branch = Instantiate(branchPrefab, pos, Quaternion.identity);
        branch.tag = "Platform"; // 設定標籤

        // 將平台移動腳本 PlatformMover.cs 也應該附加到平台上，使其向下移動
        // 注意：如果希望平台在特定時機才開始下降，你可以在生成後稍後啟動該腳本
        // 這裡直接假設平台一開始就會下降
        //（若預製件中已包含 PlatformMover.cs，此步驟可省略）

        // 根據平台位置附加樹葉：上方平台附加上方樹葉，下方平台附加下方樹葉
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
