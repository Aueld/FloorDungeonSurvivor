using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    public UIButtonNavigation UBN;

    // UI
    public Text lvText;
    public Text destroyEnemyCount;
    public Text playTimeText;

    public Image soulBar;
    public GameObject rewardPanel;
    public GameObject startPanel;

    // 능력
    public AbilityManager abilityManager;

    // 플레이어 객체
    public GameObject player;

    // 플레이어 레벨
    public int level = 1;
    public float experience;
    public float maxExperience;

    // 처치 수, 게임 타이머
    private float timeDS = 1.2f;
    private int destroyEnemyCnt = 0;
    private int wave = 1;
    private int gameTime = 0;
    private float gameTimer = 0f;

    private bool isBossSpawn;

    private string[] enemyNames = { "Skeleton", "Goblin", "Boss1" };

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (inst != this)
            { Destroy(gameObject); }
        }

        Application.targetFrameRate = 60;
        Time.timeScale = 0;
    }

    private void Update()
    {
        PlayTime();
        Spawn();
    }

    public void GameStart()
    {
        Time.timeScale = timeDS;
        startPanel.SetActive(false);    // 시작 메뉴
    }

    public void ReStart()   // 재시작
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void PlayTime() // 타이머
    {
        gameTimer += Time.deltaTime;
        if (gameTimer >= 1)
        {
            gameTime++;
            int minutes = gameTime / 60;
            int seconds = gameTime % 60;

            playTimeText.text = $"{minutes:D2}:{seconds:D2}";   // 타이머 표시
            gameTimer = 0;
        }
    }

    /* Old PlayTime
    private void PlayTime() // 타이머
    {
        gameTimer += Time.deltaTime;
        if (gameTimer >= 1)
        {
            gameTime++;
            playTimeText.text = string.Format("{0:D2}:{1:D2}", gameTime / 60, gameTime % 60);   // 타이머 표시
            gameTimer = 0;
        }
    }
    */

    // 적 소환 (player의 위치에서 원형으로 랜덤 소환)
    // 5초마다 10 + level 마리씩 소환, 최대 120마리 + maxUnit (30)
    private void Spawn()
    {
        if (ObjectPool.Instance.MonsterPoolCount > 120 || gameTime <= 5 * wave)
            return;

        wave++;
        int maxUnit = Mathf.Min(30, 5 + level);

        for (int i = 0; i < maxUnit; i++)
        {
            if (ObjectPool.Instance.MonsterPoolCount > 120)
                return;

            int ran = Random.Range(0, 10);
            int index = (ran > 3) ? 0 : 1;

            var enemyName = isBossSpawn ? enemyNames[2] : enemyNames[index];
            
            if (isBossSpawn)
                isBossSpawn = false;

            var obj = ObjectPool.Instance.GetObject(enemyName);
            EnemyController enemyController = obj.GetComponent<EnemyController>();

            enemyController.SetSetting(this, player, player.GetComponent<Player>());

            obj.transform.position = RandomPosition();
            obj.SetActive(true);

            enemyController.DoSomething();
        }
    }

    /*{    Old Spawn
    //private void Spawn()
    //{
    //    if (ObjectPool.Instance.MonsterPoolCount > 120)
    //        return;

    //    int maxUnit = 5 + level;

    //    if (maxUnit > 30)
    //        maxUnit = 30;
    
    //    if(gameTime > 5 * wave)  // 5초마다
    //    {
    //        wave++;

    //        for (int i = 0; i < maxUnit; i++)
    //        {
    //            if (ObjectPool.Instance.MonsterPoolCount > 120)
    //                return;

    //            int ran = Random.Range(0, 10);
    //            int index;

    //            if (ran > 3)
    //                index = 0;
    //            else
    //                index = 1;

    //            var obj = ObjectPool.Instance.GetObject(enemyNames[index]);// enemyNames[index]);
    //            EnemyController enemyController;


    //            if (isBossSpawn)
    //            {
    //                isBossSpawn = false;
    //                obj = ObjectPool.Instance.GetObject(enemyNames[2]);// enemyNames[index]);
    //            }

    //            enemyController = obj.GetComponent<EnemyController>();
    //            enemyController.gm = this;
    //            enemyController.player = player;
    //            obj.transform.position = RandomPosition();
    //            obj.SetActive(true);
    //        }
            
    //    }
    //}
    }*/

    public void DestroyEnemyCount() // 몬스터 처치 수
    {
        destroyEnemyCnt++;

        if (destroyEnemyCnt % 100 == 0) // 100마리 처치시 마다 보스 소환
            isBossSpawn = true;
        
        destroyEnemyCount.text = destroyEnemyCnt.ToString();
    }

    public Vector3 RandomPosition() // 플레이어 주변 원 방향으로 위치
    {
        float ranAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        float radius = 60f;

        Vector3 offset = new Vector3(Mathf.Cos(ranAngle), Mathf.Sin(ranAngle), 0f) * radius;
        Vector3 pos = player.transform.position + offset;

        return pos;
    }

    /* Old RandPos
    public Vector3 RandomPosition() // 플레이어 주변 원 방향으로 위치
    {
        float ranAngle = Random.Range(0, 360) * Mathf.Deg2Rad;
        
        Vector3 pos = player.transform.position + new Vector3(60 * Mathf.Cos(ranAngle), 60 * Mathf.Sin(ranAngle), 0);

        return pos;
    }
    */

    public void LevelUp(float expAmount)
    {
        experience += expAmount;

        UpdateUI();
        UBN.SelectButton();

        if (experience >= maxExperience)
        {
            rewardPanel.SetActive(true);

            level++;
            experience -= maxExperience;
            maxExperience *= (level % 10 == 0) ? 1.2f : 1.1f;

            Time.timeScale = 0;

            abilityManager.Display();
        }
    }

    private void UpdateUI()
    {
        lvText.text = "LV : " + level.ToString();
        soulBar.fillAmount = experience / maxExperience;
    }

    /* expAmount
    public void LevelUp(float expAmount)    // 경험치 관리
    {
        experience += expAmount;
        
        lvText.text = "LV : " + level.ToString();
        soulBar.fillAmount = experience / maxExperience;

        if (experience >= maxExperience)
        {
            rewardPanel.SetActive(true);

            level++;
            experience = experience - maxExperience;
            maxExperience *= 1.1f;

            if (level % 10 == 0)        // 1레벨마다 *1.1, 10레벨마다 *1.2
                maxExperience *= 1.2f;

            lvText.text = "LV : " + level.ToString();
            soulBar.fillAmount = experience / maxExperience;

            Time.timeScale = 0;

            abilityManager.Display();
        }
    }
    */

    public void Resume()    // 게임 재개
    {
        Time.timeScale = timeDS;
        rewardPanel.SetActive(false);
    }
}
