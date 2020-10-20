using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QeustManager : MonoBehaviour
{
    Dictionary<int, string[]> QeustData;
    //걍 퀘스트 매니저에서 텍스트 가져와가지구 거기다 넣는거징..

    void Start()
    {
        QeustData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        QeustData.Add(0, new string[] { "첫번째 미니게임 - 시계 보기", "토끼의 시계가 고장이 났어요.\n 앨리스의 시계를 보고 토끼에게 시간을 알려 주세요!", "시계에서 짧은 바늘은 '시'를 나타내고 긴 바늘은 '분'을 나타내요.\n 긴 바늘이 12를 가리킬 때 몇 시를 나타내는데 짧은 바늘이 8을 가리킬 때 8시라고 읽어요.\n 긴 바늘이 6일 때 몇 시 30분을 나타내는데 시를 읽을 때는 짧은 바늘이 방금 지나온 숫자를 읽어야 해요."});
        QeustData.Add(1, new string[] { "두번째 미니게임 - 크기 비교", "토끼를 쫓아가려면 더 넓은 문을 지나가야 해요. \n 앨리스는 어떤 문으로 지나가야 할까요?", "물건을 서로 겹쳐 보았을 때, 남는 부분이 많은 쪽이 더 넓습니다." });
    }

    public string GetQeust(int qeustNum, int qeustIndex)
    {
        return QeustData[qeustNum][qeustIndex];
    }
}
