using System.Collections;
using System.Collections.Generic;
using GlobalVariable;

[System.Serializable]
public class PlayerInfo {  
    public E_GROUP group;
    public List<ST_MECENARY> mecenary;
    public ST_HERO hero;

    PlayerInfo()
    {
        init();
    }

    public void init()
    {
#if DEBUG
        if(group == E_GROUP.castle)
        {
        }
        else
        {
        }
        mecenary = new List<ST_MECENARY>();
#endif
    }


    #region DEBUG SETUP
    public void debugSetupDungeon()
    {
        ST_MECENARY me = new ST_MECENARY();

        me.name = "던전전사";
        me.hp = 10.0f;
        me.def = 5.0f;
        me.atk = 2.0f;
        me.buildTIme = 1.0f;
        me.maxEnableBuildCnt = 5;
        me.moveSpeed = 0.3f;
        me.type = E_MECENARY_TYPE.warrior;
        me.weapon = new ST_EQUIP(E_EQUIP_TYPE.weapon, 0.1f);
        me.armor = new ST_EQUIP(E_EQUIP_TYPE.armor, 0.1f);
        mecenary.Add(me);

        me.name = "던전궁수";
        me.hp = 10.0f;
        me.def = 5.0f;
        me.atk = 2.0f;
        me.buildTIme = 1.0f;
        me.maxEnableBuildCnt = 5;
        me.moveSpeed = 0.3f;
        me.type = E_MECENARY_TYPE.warrior;
        me.weapon = new ST_EQUIP(E_EQUIP_TYPE.weapon, 0.1f);
        me.armor = new ST_EQUIP(E_EQUIP_TYPE.armor, 0.1f);
        mecenary.Add(me);

        me.name = "던전탱커";
        me.hp = 10.0f;
        me.def = 5.0f;
        me.atk = 2.0f;
        me.buildTIme = 1.0f;
        me.maxEnableBuildCnt = 5;
        me.moveSpeed = 0.3f;
        me.type = E_MECENARY_TYPE.warrior;
        me.weapon = new ST_EQUIP(E_EQUIP_TYPE.weapon, 0.1f);
        me.armor = new ST_EQUIP(E_EQUIP_TYPE.armor, 0.1f);
        mecenary.Add(me);

        me.name = "던전턴페이스";
        me.hp = 10.0f;
        me.def = 5.0f;
        me.atk = 2.0f;
        me.buildTIme = 1.0f;
        me.maxEnableBuildCnt = 5;
        me.moveSpeed = 0.3f;
        me.type = E_MECENARY_TYPE.warrior;
        me.weapon = new ST_EQUIP(E_EQUIP_TYPE.weapon, 0.1f);
        me.armor = new ST_EQUIP(E_EQUIP_TYPE.armor, 0.1f);
        mecenary.Add(me);
    }
    #endregion
}
