﻿using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour {

    public GameObject buildEffect;
    public GameObject sellEffect;
    public GameObject teethDestroyEffect;
    private TurretBlueprint turretToBuild;

    public NodeUI nodeUI;
    private Node selectedNode;

    public static BuildManager instance;
    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError("More then one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public TurretBlueprint GetTurretToBuild ()
    {
        return turretToBuild;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

    public void SelectNode (Node node)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Debug.Log("Select Node");
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        turretToBuild = null;

        selectedNode = node;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
