using UnityEngine;

namespace Assets.Scripts.voxel.Shaders
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    public class BloomShader : MonoBehaviour
    {
        public float BlurWidth = 1f;
        public bool ExtraBlurry = false;
        public float Intensity = 0.7f;
        public float Threshold = 0.75f;
        public Material Material;

        private bool _supported;
        private RenderTexture _textureA;
        private RenderTexture _textureB;

        private bool Supported()
        {
            if (_supported)
                return true;

            _supported = (SystemInfo.supportsImageEffects && SystemInfo.supportsRenderTextures && Material.shader.isSupported);
            return _supported;
        }

        private void CreateBuffers()
        {
            if (_textureA == null)
                _textureA = new RenderTexture(Screen.width / 4, Screen.height / 4, 0) { hideFlags = HideFlags.DontSave };

            if (_textureB == null)
                _textureB = new RenderTexture(Screen.width / 4, Screen.height / 4, 0) { hideFlags = HideFlags.DontSave };
        }

        private void OnDisable()
        {
            if (_textureA)
            {
                DestroyImmediate(_textureA);
                _textureA = null;
            }

            if (_textureB)
            {
                DestroyImmediate(_textureB);
                _textureB = null;
            }
        }

        private bool EarlyOutIfNotSupported(RenderTexture source, RenderTexture destination)
        {
            if (Supported())
                return false;

            enabled = false;
            Graphics.Blit(source, destination);
            return true;
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            CreateBuffers();
            if (EarlyOutIfNotSupported(source, destination))
                return;

            Material.SetVector("_Parameter", new Vector4(0.0f, 0.0f, Threshold, Intensity / (1.0f - Threshold)));

            var oneOverW = 1.0f / (source.width * 1.0f);
            var oneOverH = 1.0f / (source.height * 1.0f);

            Material.SetVector("_OffsetsA", new Vector4(1.5f * oneOverW, 1.5f * oneOverH, -1.5f * oneOverW, 1.5f * oneOverH));
            Material.SetVector("_OffsetsB", new Vector4(-1.5f * oneOverW, -1.5f * oneOverH, 1.5f * oneOverW, -1.5f * oneOverH));

            Graphics.Blit(source, _textureB, Material, 1);

            oneOverW *= 4.0f * BlurWidth;
            oneOverH *= 4.0f * BlurWidth;

            Material.SetVector("_OffsetsA", new Vector4(1.5f * oneOverW, 0.0f, -1.5f * oneOverW, 0.0f));
            Material.SetVector("_OffsetsB", new Vector4(0.5f * oneOverW, 0.0f, -0.5f * oneOverW, 0.0f));
            Graphics.Blit(_textureB, _textureA, Material, 2);

            Material.SetVector("_OffsetsA", new Vector4(0.0f, 1.5f * oneOverH, 0.0f, -1.5f * oneOverH));
            Material.SetVector("_OffsetsB", new Vector4(0.0f, 0.5f * oneOverH, 0.0f, -0.5f * oneOverH));
            Graphics.Blit(_textureA, _textureB, Material, 2);

            if (ExtraBlurry)
            {
                Material.SetVector("_OffsetsA", new Vector4(1.5f * oneOverW, 0.0f, -1.5f * oneOverW, 0.0f));
                Material.SetVector("_OffsetsB", new Vector4(0.5f * oneOverW, 0.0f, -0.5f * oneOverW, 0.0f));
                Graphics.Blit(_textureB, _textureA, Material, 2);

                Material.SetVector("_OffsetsA", new Vector4(0.0f, 1.5f * oneOverH, 0.0f, -1.5f * oneOverH));
                Material.SetVector("_OffsetsB", new Vector4(0.0f, 0.5f * oneOverH, 0.0f, -0.5f * oneOverH));
                Graphics.Blit(_textureA, _textureB, Material, 2);
            }

            Material.SetTexture("_Bloom", _textureB);
            Graphics.Blit(source, destination, Material, 0);
        }
    }
}