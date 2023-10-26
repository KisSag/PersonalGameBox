using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{


    // player physical property
    public string chara_Name;
    public string gender; //male / female / neither
    public int age;
    public int height; // in cm
    public RACE Race;//第一个是主种族，第二个是亚种

    
    public float femininity; //middle = 50, max = 100 //for male：正太，少年，少男，成男， for female: 幼女，萝莉，少女，御姐
    public float faceAppearance; //max = 100, normal = 40-50 //丑绝人寰的，丑陋的，怪异的，不扬的，寻常的，出众的，令人惊叹的，超凡的，倾城的，天姿//

    

    //头部
    public headProperties headProperties = new headProperties();
    //胸部
    public breastProperties breastProperties = new breastProperties();
    //躯干



}
