using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    //  飞船移动的速度
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    //  子弹发射的间隔，也就是子弹发射的时间间隔
    public float fireRate;
    //  下一次发射的时间
    private float nextFire;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        //  控制飞船的移动
        rigidbody.velocity = movement * speed;
        //  控制飞船不会飞出屏幕
        rigidbody.position = new Vector3
        (
        Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
        0.0f,
        Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );
        //  飞船移动时倾斜一点
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, -rigidbody.velocity.x * tilt);
    }
}
