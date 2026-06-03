
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public class move3 : MonoBehaviour
{
  [SerializeField] private float speed = 5f;
  [SerializeField] private float jump = 5f;
  [SerializeField] private Transform groundCheck;
  [SerializeField] private float groundCheckRadius = 0.2f;
  [SerializeField] private LayerMask groundLayer;

  private Rigidbody2D rb;
  private Animator ani;
  private float hori;
  private bool isJump;
  private bool isGrounded;
  
  void Awake(){
      rb=GetComponent<Rigidbody2D>();
      ani=GetComponent<Animator>();
  }
    void Update()
  {
    readInput();
  }
  private void readInput()
  {
    hori=Input.GetAxisRaw("Horizontal");
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
      isJump = true;
    }
  }
  private void FixedUpdate()
  {
    CheckGround();
    HandleMove();
    HandleJumping();
    UpdateAnimation();
  }
  private void CheckGround()
  {
    isGrounded = groundCheck != null && Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
  }

  private void UpdateAnimation()
  {
    bool isRunning = Mathf.Abs(hori) > 0.01f;
    ani.SetBool("isRunning", isRunning);
    ani.SetBool("isJumping", !isGrounded);
  }

  private void HandleMove()
  {
    if (PlayerCollision.isPlayerDead)
    {
      rb.linearVelocity = Vector2.zero;
      return;
    }

    rb.linearVelocity=new Vector2(hori*speed,rb.linearVelocity.y);
    if (hori != 0)
    {
      transform.localScale=new Vector3(Mathf.Sign(hori),1,1);
    }
  }
  private void HandleJumping()
  {
    if (PlayerCollision.isPlayerDead || !isJump) return;
    rb.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
    isJump=false;
}
}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    [SerializeField] private float speed= 5f;
//     [SerializeField] private float jump=5f;

//     private Rigidbody2D rb;
//     private Animator ani;
//     private float horizontalInput;
//     private bool isJumping;

//     void Awake(){
//         rb=GetComponent<Rigidbody2D>();
//         ani=GetComponent<Animator>();
//     }

//     void Update()
//     {
//         readinput();
//     }
//     private void readinput(){
//         horizontalInput=Input.GetAxisRaw("Horizontal");
//         if(Input.GetKeyDown(KeyCode.Space)){
//             isJumping = true;
//         }
//     }
//     private void FixedUpdate(){
//         HandleMovew();
//         HandleJumpingw();
//     }
//     private void HandleMovew(){
//         rb.linearVelocity= new Vector2(horizontalInput*speed,rb.linearVelocity.y);
//         if(horizontalInput!=0){
//             transform.localScale=new Vector3(Mathf.Sign(horizontalInput),1,1);
//         }
//     }
//     private void HandleJumpingw(){
//         if(!isJumping) return;
//         rb.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
//         isJumping=false;
//     }
    

