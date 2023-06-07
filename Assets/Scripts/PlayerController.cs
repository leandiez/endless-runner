using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerController : MonoBehaviour
{
    CharacterController playerController;
    Rigidbody playerRig;
    private Vector3 playerVelocity;

    private bool groundedPlayer;
    private bool isMoving;
    [SerializeField] private float jumpHeight = 20.0f;
    [SerializeField] private Vector2 movingRange = new Vector2(-7,0);
    Vector3 movingOffset = new Vector3(0.0f, 0.0f, 3.0f);

    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 leftPosition = transform.position - movingOffset;
        Vector3 rightPosition = transform.position + movingOffset;
        //Falta poner la condicion para que no se salga de los bordes
        if(moveInput > 0.3f && !isMoving){
            transform.DOLocalMove(rightPosition, 0.5f).OnComplete( () => isMoving = false );
            isMoving = true;
        }else if(moveInput < -0.3f && !isMoving){
            transform.DOLocalMove(leftPosition, 0.5f).OnComplete( () => isMoving = false );
            isMoving = true;
        }
        if(Input.GetButton("Jump") && groundedPlayer){
            groundedPlayer = false;
            playerRig.AddForce(transform.up * jumpHeight);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            groundedPlayer = true;
        }
    }
    

}
