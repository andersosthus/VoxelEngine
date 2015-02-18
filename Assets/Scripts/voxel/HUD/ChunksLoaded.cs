using UnityEngine;

namespace Assets.Scripts.voxel.HUD
{
    public class ChunksLoaded : BaseUiText
    {
        private World _world;

        private void Start()
        {
            _world = FindObjectOfType<World>();

            if (_world == null)
            {
                Debug.LogWarning("World not found!");
                enabled = false;
                return;
            }

            base.Start();
        }

        private void Update()
        {
            TimeLeft -= Time.deltaTime;

            if (TimeLeft > 0.0)
                return;

            Text.text = string.Format("{0} Chunks loaded", _world.ChunksInMemory);

            TimeLeft = UpdateInterval;
        }
    }
}