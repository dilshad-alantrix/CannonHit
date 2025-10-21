using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T: MonoBehaviour
{
    public T Obj;
    private Queue<T> poolList = new();

    public T GetObj()
    {
        if (poolList.Count != 0)
        {
            return poolList.Dequeue();
        }

        T newObj = GameObject.Instantiate(Obj);
        return newObj;
    }

    public void SetObj(T Obj)
    {
        poolList.Enqueue(Obj);
    }
}
