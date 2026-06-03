using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public class move2 : MonoBehaviour
{

    [SerializeField] private float speed= 5f;
    [SerializeField] private float jump=5f;
    private Rigidbody2D rb;
    private Animator ani;
    private float horizontalInput;
    private bool isJumping;

    void Awake(){
        rb=GetComponent<Rigidbody2D>();
        ani=GetComponent<Animator>();
    }

    void Update()
    {
        readinput();
    }
    private void readinput(){
        horizontalInput=Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space)){
            isJumping = true;
        }
    }
    private void FixedUpdate(){
        HandleMovew();
        HandleJumpingw();
    }
    private void HandleMovew(){
        if (PlayerCollision.isPlayerDead)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity= new Vector2(horizontalInput*speed,rb.linearVelocity.y);
        if(horizontalInput!=0){
            transform.localScale=new Vector3(Mathf.Sign(horizontalInput),1,1);
        }
    }
    private void HandleJumpingw(){
        if (PlayerCollision.isPlayerDead || !isJumping) return;
        rb.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
        isJumping=false;
    }
  
}
