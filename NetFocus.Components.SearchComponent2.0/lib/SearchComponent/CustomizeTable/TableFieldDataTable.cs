using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace NetFocus.Components.SearchComponent
{
	/// <summary>
	/// һ���̳���DataTable�������,���ڴ��һЩ�ֶ���Ϣ
	/// </summary>
	[Serializable]
	public class TableFieldDataTable : DataTable
	{
		public TableFieldDataTable()
		{
			this.Columns.Add("FieldFullName",typeof(string));
			this.Columns.Add("FieldName",typeof(string));
			this.Columns.Add("DataType",typeof(string));
			this.Columns.Add("AliasName",typeof(string));
			this.Columns.Add("ChineseName",typeof(string));
			this.Columns.Add("OwnerTable",typeof(string));
			this.PrimaryKey = new DataColumn[]{this.Columns[0]};
		}
		public TableFieldDataTable(SerializationInfo info, StreamingContext context) : base(info,context)
		{
			
		}
		
	}
}
