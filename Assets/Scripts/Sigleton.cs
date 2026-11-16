using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class Sigleton<T> : MonoBehaviour where T:Component
{

    private static T instance;
    public static T Instance
    {
        get {
            if (instance == null) { 
                instance=(T)FindObjectOfType(typeof(T));
                if (instance == null) {
                    SetupInstance();
                    
                }
            }

            return instance;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(instance);

        }
        else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static void SetupInstance() { 
        instance= (T)FindObjectOfType(typeof(T));
        if (instance == null) {
            GameObject gameObj = new GameObject();
            gameObj.name = "Singleton";
            instance=gameObj.AddComponent<T>();
            DontDestroyOnLoad(gameObj);
        }

    }

}
