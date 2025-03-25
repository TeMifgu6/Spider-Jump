using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchManager : MonoBehaviour
{
    [SerializeField] GameObject[] branchPrefabs;

    public void SpawnBranch()
    {
        int r = Random.Range(0, branchPrefabs.Length);
        GameObject branch = Instantiate(branchPrefabs[r], transform);
        branch.transform.position = new Vector3(Random.Range(-1f, 1f), 8f, 32f);
    }
}
