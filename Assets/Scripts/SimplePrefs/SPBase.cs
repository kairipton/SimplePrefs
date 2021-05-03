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
			/// PlayerPrefs�� ������ Ű.
			/// Prefs.XXXXX (���ӽ����̽�.Ŭ������)
			/// </summary>
			static string	key			= string.Format( "{0}.{1}", typeof(T).Namespace, typeof(T).Name );
			static bool		IsKeyExist	=> PlayerPrefs.HasKey( key );

			/// <summary>
			/// ���� ���尪�� ���ڿ��� ����
			/// </summary>
			public override string ToString()
			{
				CheckKeyExist();
				return JsonUtility.ToJson( this );
			}

			/// <summary>
			/// ����� ���� �ҷ���.
			/// </summary>
			public static T Load()
			{
				CheckKeyExist();
				string json = PlayerPrefs.GetString( key );
				return JsonUtility.FromJson<T>( json );
			}

			/// <summary>
			/// ���� ���� ������.
			/// </summary>
			/// <param name="data">������ ���</param>
			public static void Save(ISPrefs data)
			{
				CheckKeyExist();
				var prefsData = data as SPrefsBase<T>;
				string json = prefsData.ToString();
				PlayerPrefs.SetString( key, json );
			}

			/// <summary>
			/// ���� ���� ������.
			/// </summary>
			public void Save()
			{
				CheckKeyExist();
				string json = ToString();
				PlayerPrefs.SetString( key, json );
			}
	
			/// <summary>
			/// ���� ����� ���� �⺻������ �ǵ��� ������.
			/// ���ÿ��� �⺻������ ���� �ϰ�, �� ��ü�� ���� �ٲ�°� �ƴ�.
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
			/// Ű�� �ִ��� �˻� �� ������ �⺻������ ����
			/// </summary>
			static void CheckKeyExist()
			{
				if( IsKeyExist == false ) _Reset();
			}
		}
	}
}