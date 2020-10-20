using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //대화 관리
    public TalkManager talkManager; //대화 매니저를 변수로 선언 후, 함수 사용
    public GameObject talkPanel; //토크 판넬을 가져온다.
    public Image portraitImg; //초상화
    public Text talkText; //전달할 내용 (인스펙터 창에서 꼭 채워주기)
    public Text nameText;
    public bool isAction; //판넬 상태 저장용 변수
    public int talkIndex;
    public int id;

    //퀘스트 관리
    public QeustManager qeustManger;
    public GameObject qeustPanel;
    public Text qeustText;
    public Text qeustTitle;
    public int qeustCount;
    //퀘스트 힌트관리
    public GameObject hintPanel;
    public Text hintText;

    //퀘스트1 관련
    public InputField qeustOneHour;
    public InputField qeustOneMin;

    //퀘스트2 관련
    public bool qeustTwoCheck;

    //실패/성공 팝업
    public GameObject clearPanel;
    public Text clearText;
    public GameObject failPanel;
    public Text failText;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Action()
    {
        isAction = true;
        Talk(id);
        talkPanel.SetActive(isAction);
    }

    void Talk(int talkId)
    {
        string talkData = talkManager.GetTalk(talkId, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            id++;
            Qeust(qeustCount);
            return;
        }

        talkText.text = talkData.Split(':')[0]; //문자를 기준으로 string을 잘라 배열을 만들기 때문에 [0]이 대화 내용이다.
        portraitImg.sprite = talkManager.GetPortrait(int.Parse(talkData.Split(':')[1]));
        portraitImg.color = new Color(1, 1, 1, 1);

        if (int.Parse(talkData.Split(':')[1]) == 1)
        {
            nameText.text = "앨리스";
        }
        else if (int.Parse(talkData.Split(':')[1]) == 0)
        {
            nameText.text = "토끼";
        }

        isAction = true;
        talkIndex++;
    }

    void Qeust(int qCount)
    {
        qeustPanel.SetActive(true);
        //퀘스트 카운트에 맞는 퀘스트 내용을 뿌려주면 된다.
        qeustTitle.text = qeustManger.GetQeust(qCount, 0);
        qeustText.text = qeustManger.GetQeust(qCount, 1);
        qeustCount++;
    }

    public void QeustOneCheck()
    {
        //버튼을 누르면 쟤네를 비교하고, 반환값으로 bool을 받아서 씬을 넘기거나, 실패 대사를 띄우면서 되돌리거나 해야함.
        //답을 입력하지 않았을 시, 답을 입력하라고 해야하니까 null이 아닌지 검사해봐야한다.
        //그러면 일단..버튼을 누르는 순간의 값을 받아와서 저장하고, 얘네가 널이 아닌지 검사해보고! 비교를 해야겠군용
        if(qeustOneHour.text == "2" && qeustOneMin.text == "30")
        {
            clearText.text = qeustOneHour.text + "시 " + qeustOneMin.text + "분!" + "\n정답입니다!";
            clearPanel.SetActive(true);
            //정답 팝업 띄우고 확인 버튼 누르면 씬매니저에서 관리하는걸로 ㅇㅇ
            return;
        }
        failText.text = qeustOneHour.text + "시 " + qeustOneMin.text + "분?" + "\n다시 한 번 생각해 보자!";
        failPanel.SetActive(true);
    }

    public void showHint()
    {
        hintPanel.SetActive(true);
        hintText.text = qeustManger.GetQeust(qeustCount, 2);
    }

    public void hideHint()
    {
        hintPanel.SetActive(false);
    }

    public void QeustTwoCheck()
    {
        if(qeustTwoCheck == true)
        {
            clearText.text = "좋아! 이 문으로 나가면 토끼를 만날 수 있겠지?";
            clearPanel.SetActive(true);
            return;
        }
        clearText.text = "여기로는\n지나갈 수 없겠어..\n다시 생각해 보자!";
        failPanel.SetActive(true);
    }
}
