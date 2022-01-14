using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFixedUpdate : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] LayerMask platformLayerMask;
    Rigidbody2D rigidbody2D;
    bool leftInput;
    bool rightInput;
    bool jumpInput;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (leftInput)
        {
            rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
        }
        else if (rightInput)
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }

        if (jumpInput && isGrounded())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        leftInput = Input.GetKey(KeyCode.LeftArrow);
        rightInput = Input.GetKey(KeyCode.RightArrow);
        jumpInput = Input.GetKey(KeyCode.Space);
    }

    bool isGrounded()
    {
        Collider2D groundCollider = Physics2D.OverlapBox(rigidbody2D.position + Vector2.down*0.6f, new Vector2(0.6f,0.6f),0.0f,platformLayerMask);
        return groundCollider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(rigidbody2D.position + Vector2.down * 0.6f, new Vector2(0.6f, 0.6f));
    }
}
