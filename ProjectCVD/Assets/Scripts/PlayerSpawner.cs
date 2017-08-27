using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    /// <summary>
    /// 전역 변수
    /// </summary>

    public bool isGameStart = false;
#if DEBUG
    public PlayerInfo info;
#else
    private PlayerInfo info;
#endif
    public GameObject heroPool;
    private List<float> cntMecenaryTime;

    private void Awake()
    {
        heroPool.SetActive(true);
#if DEBUG
        info.debugSetupDungeon();
#endif
        cntMecenaryTime = new List<float>();
    }
    // Use this for initialization
    void Start () {
        //최초 용병 생성 개수 세팅
        for (int i = 0; i < info.mecenary.Capacity; i++)
            cntMecenaryTime.Add(0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (isGameStart)
        {
            StartCoroutine(spawnHeroAuto());
            StartCoroutine(checkTimeBuildMercenary());
        }
    }


    /// <summary>
    /// 영웅 출격 ( 자동 출격 )
    /// </summary>
    void spawnHero()
    {

    }


    /// <summary>
    /// 용병 생산 ( 수동 출격 )
    /// </summary>
    /// <param name="index"></param>
    void buildMecenary(int index)
    {
        cntMecenaryTime[index] = 0.0f;

        //용병을 생성한다.

    }

    /// <summary>
    /// 용병 출격
    /// </summary>
    void spawnMecenary()
    {

    }

    /// <summary>
    /// COROUTINE 용병 빌드 체크
    /// </summary>
    /// <returns></returns>
    IEnumerator checkTimeBuildMercenary()
    {
        while(true)
        {
            for(int i = 0; i < cntMecenaryTime.Capacity; i++)
            {
                cntMecenaryTime[i] += Time.deltaTime;

                //설정된 용병 생성 시간보다 타이머 시간이 커지면, 생산
                if (cntMecenaryTime[i] > info.mecenary[i].buildTIme)
                {
                    buildMecenary(i);
                }
            }
            yield return null;
        }
    }

    /// <summary>
    /// COROUTIE 영웅 자동 소환 체크
    /// </summary>
    /// <returns></returns>
    IEnumerator spawnHeroAuto()
    {
        while(true)
        {
            spawnHero();

            // 코루틴을 설정 시간 간격으로 동작하게 해서 출격 제어
            yield return new WaitForSeconds(info.hero.spawnTIme);
        }
    }
}
