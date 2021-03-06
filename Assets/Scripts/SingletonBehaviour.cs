using UnityEngine;
using System.Collections;

public abstract class SingletonBehaviour<T> : MonoBehaviour
    where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void SingletonAwake() { }

    protected void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            Instance = this as T;
            SingletonAwake();
        }
    }

    protected virtual void SingletonDestroy() { }

    protected void OnDestroy()
    {
        if (Instance == this)
        {
            SingletonDestroy();
            Instance = null;
        }
    }
}