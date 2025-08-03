using UnityEngine;

public class ShaderOverrider : MonoBehaviour
{
    public Shader newShader;

    [System.Obsolete]
    void Start()
    {
        Renderer[] allRenderers = FindObjectsOfType<Renderer>();

        foreach (Renderer rend in allRenderers)
        {
            foreach (Material mat in rend.materials)
            {
                // Eski property'leri kaydet
                Texture mainTex = mat.GetTexture("_MainTex");
                Color color = mat.GetColor("_Color");

                // Shader'ı değiştir
                mat.shader = newShader;

                // Eski property'leri geri koy
                if (mainTex != null) mat.SetTexture("_MainTex", mainTex);
                mat.SetColor("_Color", color);
            }
        }
    }
}
