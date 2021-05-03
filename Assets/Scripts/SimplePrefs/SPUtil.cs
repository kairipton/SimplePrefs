using System;
using System.Reflection;
using System.Linq;

namespace SPrefs
{
	public static class Util
	{
		/// <summary>
		/// 실제 구현된 모든 클래스
		/// </summary>
		static Type[] prefsTypes = Assembly.GetAssembly( typeof(Internal.ISPrefs) )
				.GetTypes()
				.Where( t=> t.GetInterface( typeof(Internal.ISPrefs).Name ) != null && t.IsGenericType == false )
				.ToArray();

		/// <summary>
		/// 모든 Prefs 리셋
		/// </summary>
		public static void ResetAll()
		{
			// 기본 생성자를 호출하고 Reset 호출
			Type[] ctorArgs = new Type[0];
			for(int i=0; i<prefsTypes.Length; i++)
			{
				var defaultCtor = prefsTypes[i].GetConstructor( ctorArgs );
				var o = defaultCtor.Invoke( null );
				var m = o.GetType().GetMethod( "Reset" );
				m.Invoke( o, null );
			}
		}

		/// <summary>
		/// 특정 Prefs만 리셋
		/// </summary>
		public static void Reset(params Type[] resetTargets)
		{
			// 기본 생성자를 호출하고 Reset 호출
			Type[] ctorArgs = new Type[0];
			for(int i=0; i<prefsTypes.Length; i++)
			{
				if( resetTargets.Contains( prefsTypes[i] ) == false ) continue;

				var defaultCtor = prefsTypes[i].GetConstructor( ctorArgs );
				var o = defaultCtor.Invoke( null );
				var m = o.GetType().GetMethod( "Reset" );
				m.Invoke( o, null );
			}
		}
	}
}