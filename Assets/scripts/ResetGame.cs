
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    [SerializeField] private KeyCode reset;
    [SerializeField] private float timeToHoldDown;
    [SerializeField] private float holdingDown;
    
    
    void Update()
    {
        if(Input.GetKey(reset))
        {
            holdingDown += Time.deltaTime;
            if(holdingDown >= timeToHoldDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                holdingDown = 0;
            }
            
        }
        else
        {
            holdingDown = 0;
        }  
    }
}
