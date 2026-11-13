using Unity.Collections;
using UnityEngine;

public class SendRay : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject moveWall;
    [SerializeField] private Vector3 wektor;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;

        if (cam == null)
        {
            Debug.LogError("Nie znaleziono kamery MainCamera!");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CheckWall();
        }
    }

    private void CheckWall()
    {
        if (cam == null)
            return;

        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 point = new Vector2(mousePosition.x, mousePosition.y);

        Collider2D hit = Physics2D.OverlapPoint(point, layerMask);

        if (hit == null)
        {
            Debug.Log("Nic nie trafiono!");
            return;
        }

        Debug.Log("Trafiono: " + hit.name);

        if (hit.CompareTag("Horizontal"))
        {
            moveWall = hit.gameObject;
            
            MoveHorizontal();
        }
        else if(hit.CompareTag("Vertical"))
        {
            moveWall = hit.gameObject;
            MoveVertical();
        }
    }

    private void MoveHorizontal()
    {
        if(moveWall != null)
        {
            wektor = cam.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 20;
            wektor.Set(moveWall.transform.position.x, wektor.y, wektor.z);
            moveWall.transform.position = wektor;
            
        }  
    }

    private void MoveVertical()
    {
        if(moveWall != null)
        {
            wektor = cam.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 20;
            wektor.Set(wektor.x, moveWall.transform.position.y, wektor.z);
            moveWall.transform.position = wektor;
            if(moveWall.transform.position.x > moveWall.GetComponent<MouseMoveWall>().positive.position.x)
            {
                wektor.Set(moveWall.GetComponent<MouseMoveWall>().positive.position.x, moveWall.transform.position.y, moveWall.transform.position.z);
                moveWall.transform.position = wektor;
            }
             if(moveWall.transform.position.x < moveWall.GetComponent<MouseMoveWall>().negative.position.x)
            {
                wektor.Set(moveWall.GetComponent<MouseMoveWall>().negative.position.x, moveWall.transform.position.y, moveWall.transform.position.z);
                moveWall.transform.position = wektor;
            }
        }     
    }
}