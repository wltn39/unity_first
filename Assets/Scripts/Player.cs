using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.1f; // 발사간격
    private float lastShotTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // 키보드 제어1 
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // 키보드 제어2
        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.position -= moveTo;
        // }
        // else if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.position += moveTo;
        // }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        Shoot();

        void Shoot()
        {
            // 10 - 0 > 0.2
            // lastShotTime = 10; 
            // 10.01 - 10 > 0.2 --> false 
            // 10.02 - 10 > 0.2 --> false 
            // 10.03 - 10 > 0.2 --> true 



            if (Time.time - lastShotTime > shootInterval)
            {
                Instantiate(weapon, shootTransform.position, Quaternion.identity);
                lastShotTime = Time.time;
            }
        }


    }
}
