using System;
using UnityEngine;

[ExecuteInEditMode]
public class CameraWaterEffect : MonoBehaviour {

	[SerializeField] private Material _effectMaterial;
	[Range(0, 0.1f) , SerializeField] private float _magnitude;
	
	void OnRenderImage(RenderTexture src, RenderTexture dst) {
		Graphics.Blit(src, dst, _effectMaterial);
	}

	private void Update() {
		
		_effectMaterial.SetFloat("_Magnitude", _magnitude);
	}
}
