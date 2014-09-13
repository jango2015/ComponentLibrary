using System;

namespace NetFocus.Components.CMPServices
{

	public class CommandMappingNotFoundException : Exception
	{
		public CommandMappingNotFoundException(string containerId, string commandName) : base("�־������� " + containerId + " ����� " + commandName + " û���ҵ���")
		{
		
		}
	}

	public class CommandMappingWithoutContainerMappingIdNotFoundException : Exception
	{
		public CommandMappingWithoutContainerMappingIdNotFoundException(string commandName) : base("��� " + commandName + " û���ҵ���")
		{
		
		}
	}
}
