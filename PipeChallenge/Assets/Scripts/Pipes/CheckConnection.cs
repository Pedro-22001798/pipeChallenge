using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckConnection : MonoBehaviour
{
    [SerializeField] private PipeClick pipeClick;
    private List<Transform> connections = new List<Transform>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform connection = collision.transform.parent;
        if(connection != this.transform.parent)
        {
            if(!connections.Contains(connection))
            {
                connections.Add(connection);
                pipeClick.DefineConnections(connections);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Transform connection = collision.transform.parent;
        if(connections.Contains(connection))
        {
            connections.Remove(connection);    
            pipeClick.DefineConnections(connections); 
        }
    }
}
