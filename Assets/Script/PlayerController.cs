using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour{

    public float speed = 0.1f;
    public float jump = 0.1f;
    Rigidbody2D rigid2D;
    void Start(){
        print("Start");
        rigid2D = this.gameObject.GetComponent<Rigidbody2D>();
    }


    void Update() {
        if (Input.GetKey(KeyCode.Space))
        {
            rigid2D.AddForce(new Vector2(0, jump), ForceMode2D.Force);
            print("Jump");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position -= new Vector3(speed, 0, 0);
        }
    }
}
