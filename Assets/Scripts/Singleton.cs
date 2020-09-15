using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component {
    public static T Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<T>();
                if (_instance == null) {
                    GameObject newGO = new GameObject();
                    _instance = newGO.AddComponent<T>();
                }
            }

            return _instance;
        }
    }
    private static T _instance;

    protected virtual void Awake() {
        _instance = this as T;
    }

}
