using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    

    

    

    

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    

    

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    
    private float horizontalInput;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when moving left-right
        if (horizontalInput > 0.05f)
            transform.localScale = new Vector3(5,5,5);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-5, 5, 5);

        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //Jump
        

        

        
        
    }

    

   


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    
    
}