using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

namespace fps
{
    public class EnemyFSM : MonoBehaviour
    {
        private enum EnemyState { Idle, Move, Attack, Return, Damaged, Die };
        private EnemyState m_State;

        private Transform player;
        private CharacterController cc;

        public float attackDistance = 3f;
        public float moveSpeed = 5f;
        public float findDistance = 8f;

        private float currentTime = 0f;
        private float attackDelay = 2f;

        public int attackPower = 3;
        public int hp = 15;
        private int maxHp = 15;
        public Slider hpslider;

        private Vector3 originPos;
        private Quaternion originRot;
        public float moveDistance = 20f;


        private Animator anim;

        void Start()
        {
            m_State = EnemyState.Idle;
            player = GameObject.Find("Player").transform;
            cc = GetComponent<CharacterController>();
            originPos = transform.position;
            originRot = transform.rotation;
            anim = transform.GetComponentInChildren<Animator>();
        }

        void Update()
        {
            switch (m_State)
            {
                case EnemyState.Idle:
                    Idle();
                    break;
                case EnemyState.Move:
                    Move();
                    break;
                case EnemyState.Attack:
                    Attack();
                    break;
                case EnemyState.Return:
                    Return();
                    break;
                case EnemyState.Damaged:
                    //Damaged();
                    break;
                case EnemyState.Die:
                    //Die();
                    break;
            }

            hpslider.value = (float)hp / (float)maxHp;
        }

        private void Idle()
        {
            if (Vector3.Distance(transform.position, player.position) < findDistance)
            {
                m_State = EnemyState.Move;
                Debug.Log("상태전환 : Idle >> Move");

                anim.SetTrigger("IdletoMove");
            }
        }
        private void Move()
        {
            if (Vector3.Distance(transform.position, originPos) > moveDistance)
            {
                m_State = EnemyState.Return;
                Debug.Log("상태전환 : Move >> Return");
            }
            else if (Vector3.Distance(transform.position, player.position) > attackDistance)
            {
                Vector3 dir = (player.position - transform.position).normalized;
                cc.Move(dir * moveSpeed * Time.deltaTime);

                transform.forward = dir;
            }
            else
            {
                currentTime = attackDelay;
                m_State = EnemyState.Attack;
                anim.SetTrigger("MovetoAttackDelay");
                Debug.Log("상태전환 : Move >> Attack");
            }
        }
        private void Attack()
        {
            if (Vector3.Distance(transform.position, player.position) < attackDistance)
            {
                currentTime += Time.deltaTime;

                if (currentTime > attackDelay)
                {
                    currentTime = 0f;
                    //player.GetComponent<PlayerMove>().DamageAction(attackPower);
                    anim.SetTrigger("StartAttack");
                    Debug.Log("공격");
                }
            }
            else
            {
                currentTime = 0f;
                m_State = EnemyState.Move;
                anim.SetTrigger("AttacktoMove");
                Debug.Log("상태전환 : Attack >> Move");
            }
        }
        public void AttackAction()
        {
            player.GetComponent<PlayerMove>().DamageAction(attackPower);
        }
        private void Return()
        {
            if (Vector3.Distance(transform.position, originPos) > 0.1f)
            {
                Vector3 dir = (originPos - transform.position).normalized;
                cc.Move(dir * moveSpeed * Time.deltaTime);

                transform.forward = dir;
            }
            else
            {
                transform.position = originPos;
                transform.rotation = originRot;

                hp = 15;
                m_State = EnemyState.Idle;
                Debug.Log("상태전환 : Return >> Idle");

                anim.SetTrigger("MovetoIdle");
            }
        }
        private void Damaged()
        {
            StartCoroutine(DamageProcess());
        }
        private void Die()
        {
            StopAllCoroutines();

            StartCoroutine(DieProcess());
        }

        IEnumerator DamageProcess()
        {
            yield return new WaitForSeconds(1f);

            m_State = EnemyState.Move;
            Debug.Log("상태전환 : Damaged >> Move");
        }

        IEnumerator DieProcess()
        {
            cc.enabled = false;

            yield return new WaitForSeconds(2f);
            Debug.Log("죽음");
            Destroy(gameObject);
        }

        public void HitEnamy(int hitPower)
        {
            if (m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return) return;
            hp -= hitPower;

            if (hp > 0)
            {
                anim.SetTrigger("Damaged");
                m_State = EnemyState.Damaged;
                Damaged();
                Debug.Log("상태전환 : Any State >> Damaged");
            }
            else
            {
                anim.SetTrigger("Die");
                m_State = EnemyState.Die;
                Die();
                Debug.Log("상태전환 : Any State >> Die");
            }
        }
    }
}
