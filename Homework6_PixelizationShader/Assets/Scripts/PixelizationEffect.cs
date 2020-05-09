using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PixelizationEffect : MonoBehaviour
{
    [SerializeField]
    private Vector2 cellSize = new Vector2(4, 4);
    public Material pixelateEffectMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {

        pixelateEffectMaterial.SetFloat("_ScreenWidth", Screen.width);
        pixelateEffectMaterial.SetFloat("_ScreenHeight", Screen.height);
        pixelateEffectMaterial.SetFloat("_CellSizeX", cellSize.x);
        pixelateEffectMaterial.SetFloat("_CellSizeY", cellSize.y);

        Graphics.Blit(source, destination, pixelateEffectMaterial);
	}
}
