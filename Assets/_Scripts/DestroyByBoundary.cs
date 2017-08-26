using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{

    //  当其他碰撞体超出触发器的容量时销毁碰撞体
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
