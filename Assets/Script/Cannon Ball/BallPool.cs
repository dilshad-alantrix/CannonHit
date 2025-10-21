using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    [SerializeField] private GameObject BallPrefab;
    private List<GameObject> poolList= new();

    public GameObject GetObj()
    {
        foreach (var obj in poolList)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(BallPrefab);
        poolList.Add(newObj);
        return newObj;
    }

    public void SendBackToPool(GameObject gameObject)
    {
        poolList.Add(gameObject);
    }
}
