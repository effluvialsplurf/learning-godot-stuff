using Godot;
using System;
using System.Collections.Generic;

// this script is meant to be attached to the root node of any scene where accessing
// children nodes in that scene is a matter of necessity
public static class SceneNodeCollector
{

    private static void CollectAllDescendantNodes(Node parentNode, List<Node> nodeList)
    {
        // throw the parent node in the list
        nodeList.Add(parentNode);

        // iterate over the direct children of the parent node
        foreach (Node child in parentNode.GetChildren())
        {
            // recursively call to grab all children
            CollectAllDescendantNodes(child, nodeList);
        }
    }

    public static List<Node> GetAllChildrenNodes(Node parentNode)
    {
        // gonsta recursively get all this nodes kids
        List<Node> allNodesInScene = new List<Node>();

        CollectAllDescendantNodes(parentNode, allNodesInScene);

        return allNodesInScene;
    }
}