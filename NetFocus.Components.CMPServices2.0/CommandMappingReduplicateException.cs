using System;

namespace NetFocus.Components.CMPServices
{

	public class CommandMappingReduplicateException : Exception
	{
		public CommandMappingReduplicateException(string containerMappingId, string commandName) : base("�ڳ־��������� " + containerMappingId + " ���Ѿ�����һ����Ϊ " + commandName + " �����")
		{
		
		}
	}
}
