
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class BaseNode_A : ScriptableObject
{
    public Rect  windowRect;
    public List<InputEdit_A> inputsEdit;
    public List<outputEdit_A> outputsEdit;


    public bool hasInputs = false;

    //the title of our window
    public string windowTitle = "";
    public virtual void DrawWindow()
    
    {
        //We want each node to have a title which the user can modify
        windowTitle = EditorGUILayout.TextField("Title", windowTitle);
    }

    public abstract void DrawCurves();

    public virtual void SetInput(BaseInputNode input, Vector2 clickPos)
    {
    }

    public virtual void NodeDeleted(BaseNode node)
    {

    }

    public virtual BaseInputNode ClickedOnInput(Vector2 pos)
    {
        return null;
    }

    public abstract void Tick(float deltaTime);
}
