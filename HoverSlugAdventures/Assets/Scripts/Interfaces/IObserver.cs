using UnityEngine;
using System.Collections;

public interface IObserver
{
    void ObserverUpdate(GameObject sender, System.Object message);
}
