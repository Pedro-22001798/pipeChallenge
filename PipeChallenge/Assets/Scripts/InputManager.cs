using UnityEngine;

public class InputManager : MonoBehaviour
{

    private void Update()
    {
        // Check for mouse left-click
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

            if(hit == true)
            {
                if(hit.collider.tag == "NormalPipe" || hit.collider.tag == "CurvePipe")
                {
                    // Check if the object has a PipeClick component
                    PipeClick pipeClick = hit.collider.GetComponent<PipeClick>();
                    if (pipeClick != null)
                    {
                        pipeClick.RotatePipe();
                    }
                }
            }
        }
    }
}
