using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace NetFocus.Components.SearchComponent
{
	/// <summary>
	/// һ���̳���DataTable�������,���ڴ�ŵ�ǰ���õĺͱ��ϵ��ص�һЩ�����ֶ���Ϣ
	/// </summary>
	[Serializable]
	public class RelationFieldDataTable : DataTable
	{
		public RelationFieldDataTable()
		{
			this.Columns.Add("Table1",typeof(string));
			this.Columns.Add("Table2",typeof(string));
			this.Columns.Add("AliasTable1",typeof(string));
			this.Columns.Add("AliasTable2",typeof(string));
			this.Columns.Add("Field1",typeof(string));
			this.Columns.Add("Field2",typeof(string));
		}

		public RelationFieldDataTable(SerializationInfo info, StreamingContext context) : base(info,context)
		{
			
		}
		
	}
}
