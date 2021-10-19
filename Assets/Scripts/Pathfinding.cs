using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Grid grid;
    public Transform startPosition;
    public Transform targetPosition;

    private void Awake()
    {
        grid = GetComponent<Grid>(); 
    }

    private void Update()
    {
        FindPath(startPosition.position, targetPosition.position);
    }

    void FindPath(Vector3 a_StartPos, Vector3 a_TargetPos)
    {
        Node startNode = grid.NodeFromWorldPosition(a_StartPos);
        Node targetNode = grid.NodeFromWorldPosition(a_TargetPos);

        List<Node> openList = new List<Node>();
        HashSet<Node> closedList = new HashSet<Node>();

        openList.Add(startNode);

        while(openList.Count > 0)
        {
            Node currentNode = openList[0];
            for(int i = 1; i < openList.Count; i++)
            {
                if(openList[i].fCost < currentNode.fCost || openList[i].fCost == currentNode.fCost && openList[i].hCost < currentNode.hCost)
                {
                    currentNode = openList[i];
                }
            }
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if(currentNode == targetNode)
            {
                GetFinalPath(startNode, targetNode);
            }

            foreach (Node neighbourNode in grid.GetNeighboringNodes(currentNode))
            {
                if(!neighbourNode.isWall || closedList.Contains(neighbourNode))
                {
                    continue;
                }
                int moveCost = currentNode.gCost + GetManhattenDistance(currentNode, neighbourNode);
                
                if(moveCost < neighbourNode.gCost || !openList.Contains(neighbourNode))
                {
                    neighbourNode.gCost = moveCost;
                    neighbourNode.hCost = GetManhattenDistance(neighbourNode, targetNode);
                    neighbourNode.parent = currentNode;

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }
    }

    void GetFinalPath(Node a_StartingNode, Node a_EndNode)
    {
        List<Node> finalPath = new List<Node>();
        Node currentNode = a_EndNode;

        while(currentNode != a_StartingNode)
        {
            finalPath.Add(currentNode);
            currentNode = currentNode.parent;
        }
        finalPath.Reverse();

        grid.finalPath = finalPath;
    }

    int GetManhattenDistance(Node a_nodeA, Node a_nodeB)
    {
        int ix = Mathf.Abs(a_nodeA.gridX - a_nodeB.gridX);
        int iy = Mathf.Abs(a_nodeA.gridY - a_nodeB.gridY);

        return ix + iy;
    }
}
