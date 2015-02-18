using UnityEngine;

namespace Assets.Scripts.voxel.HUD
{
    public class FpsCounter : BaseUiText
    {
        private float _accumulated;
        private int _frames;

        private void Update()
        {
            TimeLeft -= Time.deltaTime;
            _accumulated += Time.timeScale/Time.deltaTime;
            ++_frames;

            if (TimeLeft > 0.0)
                return;

            var fps = _accumulated/_frames;
            var fpsText = string.Format("{0:F2} FPS", fps);
            Text.text = fpsText;

            if (fps < 30)
                Text.material.color = Color.yellow;
            else if (fps < 10)
                Text.material.color = Color.red;
            else
                Text.material.color = Color.green;

            TimeLeft = UpdateInterval;
            _accumulated = 0.0f;
            _frames = 0;
        }
    }
}