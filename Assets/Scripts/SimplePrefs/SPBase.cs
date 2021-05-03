using UnityEngine;

namespace SPrefs
{
	namespace Internal
	{
		public interface ISPrefs
		{
			public void Reset();
			public void Save();
		}

		public class SPrefsBase<T> : ISPrefs where T : SPrefsBase<T>, new()
		{
			/// <summary>
			/// PlayerPrefs로 저장할 키.
			/// Prefs.XXXXX (네임스페이스.클래스명)
			/// </summary>
			static string	key			= string.Format( "{0}.{1}", typeof(T).Namespace, typeof(T).Name );
			static bool		IsKeyExist	=> PlayerPrefs.HasKey( key );

			/// <summary>
			/// 현재 저장값을 문자열로 리턴
			/// </summary>
			public override string ToString()
			{
				CheckKeyExist();
				return JsonUtility.ToJson( this );
			}

			/// <summary>
			/// 저장된 값을 불러옴.
			/// </summary>
			public static T Load()
			{
				CheckKeyExist();
				string json = PlayerPrefs.GetString( key );
				return JsonUtility.FromJson<T>( json );
			}

			/// <summary>
			/// 현재 값을 저장함.
			/// </summary>
			/// <param name="data">저장할 대상</param>
			public static void Save(ISPrefs data)
			{
				CheckKeyExist();
				var prefsData = data as SPrefsBase<T>;
				string json = prefsData.ToString();
				PlayerPrefs.SetString( key, json );
			}

			/// <summary>
			/// 현재 값을 저장함.
			/// </summary>
			public void Save()
			{
				CheckKeyExist();
				string json = ToString();
				PlayerPrefs.SetString( key, json );
			}
	
			/// <summary>
			/// 현재 저장된 값을 기본값으로 되돌려 저장함.
			/// 로컬에만 기본값으로 저장 하고, 이 객체의 값이 바뀌는건 아님.
			/// </summary>
			public void Reset()
			{
				_Reset();
			}

			static void _Reset()
			{
				var newData = new T();
				PlayerPrefs.SetString( key, JsonUtility.ToJson( newData ) );
			}

			/// <summary>
			/// 키가 있는지 검사 후 없으면 기본값으로 리셋
			/// </summary>
			static void CheckKeyExist()
			{
				if( IsKeyExist == false ) _Reset();
			}
		}
	}
}