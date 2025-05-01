using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public int Players { get; set; }

    private void Awake()
    {
        SetAsSingleton();
    }

    private void SetAsSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
