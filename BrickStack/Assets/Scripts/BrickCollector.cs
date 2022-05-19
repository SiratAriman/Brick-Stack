using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class BrickCollector : MonoBehaviour
{
    public Transform Holster;
    public List<Vector3> HolsterLocation = new List<Vector3>();
    public Stack<GameObject> HolsterStack = new Stack<GameObject>();
    public int cubeCount = 0;

    private void Start()
    {
        DetermineHolsterLocation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick") && cubeCount < 20)
        {
            AddNewCube(other.transform);
        }
    }

    private void DetermineHolsterLocation()
    {
        for (int i = 0; i <= 20; i++)
        {
            var currentLocation = new Vector3(0, 0.12f * i , 0);
            HolsterLocation.Add(currentLocation);
        }
    }

    private void AddNewCube(Transform CubeToAdd)
    {
        if (Holster.childCount <= 20)
        {
            var oldscale = CubeToAdd.transform.localScale;
            CubeToAdd.SetParent(Holster,true);
            CubeToAdd.DOLocalJump(HolsterLocation[cubeCount], 1, 1, .5f);
            CubeToAdd.DOLocalRotate(Vector3.zero, .5f);
            HolsterStack.Push(CubeToAdd.gameObject);
            CubeToAdd.GetComponent<BoxCollider>().enabled = false;
            cubeCount++;
            CubeToAdd.transform.localScale = oldscale;
        }
    }
}
