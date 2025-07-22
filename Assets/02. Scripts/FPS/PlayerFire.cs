using UnityEngine;
using UnityEngine.PlayerLoop;

namespace fps
{
    public class PlayerFire : MonoBehaviour
    {
        private Animator anim;
        public GameObject firePosition;

        public GameObject bombFactory;

        public float throwPower = 15f;
        public int weaponPower = 5;

        public GameObject bulletEffect;
        private ParticleSystem ps;

        void Start()
        {
            ps = bulletEffect.GetComponent<ParticleSystem>();
            anim = GetComponentInChildren<Animator>();
        }

        void Update()
        {
            if (GameManager.gm.gState != GameManager.GameState.Run) return;
            
            if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
            {
                if (anim.GetFloat("MoveMotion") == 0)
                {
                    anim.SetTrigger("Attack");
                }
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit hitInfo = new RaycastHit();

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) // Raycast를 Enemy가 맞은 경우
                    {
                        EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                        eFSM.HitEnamy(weaponPower);
                    }
                    else // Raycast를 맞은 대상이 Enemy가 아닌 경우
                    {
                        bulletEffect.transform.position = hitInfo.point;
                        bulletEffect.transform.forward = hitInfo.normal;

                        ps.Play();
                    }
                }
            }

            if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭
            {
                GameObject bomb = Instantiate(bombFactory);
                bomb.transform.position = firePosition.transform.position;

                Rigidbody rb = bomb.GetComponent<Rigidbody>();
                rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
            }
        }
    }
}