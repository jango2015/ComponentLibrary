using System;

namespace NetFocus.Components.CMPServices
{

	public class ContainerMappingNotFoundException : Exception
	{
		public ContainerMappingNotFoundException(string containerMappingId) : base("�־������� " + containerMappingId + " δ�ҵ���")
			
		{
		
		}
	}
}
