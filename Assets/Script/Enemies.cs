using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemiesRb;
    private GameObject player;

    private float batasY = -3;

    // Start is called before the first frame update
    void Start()
    {
        enemiesRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // enemy berjalan sendiri mendekati player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        
        enemiesRb.AddForce(lookDirection* speed);

        if(transform.position.y < batasY)
        {
            Destroy(gameObject);
        }
    }

}
