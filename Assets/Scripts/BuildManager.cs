using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    public GameObject knifeTower;
    public GameObject iceTower;
    public GameObject grillTower;

    public GameObject selectedTower;

    public void SetTurretToBuild(GameObject tower)
    {
        selectedTower = tower;
    }
}
