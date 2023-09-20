using UnityEngine;
using System.Collections.Generic;

public class DetectCollisions : MonoBehaviour
{
    private List<Collider2D> collidingObjects = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!collidingObjects.Contains(other))
        {
            collidingObjects.Add(other);
            UpdateConnectedObjects(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (collidingObjects.Contains(other))
        {
            collidingObjects.Remove(other);          
        }
    }

    private void UpdateConnectedObjects(GameObject currentObject)
    {
        Collider2D[] colliders = currentObject.GetComponentsInChildren<Collider2D>();

        foreach (Collider2D collider in colliders)
        {
            Collider2D[] overlappedColliders = Physics2D.OverlapBoxAll(collider.bounds.center, collider.bounds.size, 0);

            foreach (Collider2D overlappedCollider in overlappedColliders)
            {
                if (overlappedCollider.gameObject != gameObject && !collidingObjects.Contains(overlappedCollider))
                {
                    collidingObjects.Add(overlappedCollider);
                    UpdateConnectedObjects(overlappedCollider.gameObject);
                    foreach(Collider2D c in collidingObjects)
                    {
                        GameObject pipeObject = c.gameObject;
                        PipeClick pipeClick = pipeObject.GetComponent<PipeClick>();
                        if(pipeClick != null)
                        {
                            pipeClick.LightPipe();
                        }
                    }
                }
            }
        }
    }

    public int GetConnectedObjectCount()
    {
        return collidingObjects.Count;
    }

    // void Update()
    // {
    //     Debug.Log($"There are {GetConnectedObjectCount()} connections");
    // }
}
