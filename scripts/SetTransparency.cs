using UnityEngine;

public class SetTransparency : MonoBehaviour
{
    public string targetTag = "TransparentObject";
    public float transparency = 0f;

    void Start()
    {
        GameObject[] transparentObjects = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject transparentObject in transparentObjects)
        {
            Renderer objectRenderer = transparentObject.GetComponent<Renderer>();
            Material objectMaterial = new Material(objectRenderer.sharedMaterial);

            objectMaterial.SetFloat("_Mode", 2);
            objectMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objectMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objectMaterial.SetInt("_ZWrite", 0);
            objectMaterial.DisableKeyword("_ALPHATEST_ON");
            objectMaterial.EnableKeyword("_ALPHABLEND_ON");
            objectMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            objectMaterial.renderQueue = 3000;

            Color objectColor = objectMaterial.color;
            objectColor.a = transparency;
            objectMaterial.color = objectColor;

            objectRenderer.sharedMaterial = objectMaterial;
        }
    }
}
