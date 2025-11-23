using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RandomItemSpawn : MonoBehaviour {
private float MinX;
private float MaxX;
public string ItemType;
public GameObject Origin;
public GameObject Item;

    public void SpawnItem(){
        float RandomCoordinateX = UnityEngine.Random.Range(MinX, MaxX);
        Origin = GameObject.Find(ItemType);
        Item = Instantiate(Origin, new Vector3(RandomCoordinateX, 100, 1), Quaternion.identity);
        StartCoroutine(Drop(Item));
    }

    private void Update()
    {
    }

    IEnumerator Drop(GameObject item)
    {
        while (item.transform.position.x >= 0)
        {
            item.transform.position = new Vector3(item.transform.position.x - 0.2f, item.transform.position.y, 1);
            yield return null;
        }
    }
}