using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplitMerge : MonoBehaviour
{
    //���л�һ������ ����������������gameobject ��Ż�е���
    [SerializeField] GameObject[] machine;

    //target Ŀ���
    [SerializeField] GameObject target;

    //�������
    [SerializeField] Vector3[] moveDir;

    //���ڼ�¼��ж�Ƿ���ɵı���
    bool isSplit = false;

    

    //��ť
    public Button btn_Split;//��ж��ť
    public Button btn_Merge;//��ԭ��ť

    //���������еĶ���
    private void Awake()
    {
        //�����鸳ֵ
        machine = new GameObject[transform.childCount];
        //��������ֵ
        moveDir = new Vector3[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            machine[i] = transform.GetChild(i).gameObject;
            moveDir[i] = (target.transform.position - machine[i].transform.position).normalized;
        }
    }
    private void Start()
    {
        //������жʱ�䷽��
        btn_Split.onClick.AddListener(SplitMchineTest);
        //������ԭʱ�䷽��
        btn_Merge.onClick.AddListener(MergeMchineTest);
    }
    //��ж����
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
    //��ԭ����
    public void MergeMchineTest()
    {
        if (!isSplit) return;
        for (int i = 0; i < machine.Length; i++)
        {
            MechineAni(machine[i], moveDir[i]);
        }
        isSplit = false;
    }

    //��е��ж
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
