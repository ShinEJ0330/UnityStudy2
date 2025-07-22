using UnityEngine;

namespace fps
{
    public class PlayerRotate : MonoBehaviour
    {
        public float rotSpeed = 200f;
        public float mx = 0;

        void Update()
        {
            if (GameManager.gm.gState != GameManager.GameState.Run) return;
            
            float mouse_X = Input.GetAxis("Mouse X");

            mx += mouse_X * rotSpeed * Time.deltaTime;

            transform.eulerAngles = new Vector3(0, mx, 0);
        }
    }
}