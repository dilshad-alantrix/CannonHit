using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    private List<Iobserver> _observers = new List<Iobserver>();

    public void AddObserver(Iobserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(Iobserver observer)
    {
        _observers.Remove(observer);
    }
    
    public void NotifyObservers(GameState state)
    {
        foreach (var observer in _observers)
        {
            observer.OnNotify(state);
        }
    }
}
