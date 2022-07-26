using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RigidBody : MonoBehaviour
{
    public float rotSpeed = 1f;
    public float speed = 1f;
    public float gunpower = 15f;
    public float gunCooldown = 2f;
    public float gunCooldownCount = 0;
    public bool hasgun = false;
    public int bulletcount = 0;
    public GameObject prefabBullet;
    public Transform gunpoint;
    public int coinCount = 0;
    public Text uiCountcoin;
    public MENU manager;
    public AudioSource audioGun;
    public AudioSource audioCoin;
    public AudioSource audioReload;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = FindObjectOfType<MENU>();
        if(manager == null)
        {
            print("Manager not Found");
        }
    }
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, horizontal);
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,0,0),transform.rotation, rotSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, horizontal);
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,180,0),transform.rotation, rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(vertical, 0, 0);
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,90,0),transform.rotation, rotSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(vertical, 0, 0);
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,-90,0),transform.rotation, rotSpeed * Time.deltaTime);
        }
        */
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        rb.AddForce(horizontal * Time.deltaTime,0,vertical * Time.deltaTime, ForceMode.VelocityChange);
        if(horizontal > 0)
        {
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,90,0),transform.rotation, rotSpeed * Time.deltaTime);
        }
        else if(horizontal < 0)
        {
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,-90,0),transform.rotation, rotSpeed * Time.deltaTime);
        }
        if(vertical > 0)
        {
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,0,0),transform.rotation, rotSpeed * Time.deltaTime);
        }
        else if(vertical < 0)
        {
            transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,-180,0),transform.rotation, rotSpeed * Time.deltaTime);
        }
        gunCooldownCount += Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && hasgun == true && gunCooldownCount >= gunCooldown)
        {
            gunCooldownCount = 0;
            bulletcount --;
            manager.setTextBullet(bulletcount);
            GameObject bullet = Instantiate(prefabBullet,gunpoint.position, gunpoint.rotation);
            Rigidbody brb = bullet.GetComponent<Rigidbody>();
            brb.AddForce(transform.forward * gunpower, ForceMode.Impulse);
            Destroy(bullet, 2f);
            if(bulletcount == 0)
            {
                hasgun = false;
            }
            audioGun.Play();
        }
    }
   private void OnCollisionEnter(Collision collision)
   {
       print(collision.gameObject.name);
       if(collision.gameObject.tag == "Collectable")
       {
           Destroy(collision.gameObject);
       }
   }
   private void OnTriggerEnter(Collider other)
   {
       if(other.gameObject.tag == "Collectable")
       {
           Destroy(other.gameObject);
           coinCount++;
           manager.SetTextCoin(coinCount);
           audioCoin.Play();
       }

       if(other.gameObject.name == "Gun")
       {
           print("Heyy i have gun");
           hasgun = true;
           bulletcount += 10;
           manager.setTextBullet(bulletcount);
           audioReload.Play();
       }
   }
}
