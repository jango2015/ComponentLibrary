using System;

namespace NetFocus.Components.CMPServices
{
	public class DbTypeNotFoundException : Exception
	{
		public DbTypeNotFoundException(string typeName) : base("�������� " + typeName + " û���ҵ�������ӳ���ļ���")
		{
		
		}
	}
}
