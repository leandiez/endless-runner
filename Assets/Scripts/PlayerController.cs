using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    Animator myAnimator;
    Rigidbody playerRig;
    private Vector3 playerVelocity;

    [SerializeField]private bool groundedPlayer;
    private bool isMoving;
    [SerializeField] private float jumpHeight = 20.0f;
    [SerializeField] private Vector2 movingRange = new Vector2(-7,0);
    Vector3 movingOffset = new Vector3(0.0f, 0.0f, 3.0f);
    [SerializeField] float playerSpeed = 10.0f;

    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        
        float moveInput = Input.GetAxis("Horizontal");
        if(Input.GetButton("Jump") && groundedPlayer){
            myAnimator.SetTrigger("Jump");
            myAnimator.SetBool("isGrounded", false);
            groundedPlayer = false;

            playerRig.AddForce(transform.up * jumpHeight);
        }
        
    }

    void Update(){
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 leftPosition = transform.position - movingOffset;
        Vector3 rightPosition = transform.position + movingOffset;
        //Falta poner la condicion para que no se salga de los bordes
        if(moveInput > 0.3f && !isMoving && groundedPlayer){
            transform.DOLocalMove(rightPosition, 0.5f).OnComplete( () => isMoving = false );
            myAnimator.SetTrigger("Dash");
            isMoving = true;
        }else if(moveInput < -0.3f && !isMoving && groundedPlayer){
            transform.DOLocalMove(leftPosition, 0.5f).OnComplete( () => isMoving = false );
            myAnimator.SetTrigger("Dash");
            isMoving = true;
        }

        transform.position = transform.position + new Vector3(-1.0f*playerSpeed,0,0);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            groundedPlayer = true;
            myAnimator.SetBool("isGrounded", true);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //Pantalla de game over
            Debug.Log("Perdiste");
        }
    }

}
