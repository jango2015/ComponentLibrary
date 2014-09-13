
using System;

namespace NetFocus.Components.CMPServices
{
	/// <summary>
	/// ���г־��������Ļ���
	/// </summary>
	public class StdPersistenceContainer
	{
		/// <summary>
		/// ͨ��һ���洢���̵����ƾͿ��Խ������ݷ��ʣ����ַ�ʽ��ǰ�������еĴ洢���̵����ƶ����ظ����÷�����Ҫ����ִ�иò�������Ҫ�κ����������Ҳ����Ҫ�κη�����Ϣ��
		/// </summary>
		/// <param name="commandName">�洢���̵�����</param>
		public virtual void Execute(string commandName)
		{

		}

		/// <summary>
		/// ͨ��һ���洢���̵����ƺ�һ���־��Զ���������ݷ��ʣ����ַ�ʽ��ǰ�������еĴ洢���̵����ƶ����ظ���
		/// </summary>
		/// <param name="commandName">�洢���̵�����</param>
		/// <param name="currentObject">һ���־��Զ��󣬲���Ϊ��</param>
		public virtual void Execute(string commandName, PersistableObject currentObject)
		{

		}

		/// <summary>
		/// �ṩһ���־����������ƺ͸������е�һ���洢���̵����ƽ������ݷ��ʣ��÷�����Ҫ����ִ�иò�������Ҫ�κ����������Ҳ����Ҫ�κη�����Ϣ��
		/// </summary>
		/// <param name="containerMappingId">�־���������ID</param>
		/// <param name="commandName">�洢���̵�����</param>
		public virtual void Execute(string containerMappingId, string commandName)
		{

		}

		/// <summary>
		/// �ṩһ���־����������ƺ͸������е�һ���洢�����Լ�һ���־��Զ���������ݷ��ʣ���������������Ϊ�ա�
		/// </summary>
		/// <param name="containerMappingId">�־�������ID</param>
		/// <param name="commandName">�洢���̵�����</param>
		/// <param name="currentObject">һ���־��Զ���</param>
		public virtual void Execute(string containerMappingId, string commandName, PersistableObject currentObject)
		{

		}

	}
}
