using UnityEngine;

[ExecuteInEditMode]
public class CameraWaterEffect : MonoBehaviour {

	[SerializeField] private Material _effectMaterial;

	void OnRenderImage(RenderTexture src, RenderTexture dst) {
		Graphics.Blit(src, dst, _effectMaterial);
	}



}
