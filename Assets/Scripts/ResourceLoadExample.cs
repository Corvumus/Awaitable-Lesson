using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ResourceLoadExample : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private async Awaitable Start()
    {
        meshRenderer.material = await LoadResourceAsync();
    }

    private async Awaitable<Material> LoadResourceAsync()
    {
        var operation = Resources.LoadAsync<Material>("my-material");
        await operation;
        return operation.asset as Material;
    }
}
