using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public class Move : MonoBehaviour
{
    //SerializeField
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jump=5f;

    private Rigidbody2D rb;
    private Animator ani;
    private float horizontalIunput;
    private bool isJumping;

    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        ani=GetComponent<Animator>();
    }

    void Update()
    {
        readInput();
    }

    private void readInput()
    {
        horizontalIunput=Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping=true;
        }
    }
    private void FixedUpdate()
    {
        HandleMove();
        HandleJumping();
    }
    private void HandleMove()
    {
        if (PlayerCollision.isPlayerDead)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity=new Vector2(horizontalIunput*speed,rb.linearVelocity.y);
        if (horizontalIunput != 0)
        {
            transform.localScale=new Vector3(Mathf.Sign(horizontalIunput),1,1);
        }
    }
    private void HandleJumping()
    {
        if (PlayerCollision.isPlayerDead || !isJumping) return;
        rb.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
        isJumping=false;
    }
    // private void FixedUpdate(){
    //     HandleMove();
    //     HandleJump();
    // }
  
    // private void readInput(){
    //     horizontalInput= Input.GetAxisRaw("Horizontal");
    //     if(Input.GetKeyDown(KeyCode.Space)){
    //         isJumping = true;
    //     }
    // }
    // private void HandleMove(){
    //     rb.linearVelocity=new Vector2(horizontalInput*speed,rb.linearVelocity.y);
    //     if(horizontalInput!=0){
    //         transform.localScale=new Vector3(Mathf.Sign(horizontalInput),1,1);
    //     }
    //     ani.SetFloat("Speed",Mathf.Abs(horizontalInput));
    // }
    // private void HandleJump(){
    //     if(!isJumping) return;

    //     rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
    //     isJumping=false;
    // }
}

