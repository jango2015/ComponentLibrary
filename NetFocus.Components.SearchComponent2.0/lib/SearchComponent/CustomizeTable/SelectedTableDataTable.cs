using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace NetFocus.Components.SearchComponent
{
	/// <summary>
	/// һ���̳���DataTable�������,���ڴ�ŵ�ǰѡ������еı����Ϣ
	/// </summary>
	[Serializable]
	public class SelectedTableDataTable : DataTable
	{
		public SelectedTableDataTable()
		{
			this.Columns.Add("TableName",typeof(string));
			this.Columns.Add("AliasName",typeof(string));
			this.Columns.Add("ChineseName",typeof(string));
			this.PrimaryKey = new DataColumn[]{this.Columns[0]};
		}

		public SelectedTableDataTable(SerializationInfo info, StreamingContext context) : base(info,context)
		{
			
		}
		
	}
}
