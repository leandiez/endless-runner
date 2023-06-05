using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    CharacterController playerController;
    Rigidbody playerRig;
    private Vector3 playerVelocity;

    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 20.0f;

    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if(Input.GetButton("Jump") && groundedPlayer){
            groundedPlayer = false;
            //playerRig.AddForce(transform.up * jumpHeight);
        }
        float horDir = Input.GetAxis("Horizontal");
        float verDir = Input.GetAxis("Vertical");
        if( horDir != 0 && verDir != 0){
            Vector3 moveDir = new Vector3(verDir, 0 , horDir);
            playerRig.AddForce(moveDir * playerSpeed);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            groundedPlayer = true;
        }
    }

}
