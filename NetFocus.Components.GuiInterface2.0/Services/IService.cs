
using System;

namespace NetFocus.Components.GuiInterface.Services
{
	/// <summary>
	/// ����һ�����з������ʵ�ֵĽӿ�.
	/// </summary>
	public interface IService
	{
		/// <summary>
		/// ���ڳ�ʼ��һ������.
		/// </summary>
		void InitializeService();
		
		/// <summary>
		/// ����ж��һ������.
		/// </summary>
		void UnloadService();
		
		//���������¼�,�Ա�ĳЩ�ض��ķ���Ϊ����Ӵ������.
		event EventHandler Initialize;
		event EventHandler Unload;
	}
}
