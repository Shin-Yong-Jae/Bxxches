using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void Updated();
}

public class ButtonSubject : MonoBehaviour
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var o in observers)
        {
            o.Updated();
        }
    }
}
