using System;

namespace NetFocus.Components.CMPServices
{

	public class ContainerMappingReduplicateException : Exception
	{
		public ContainerMappingReduplicateException(string containerMappingId) : base("�Ѵ���һ����Ϊ " + containerMappingId + " �ĳ־���������")
		{
		
		}
	}
}
