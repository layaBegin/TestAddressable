using UnityEngine;
using UnityEngine.AddressableAssets;

public class SelfDestruct : MonoBehaviour
{

    [SerializeField] private float lifetime = 2f;

    private void Start()
    {
        Invoke("Release", lifetime);
    }

    void Release()
    {
        //释放资源
        Addressables.ReleaseInstance(gameObject);
    }
}
