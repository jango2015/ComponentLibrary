using System;

namespace NetFocus.Components.CMPServices
{
	public class PropertyNotFoundException : Exception
	{
		public PropertyNotFoundException(string propertyName) : base("ӳ���ļ��ж�������Գ�Ա " + propertyName + " �ڳ־������в����ڣ�") 
		{
			
		}
	}
}
