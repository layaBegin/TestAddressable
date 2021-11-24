using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressablesManagerCOMPLETE : MonoBehaviour
{
    //强制在面板显示私有化变量
    [SerializeField] Image image;

    [SerializeField] AssetReference assetReference;
    [SerializeField] AssetReferenceGameObject assetReferenceGameObject;
    [SerializeField] AssetReferenceSprite assetReferenceSprite;
    

    //加载预制体
    public void AddressablesPrefab()
    {
        Debug.Log("===加载Prefab");
        Addressables.InstantiateAsync(assetReferenceGameObject).Completed += onInstantiatePrefabCompleted;
        
    }

    void onInstantiatePrefabCompleted(AsyncOperationHandle<GameObject> handle)
    {
        GameObject cube = handle.Result;
        cube.transform.position = new Vector3(3, 12, 0);
        cube.transform.rotation = Quaternion.identity;
        cube.transform.Rotate(Vector3.up, 30);
    }

    //加载场景
    public void AddressablesScene()
    {
        Debug.Log("===加载Scene");
        assetReference.LoadSceneAsync(UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    //加载图片
    public void AddressablesSprite()
    {
        Debug.Log("===加载图片");
        assetReferenceSprite.LoadAssetAsync().Completed += OnSpriteLoaded;
    }

    void OnSpriteLoaded(AsyncOperationHandle<Sprite> handle)
    {
        image.sprite = handle.Result;
    }
}
