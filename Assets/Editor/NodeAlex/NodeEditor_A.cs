using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class NodeEditor_A : EditorWindow {

    //list that stores our windows
    private List<BaseNode_A> windows = new List<BaseNode_A>();

    //variable to store our mousePos
    private Vector2 mousePos;

    //variable to store a selected node
    private BaseNode_A selectedNode;
    //variable to determine if we are on a transition mode
    private bool makeTransitionMode = false;

    private System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

    float PanY;
    float PanX;

    private bool scrollWindow = false;
    private Vector2 scrollStartMousePos;

    //In order to be accessible the window from the menue we add a menu item
    [MenuItem("Window/Node Editor Alex")]
    static void ShowEditor()
    {
        NodeEditor_A editor = EditorWindow.GetWindow<NodeEditor_A>();

        editor.stopWatch.Start();
    }


    void OnGUI()
    {
        //check event
        Event e = Event.current;

        //check mouse position
        mousePos = e.mousePosition;




        if (e.button == 1 && !makeTransitionMode)
        {
            if (e.type == EventType.MouseDown)
            {
                bool clickedOnWindow = false;
                int selectedIndex = -1;

                //check to see if he clicked inside a window
                for (int i = 0; i < windows.Count; i++)
                {
                    if (windows[i].windowRect.Contains(mousePos))
                    {
                        //if he clicked store the i
                        selectedIndex = i;
                        //we clicked on a window
                        clickedOnWindow = true;
                        //we have a window so we don't need to check for another one
                        break;
                    }
                }

                //if we didn't clicked a window
                if (!clickedOnWindow)
                {
                    //make a new menu for every different case 
                    GenericMenu menu = new GenericMenu();

                    menu.AddItem(new GUIContent("Add Input Node"), false, ContextCallback, "inputNode");
                    menu.AddItem(new GUIContent("Add Output Node"), false, ContextCallback, "outputNode");
                    menu.AddItem(new GUIContent("Add Calculation Node"), false, ContextCallback, "calcNode");
                    menu.AddItem(new GUIContent("Add Comparison Node"), false, ContextCallback, "compNode");
                    menu.AddSeparator("");
                    menu.AddItem(new GUIContent("Add GameObject Active Node"), false, ContextCallback, "goActive");
                    menu.AddItem(new GUIContent("Add GameObject Distance Node"), false, ContextCallback, "goDistance");
                    menu.AddItem(new GUIContent("Add Timer Node"), false, ContextCallback, "timerNode");

                    menu.ShowAsContext();
                    e.Use();
                }
                else
                {
                    //if it clicked on a window add items to make transition or delete node
                    GenericMenu menu = new GenericMenu();

                    menu.AddItem(new GUIContent("Make Transition"), false, ContextCallback, "makeTransition");
                    menu.AddSeparator("");
                    menu.AddItem(new GUIContent("Delete Node"), false, ContextCallback, "deleteNode");

                    //we use it so that it will show
                    menu.ShowAsContext();
                    //consumes the event
                    e.Use();
                }
            }
        } //if we are in a transition mode and there is a left click




    }






    void ContextCallback(object obj)
    {
        //make the passed object to a string
        string clb = obj.ToString();

        //add the node we want
        if (clb.Equals("inputNode"))
        {

            InputNode inputNode = new InputNode();
            inputNode.windowRect = new Rect(mousePos.x, mousePos.y, 200, 150);

            windows.Add(inputNode);

        }
        else if (clb.Equals("outputNode"))
        {
            OutputNode outputNode = new OutputNode();
            outputNode.windowRect = new Rect(mousePos.x, mousePos.y, 200, 100);

            windows.Add(outputNode);

        }




        /*
        else if (clb.Equals("makeTransition"))
        {
            bool clickedOnWindow = false;
            int selectedIndex = -1;
            //find the window that it was clicked
            for (int i = 0; i < windows.Count; i++)
            {
                if (windows[i].windowRect.Contains(mousePos))
                {
                    selectedIndex = i;
                    clickedOnWindow = true;
                    break;
                }
            }

            //and make it the selected node of the transition
            if (clickedOnWindow)
            {
                selectedNode = windows[selectedIndex];
                makeTransitionMode = true;
            }

        }
        else if (clb.Equals("deleteNode")) //if it's a delete node
        {
            bool clickedOnWindow = false;
            int selectedIndex = -1;

            //find the selected node
            for (int i = 0; i < windows.Count; i++)
            {
                if (windows[i].windowRect.Contains(mousePos))
                {
                    selectedIndex = i;
                    clickedOnWindow = true;
                    break;
                }
            }


            if (clickedOnWindow)
            {
                //delete it from our list
                BaseNode selNode = windows[selectedIndex];
                windows.RemoveAt(selectedIndex);

                //then pass it to all our nodes that is deleted
                foreach (BaseNode n in windows)
                {
                    n.NodeDeleted(selNode);
                }
            }
        }
        */

        //we use else if instead of a switch because:
        /*Selecting from a set of multiple cases is faster with if statements than with switch 
         */
    }

}