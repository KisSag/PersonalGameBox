using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{


    // player physical property
    [SerializeField] string name_player;
    [SerializeField] string gender; //male / female / neither
    [SerializeField] int age;
    [SerializeField] int height; // in cm
    [SerializeField] string[] race = new string[2]; //第一个是主种族，第二个是亚种
    [SerializeField] float body_Size; // max = 100 mid = 50 //骨瘦如柴的，消瘦的，纤细的，苗条的，标准的，宽大的，饱满的，肥胖的，圆滚滚的//该变量主要描述身体的形状
    [SerializeField] float femininity; //max = 100//男子气概的，非常男人味的，男人味的，男性，女性，女人味的，非常女人味的，充满女性魅力的//该变量衡量外表看起来是男性还是女性
    [SerializeField] float Mature; //middle = 50, max = 20 = domineering, 0 = loli //for male：正太，少年，少男，成男， for female: 幼女，萝莉，少女，御姐
    [SerializeField] float muscleDef; //max = 100 //弱不禁风的，虚弱的， 柔弱的，柔软的，正常的，紧致的，结实的，健壮的，健美的，虎背熊腰的
    [SerializeField] float appearance; //max = 100, normal = 40-50 //丑角人寰的，丑陋的，怪异的，不扬的，寻常的，出众的，令人惊叹的，超凡的，倾城的，天姿//

    //头部
    //头发 //一个2index数组，如果没有挑染，则color in index1 = index0，挑染：//无挑染，横条纹染，竖条纹染，斑点染，低渐层染，高渐层染，内挑染，混合染，独立发束染
    [SerializeField] hairProperties hairProperties;



}
