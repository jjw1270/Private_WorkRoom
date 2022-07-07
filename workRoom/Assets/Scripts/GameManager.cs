using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FocusModeData
{
    public int FocusTimeMin;
    public int myMoney;
    //public string nowSkillName = "";
    // public bool haveSkill() => nowSkillName == "" ? false : true;
    // public List<string> SkillNameSet = new List<string> { };
    // public GameObject[] SkillResource;
    // public int nowProgressLevel;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public FocusModeData focusModeData;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
        //focusModeData = new FocusModeData { FocusTimeMin = 30, SkillNameSet = { "Fire", "Barrier", "Water" }, nowProgressLevel = 0 };
        focusModeData = new FocusModeData { FocusTimeMin = 30};
        //focusModeData.SkillResource = new GameObject[focusModeData.SkillNameSet.Count];
        ResourceLoad();
    }
     public void ResourceLoad()
    {
        // for (int i = 0; i < focusModeData.SkillNameSet.Count; i++)
        // {
        //     focusModeData.SkillResource[i] = Resources.Load<GameObject>(string.Format("SkillEffect/{0}", focusModeData.SkillNameSet[i]));
        // }
    }
}
