using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
	[TextArea( 5, 50 )]
	public string				sampleDesc;

	[Space]
	public int					_level;
	public string				_desc;
	public bool					_isAwsome;
	public float				_progress;
	
	[Space]
	public SPrefs.SampleData	sampleData;

	void Start() => Load();

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Alpha1 ) )
		{
			Load();	
		}

		else if( Input.GetKeyDown( KeyCode.Alpha2 ) )
		{
			var data = SPrefs.SampleData.Load();
			data.level = _level;
			data.desc = _desc;
			data.isAwsome = _isAwsome;
			data.progress = _progress;
			data.Save();
		}

		else if( Input.GetKeyDown( KeyCode.Alpha3 ) )
		{
			SPrefs.SampleData.Save( sampleData );
		}

		else if( Input.GetKeyDown( KeyCode.Escape ) )
		{
			// SPrefs.Util.Reset을 통해 선별적으로 초기화도 가능
			// SPrefs.Util.Reset( typeof(SampleData), typeof(BlaBlaData), .... )
			SPrefs.Util.ResetAll();
			Load();
		}
	}

	void Load()
	{
		sampleData = SPrefs.SampleData.Load();
		_level = sampleData.level;
		_desc = sampleData.desc;
		_isAwsome = sampleData.isAwsome;
		_progress = sampleData.progress;
	}
}