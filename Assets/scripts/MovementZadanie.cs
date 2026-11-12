using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
//using UnityEngine.Windows;

public class MovementZadanie : MonoBehaviour
{
    
    [SerializeField] private bool shouldMove = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.Space) && shouldMove == false)
        {
            shouldMove = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && shouldMove == true)
        {
            shouldMove = false;
        }


        if (shouldMove == true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 20);

        }
        
        

    }
}
