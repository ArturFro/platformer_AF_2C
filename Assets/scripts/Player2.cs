using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private float speed;
    [SerializeField] private float horizontalInput;
    [SerializeField] private Vector2 wektorek;
    
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpForce;
    
    // Start is called before the first frame update
    
    void OnCollisionStay2D()
    {
        isGrounded = true;
    }
    void OnCollisionExit2D()
    {
        isGrounded = false;
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        // Vector2 vectorek = Vector2.right * horizontalInput;
        // rig.AddForce(vectorek);     
        wektorek.Set(horizontalInput * speed, rig.velocity.y);
        rig.velocity = wektorek;

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded == true)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
