using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    public GameManager gameManager;

    //여기서 게임오브젝트 접근해가지구 숫자 조절해도 될듯.. 카운트나 id같은겅ㅇㅇ
    //씬이 바뀔때는 상관없는데, 챕터 바뀔때마다는 꼭 한번씩 id, qeustCount초기화해줘야함. 메인화면에서 들어가는 경우도 있기 때문에.
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ChangeChapterOne()
    {
        SceneManager.LoadScene("chap1.Scene_1");
    }
    public void ChapOneFirstMiniGame()
    {
        SceneManager.LoadScene("chap1.Scene_2");
    }
    public void ChangeChapterOneScene3()
    {
        SceneManager.LoadScene("chap1.Scene_3");
    }
    public void ChapOneSecondMiniGame()
    {
        SceneManager.LoadScene("chap1.Scene_4");
    }
    public void ChapTwoSceneOne()
    {
        SceneManager.LoadScene("chap2.Scene_1");
        DataController.Instance.gameData.chapter1Clear = true;
        DataController.Instance.SaveGameData();
    }
    public void ChapTwoSceneTwo()
    {
        if (DataController.Instance.gameData.chapter1Clear == true)
            SceneManager.LoadScene("chap2.Scene_2");
        else
            Debug.Log("챕터1을 먼저 클리어해야 합니다.");
    }
    public void ChapThreeSceneTwo()
    {
        //if (DataController.Instance.gameData.chapter2Clear == true)
            //SceneManager.LoadScene("chap2.Scene_2");
        //else
        if(DataController.Instance.gameData.chapter2Clear == false)
            Debug.Log("챕터2를 먼저 클리어해야 합니다.");
    }
}
