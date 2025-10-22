using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T: MonoBehaviour
{
    public T Obj;
    private Queue<T> poolList = new();

    public T GetObj()
    {
        if (poolList.Count > 0)
        {
            T item = poolList.Dequeue();
            item.gameObject.SetActive(true);
            return item;
        }

        T newObj = GameObject.Instantiate(Obj);
        return newObj;
    }

    public void SetObj(T Obj)
    {
        Obj.gameObject.SetActive(false);
        poolList.Enqueue(Obj);
    }
}
