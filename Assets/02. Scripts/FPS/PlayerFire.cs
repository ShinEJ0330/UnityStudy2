using UnityEngine;

namespace fps
{
    public class PlayerFire : MonoBehaviour
    {
        public GameObject firePosition;
        public GameObject bombFactory;
        public GameObject bulletEffect;

        private ParticleSystem ps;
        public float throwPower = 15f;

        void Start()
        {
            ps = bulletEffect.GetComponent<ParticleSystem>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit hitInfo = new RaycastHit();

                if (Physics.Raycast(ray, out hitInfo))
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal;
                    ps.Play();
                }
            }
            if (Input.GetMouseButtonDown(1))
                {
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rd = bomb.GetComponent<Rigidbody>();
                    rd.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
                }
        }
    }
}