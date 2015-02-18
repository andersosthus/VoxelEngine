using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.voxel.HUD
{
    public abstract class BaseUiText : MonoBehaviour
    {
        internal Text Text;
        internal const float UpdateInterval = 0.5f;
        internal float TimeLeft;

        internal void Start()
        {
            Text = GetComponent<Text>();
            if (Text == null)
            {
                Debug.LogWarning("Can't find the GUIText component!");
                enabled = false;
                return;
            }

            TimeLeft = UpdateInterval;
        }
    }
}