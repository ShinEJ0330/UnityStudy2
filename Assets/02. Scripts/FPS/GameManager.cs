using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace fps
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager gm;
        public enum GameState { Ready, Run, GameOver }
        public GameState gState;
        public GameObject gameLabel;
        private TextMeshProUGUI gameText;
        private PlayerMove pm;

        void Start()
        {
            gState = GameState.Ready;
            gameText = gameLabel.GetComponent<TextMeshProUGUI>();

            gameText.text = "Ready...";
            gameText.color = new Color32(255, 185, 0, 255);

            StartCoroutine(ReadyToStart());

            pm = GameObject.Find("Player").GetComponent<PlayerMove>();
        }

        void Update()
        {
            if (pm.hp <= 0)
            {
                pm.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);
                gameLabel.SetActive(true);
                gameText.text = "Game Over";
                gameText.color = new Color32(255, 0, 0, 255);
                gState = GameState.GameOver;
            }
        }
        IEnumerator ReadyToStart()
        {
            yield return new WaitForSeconds(2f);
            gameText.text = "Go!";
            gameText.color = new Color32(140, 255, 100, 255);

            yield return new WaitForSeconds(0.5f);
            gameLabel.SetActive(false);

            gState = GameState.Run;
        }

        private void Awake()
        {
            if (gm == null)
            {
                gm = this;
            }
        }
    }
}
