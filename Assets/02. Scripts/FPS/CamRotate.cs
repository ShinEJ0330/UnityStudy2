using UnityEngine;

namespace fps
{
    public class CamRotate : MonoBehaviour
    {
        public float rotSpeed = 200f;
        public float mx = 0;
        public float my = 0;

        void Update()
        {
            if (GameManager.gm.gState != GameManager.GameState.Run) return;
            
            float mouse_X = Input.GetAxis("Mouse X");
            float mouse_Y = Input.GetAxis("Mouse Y");

            //Vector3 dir = new Vector3(-mouse_Y, mouse_X, 0f);

            mx += mouse_X * rotSpeed * Time.deltaTime;
            my += mouse_Y * rotSpeed * Time.deltaTime;

            my = Mathf.Clamp(my, -90f, 90f);

            //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;

            //Vector3 rot = transform.eulerAngles;
            //rot.x = Mathf.Clamp(rot.x, -90f, 90f);
            transform.eulerAngles = new Vector3(-my, mx, 0);
        }
    }
}