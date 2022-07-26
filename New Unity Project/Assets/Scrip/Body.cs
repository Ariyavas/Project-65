using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public float speed = 1f;
    public float rotSpeed = 2f;
    // Update is called once per frame
    void Update()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        float newZ = transform.position.z;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            newZ = transform.position.z + speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,0,0),transform.rotation, rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newZ = transform.position.z - speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,180,0),transform.rotation, rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newX = transform.position.x + speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,90,0),transform.rotation, rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newX = transform.position.x - speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,-90,0),transform.rotation, rotSpeed * Time.deltaTime);
        }

        transform.position = new Vector3(newX,newY,newZ);
    }

private void OnCollisionEnter(Collision collision)
{
    print(collision.gameObject.name);
}
}
