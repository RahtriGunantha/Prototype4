using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;

    public bool hasPowerUp = !true;
    private float powerUpStrengh = 10;
    public GameObject powerUpIndicator;

    private Vector3 powerUpPosition = new Vector3(0,-0.5f,0);
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

      //  playerRb.AddForce(Vector3.forward * verticalInput * speed);
      playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);

        powerUpIndicator.transform.position = transform.position + powerUpPosition;
    }

   private void OnTriggerEnter(Collider other) 
   {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine()); // untuk menjalankan delay diluar update method
        } 
   }

    // untuk memulai delay diluar Update method
   IEnumerator PowerUpCountdownRoutine()
   {
    yield return new WaitForSeconds(5);
    hasPowerUp = false;
    powerUpIndicator.gameObject.SetActive(false);
   }

   private void OnCollisionEnter(Collision other) 
   {

    if(other.gameObject.CompareTag("Enemy") && hasPowerUp)
    {
        Rigidbody enemyRigidBody = other.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position; // memantulkan musuh sesuai arah

        enemyRigidBody.AddForce(awayFromPlayer * powerUpStrengh, ForceMode.Impulse);
        Debug.Log("Compare with " + other.gameObject.name + "with Power Up set to" + hasPowerUp);
    }
   }
}
