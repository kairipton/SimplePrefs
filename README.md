# SimplePrefs
## 기능
* PlayerPrefs를 대체합니다.
* 저장하거나 불러올 데이터를 용도별로 카테고리화 하여 사용합니다.
* 더이상 골치아픈 string key를 몰라도 됩니다.

## 사용법
간단한 샘플(Assets/Scenes/SampleScene.unity)이 준비되어 있으며,
플레이 모드에서 테스트를 진행해주시고, 테스트의 설명은 Scene에 있는 GameObject를 참고 해주세요.  
테스트 코드는 Assets/Scripts/Sample/Test.cs 에 작성 되어 있습니다.

```C#
// 저장, 불러올 데이터 작성
namespace SPrefs
{
  public class SomeData : Internal.SPrefsBase<SampleData>
  {
    public int level;
    public string desc;
    public bool isNice;
    public float progress;
  }
}



public class PrefsTest : MonoBehaviour
{
  void Start()
  {
    // 불러오기
    var data = SPrefs.SomeData.Load();
    
    // 변경
    data.level = 123;
    data.desc = "가나다라마법사";
    data.isNice = true;
    data.progress = 0.123f;
    
    // 저장
    data.Save();
  }
}
```

## 주의사항
* UnityEngine.JsonUtility를 사용합니다. 때문에 다른 Json 플러그인의 의존성은 없으나,  
JsonUtility에서 지원하지 않는 기능은 지원하지 않습니다
* 새로운 데이터 작성시 반드시 지킬 필요는 없으나 가능하면 SPrefs 네임스페이스에 넣어주세요.  
IDE 자동완성 기능을 이용해 현재 사용가능한 데이터를 한눈에 보기 위함입니다.
