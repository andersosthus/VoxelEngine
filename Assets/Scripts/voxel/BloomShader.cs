using UnityEngine;

namespace Assets.Scripts.voxel
{
    [ExecuteInEditMode]
    [RequireComponent(typeof (Camera))]
    public class BloomShader : MonoBehaviour
    {
        public Shader ActiveShader;
        public float BlurWidth = 1f;
        public bool ExtraBlurry = false;
        public float Intensity = 0.7f;
        public float Threshold = 0.75f;
        private Material _material;


        protected Material Material
        {
            get
            {
                if (_material == null)
                    _material = new Material(ActiveShader) {hideFlags = HideFlags.HideAndDontSave};

                return _material;
            }
        }
    }
}