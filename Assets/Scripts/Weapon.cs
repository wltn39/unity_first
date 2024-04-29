using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10; // 미사일 스피드

    // Start is called before the first frame update (처음 한번만 호출)
    void Start()
    {
        Destroy(gameObject, 1f); // 게임오브젝트를 1초 뒤 없애줘 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
