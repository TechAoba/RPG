using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSkillTree : MonoBehaviour
{
    public CanvasGroup statsCanvas;
    private bool skillTreeOpen = false;
    
    void Update()
    {
        if (Input.GetButtonDown("ToggleSkillTree"))
        {   
            // 关闭技能树
            if (skillTreeOpen)
            {
                Time.timeScale = 1;
                statsCanvas.alpha = 0;
                statsCanvas.blocksRaycasts = false;     // 不阻挡射线投射
                skillTreeOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                statsCanvas.alpha = 1;
                statsCanvas.blocksRaycasts = true;
                skillTreeOpen = true;
            }
        }
    }
}
