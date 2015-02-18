using UnityEngine;

namespace Assets.Scripts.voxel.Shaders
{
    [ExecuteInEditMode]
    [RequireComponent(typeof (Camera))]
    public class TVShader : MonoBehaviour
    {
        public Shader ActiveShader;
        private Material _material;
        [Range(0, 1)] public float VertsForce = 0.51f;
        [Range(0, 1)] public float VertsForce2 = 0.255f;
        [Range(0, 1)] public float ScanColor = 0.4f;
        [Range(-3, 20)] public float Contrast = 2.1f;
        [Range(-200, 200)] public float Brightness = 27f;

        protected Material Material
        {
            get
            {
                if (_material == null)
                    _material = new Material(ActiveShader) {hideFlags = HideFlags.HideAndDontSave};

                return _material;
            }
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (ActiveShader == null)
                return;

            var material = Material;
            material.SetFloat("_VertsColor", 1 - VertsForce);
            material.SetFloat("_VertsColor2", 1 - VertsForce2);
            material.SetFloat("_ScansColor",  ScanColor);
            material.SetFloat("_Contrast", Contrast);
            material.SetFloat("_Br", Brightness);
            Graphics.Blit(source, destination, material);
        }

        private void OnDisable()
        {
            if (_material)
                DestroyImmediate(_material);
        }
    }
}