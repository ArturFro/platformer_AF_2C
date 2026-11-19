using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
//using UnityEngine.Windows;

public class MovementZadanie : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpForce;
    
    // Start is called before the first frame update
    
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }
    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        



    }


}
