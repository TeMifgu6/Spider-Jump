using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    [SerializeField] float movespeed = -2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,movespeed*Time.deltaTime,0);
        if(transform.position.y < -12f)
        {
            Destroy(gameObject);
            transform.parent.GetComponent<BranchManager>().SpawnBranch();
        }
    }
}
