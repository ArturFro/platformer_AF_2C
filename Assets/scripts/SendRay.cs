using UnityEngine;

public class SendRay : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject moveWall;

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
            moveWall.transform.position = cam.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 20;
            print("horizontal");
        }  
    }

    private void MoveVertical()
    {
        if(moveWall != null)
        {
            moveWall.transform.position = cam.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 20;
            print("vertical");
        }     
    }
}