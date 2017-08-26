using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    //  陨石最大翻滚值
    public float tumble;

    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        //  刚体的角速度
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
