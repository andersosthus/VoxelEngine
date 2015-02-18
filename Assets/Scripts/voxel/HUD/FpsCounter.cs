using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.voxel.HUD
{
    public class FpsCounter : MonoBehaviour
    {
        public float UpdateInterval = 0.5f;
        private float _accumulated = 0;
        private int _frames = 0;
        private float _timeLeft;

        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
            if (_text == null)
            {
                Debug.LogWarning("Can't find the GUIText component!");
                enabled = false;
                return;
            }

            _timeLeft = UpdateInterval;
        }

        private void Update()
        {
            _timeLeft -= Time.deltaTime;
            _accumulated += Time.timeScale/Time.deltaTime;
            ++_frames;

            if (_timeLeft > 0.0)
                return;

            var fps = _accumulated/_frames;
            var fpsText = string.Format("{0:F2} FPS", fps);
            _text.text = fpsText;

            if (fps < 30)
                _text.material.color = Color.yellow;
            else if (fps < 10)
                _text.material.color = Color.red;
            else
                _text.material.color = Color.green;

            _timeLeft = UpdateInterval;
            _accumulated = 0.0f;
            _frames = 0;
        }
    }
}