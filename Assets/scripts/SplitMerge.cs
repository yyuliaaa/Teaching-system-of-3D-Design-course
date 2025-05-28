using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplitMerge : MonoBehaviour
{
    //序列化一个数组 数组类型是物体用gameobject 存放机械零件
    [SerializeField] GameObject[] machine;

    //target 目标点
    [SerializeField] GameObject target;

    //存放向量
    [SerializeField] Vector3[] moveDir;

    //用于记录拆卸是否完成的变量
    bool isSplit = false;

    

    //按钮
    public Button btn_Split;//拆卸按钮
    public Button btn_Merge;//复原按钮

    //遍历数组中的对象
    private void Awake()
    {
        //给数组赋值
        machine = new GameObject[transform.childCount];
        //给向量赋值
        moveDir = new Vector3[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            machine[i] = transform.GetChild(i).gameObject;
            moveDir[i] = (target.transform.position - machine[i].transform.position).normalized;
        }
    }
    private void Start()
    {
        //监听拆卸时间方法
        btn_Split.onClick.AddListener(SplitMchineTest);
        //监听复原时间方法
        btn_Merge.onClick.AddListener(MergeMchineTest);
    }
    //拆卸方法
    public void SplitMchineTest()
    {
        if (isSplit) return;
        else
        {
            for (int i = 0; i < machine.Length; i++)
            {
                MechineAni(machine[i], -moveDir[i]);
            }
            isSplit = true;
        }
        
    }
    //复原方法
    public void MergeMchineTest()
    {
        if (!isSplit) return;
        for (int i = 0; i < machine.Length; i++)
        {
            MechineAni(machine[i], moveDir[i]);
        }
        isSplit = false;
    }

    //机械拆卸
    public void MechineAni(GameObject obj,Vector3 vec)
    {
        vec.x = vec.x * 3;
        vec.y = vec.y * 3;
        vec.z = vec.z * 3;
        iTween.MoveAdd(obj, iTween.Hash("amount", vec,
                                       "time", 0.3f,
                                       "easetype", iTween.EaseType.easeOutQuad,
                                       "space",Space.World,
                                       "looptype", iTween.LoopType.none));
    }
}
