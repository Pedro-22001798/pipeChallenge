using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private CameraShake cameraShake;

    private void Update()
    {
        if(GameStateMachine.Instance.CurrentGameState == GameState.playing)
        {
            // Check for mouse left-click
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

                if(hit == true)
                {
                    if(hit.collider.tag == "NormalPipe" || hit.collider.tag == "CurvePipe" || hit.collider.tag == "EndPipe" || hit.collider.tag == "MixPipe")
                    {
                        // Check if the object has a PipeClick component
                        PipeClick pipeClick = hit.collider.GetComponent<PipeClick>();
                        if (pipeClick != null)
                        {
                            pipeClick.RotatePipe();
                        }
                    }
                    else if(hit.collider.tag == "LightPipe")
                    {
                        PipeClick pipeClick = hit.collider.GetComponent<PipeClick>();
                        if (pipeClick != null)
                        {
                            pipeClick.RotatePipe(true);
                            cameraShake.ShakeCamera();
                        }
                    }
                }
            }
        }
    }
}
