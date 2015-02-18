using Assets.Scripts.voxel.Blocks;
using UnityEngine;

namespace Assets.Scripts.voxel
{
    public class Modify : MonoBehaviour
    {
        private Vector2 _rot;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
                    Terrain.SetBlock(hit, new BlockAir());
            }

            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
                {
                    
                }
                    //Terrain.SetBlock(hit, new BlockGrass(), true);
            }

            if(Input.GetKey(KeyCode.Escape))
                Application.Quit();
        }
    }
}