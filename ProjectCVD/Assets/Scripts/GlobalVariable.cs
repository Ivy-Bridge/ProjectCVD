using System.Collections;
using System.Collections.Generic;

namespace GlobalVariable
{
    /// <summary>
    /// ENUM 용병 타입
    /// </summary>
    public enum E_MECENARY_TYPE
    {
        /// <summary>
        /// 0,1,2 일반
        /// 3,4,5 일반2
        /// 6,7,8 전세역전
        /// </summary>

        warrior = 0,    // 공격 몰빵
        archer,         // 곡선 궁수
        mage,           // 직선 파이어볼

        tanker,         // 방어 몰빵
        ranger,         // 직선 궁수
        archmage,       // 직선 레이저

        ironwall,       // 최강 체력/방어력
        steelrain,      // 곡선 폭탄 다수
        destroyer       // 지우개
    }

    /// <summary>
    /// ENUM 장비 타입
    /// </summary>
    public enum E_EQUIP_TYPE
    {
        weapon,         // 무기
        armor           // 방어구
    }

    public enum E_ATTACK_TYPE
    {
        charge,             // 박치기
        sinArchage,         // 곡선 화살
        sinBomb,            // 곡선 폭탄 (스플래시)
        straightArchage,    // 직선 화살
        stratghtLazer,      // 직선 레이저
        straightBomb,       // 직선 폭탄
        erase,              // 지우개
    }


    /// <summary>
    /// ENUM 세력구분 - 캐슬이냐 던전이냐
    /// </summary>
    public enum E_GROUP
    {
        castle,
        dungeon,
    }

    public struct ST_EQUIP
    {
        public ST_EQUIP(E_EQUIP_TYPE type, float value)
        {
            this.type = type;
            this.value = value;
        }

        E_EQUIP_TYPE type;
        float value;
    }

    /// <summary>
    /// STRUCT 용병 데이터 ( 자동 생산, 수동 출격 )
    /// </summary>
    public struct ST_MECENARY
    {
        public string name;

        public int maxEnableBuildCnt; //최대 생산 수 (일반 5, 전세역전 1)
        public int useImageId;
 
        public float buildTIme;
        public float moveSpeed;
        public float hp;
        public float atk;
        public float def;

        public ST_EQUIP weapon;
        public ST_EQUIP armor;

        public E_MECENARY_TYPE type;
    }

    /// <summary>
    /// STRUCT 영웅 데이터 ( 생산 x , 자동 출격 )
    /// </summary>
    public struct ST_HERO
    {
        public int maxSpawnCnt;
        public int useImageId;

        public float spawnTIme;
        public float moveSpeed;
        public float hp;
        public float atk;
        public float def;

        public ST_EQUIP weapon;
        public ST_EQUIP armor;

    }

    /// <summary>
    /// 각 진영 필드 정보
    /// </summary>
    [System.Serializable]
    public struct ST_FIELD
    {
        public ST_FIELD_INFO castle;
        public ST_FIELD_INFO dungeon;
    }

    [System.Serializable]
    public struct ST_FIELD_INFO
    {
        public int floor;
        public string color;
    }
}

