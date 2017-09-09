using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalVariable;

public class InGameMgr : MonoBehaviour {
    [SerializeField]
    private ST_FIELD _fieldInfo;

    [SerializeField]
    private GameObject _fieldManager;

    // Use this for initialization
	void Start () {
#if DEBUG_LOCAL
        dbg_loadField();
        dbg_insField();
#endif
    }
	
	// Update is called once per frame
	void Update () {
		
	}

#region DBG SETTING
    void dbg_loadField()
    {
        _fieldInfo = JsonUtility.FromJson<ST_FIELD>(loadToTxt("DBG_json/dbg_instance"));
    }

    void dbg_insField()
    {
        GameObject[] floor = new GameObject[_fieldInfo.castle.floor + _fieldInfo.dungeon.floor + 1];
        // 캐슬 로딩
        for (int i = 0; i <_fieldInfo.castle.floor; i++)
        {
            //최초는 캐슬로딩
            if ( i == 0 )
            {
                floor[i] = Instantiate(Resources.Load("Prefab/Castle")) as GameObject;
                floor[i].transform.parent = _fieldManager.transform;
                floor[i].transform.Translate(new Vector2(0, 0));

                continue;
            }

            if ( i % 2 == 1)
            {
                floor[i] = Instantiate(Resources.Load("Prefab/g_castle_right")) as GameObject;
            }
            else
            {
                floor[i] = Instantiate(Resources.Load("Prefab/g_castle_left")) as GameObject;
            }
            floor[i].transform.parent = _fieldManager.transform;
            floor[i].transform.position = floor[0].transform.Find("genPos").transform.localPosition - new Vector3(0, i - 1);
            floor[i].name = "grc_" + i;
        }

        // 중간 완충지대 1개 로딩
        if(_fieldInfo.castle.floor %2 == 0)
            floor[_fieldInfo.castle.floor] = Instantiate(Resources.Load("Prefab/g_center_left")) as GameObject;
        else
            floor[_fieldInfo.castle.floor] = Instantiate(Resources.Load("Prefab/g_center_right")) as GameObject;

        floor[_fieldInfo.castle.floor].transform.parent = _fieldManager.transform;
        floor[_fieldInfo.castle.floor].transform.position = floor[0].transform.Find("genPos").transform.localPosition - new Vector3(0, _fieldInfo.castle.floor - 1);
        floor[_fieldInfo.castle.floor].name = "grNewtral";

        // 던전 로딩
        for (int i = _fieldInfo.castle.floor + 1; i < floor.Length; i++)
        {
            if (i != floor.Length - 1)
            {
                //좌우 경로 구분 층 수 생성
                if (i % 2 == 1)
                {
                    floor[i] = Instantiate(Resources.Load("Prefab/g_dungeon_right")) as GameObject;
                }
                else
                {
                    floor[i] = Instantiate(Resources.Load("Prefab/g_dungeon_left")) as GameObject;
                }
                floor[i].transform.parent = _fieldManager.transform;
                floor[i].transform.position = floor[0].transform.Find("genPos").transform.localPosition - new Vector3(0, i - 1);
                floor[i].name = "grd_" + i;
            }
            else
            {
                //좌우 구분 오브젝트 생성
                if(i % 2 == 0)
                //마지막은 던전 로딩
                    floor[i] = Instantiate(Resources.Load("Prefab/Castle_right")) as GameObject;
                else
                    floor[i] = Instantiate(Resources.Load("Prefab/Castle")) as GameObject;

                floor[i].transform.parent = _fieldManager.transform;
                floor[i].transform.position = floor[0].transform.Find("genPos").transform.localPosition - new Vector3(0, i);
            }
        }
    }

    string loadToTxt(string fileName)
    {
        return System.IO.File.ReadAllText(Application.dataPath + "/" + fileName + ".txt"); ;
    }
#endregion
}
