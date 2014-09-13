using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace NetFocus.Components.SearchComponent
{
	/// <summary>
	/// һ���̳���DataTable�������,���ڴ�ŵ�ǰ���õ�����ԭ����������Ϣ
	/// </summary>
	[Serializable]
	public class AtomConditionDataTable : DataTable
	{
		public AtomConditionDataTable()
		{
			this.Columns.Add("FieldFullName",typeof(string));
			this.Columns.Add("FieldDataType",typeof(string));
			this.Columns.Add("InputControlType",typeof(string));
			this.Columns.Add("ConditionName",typeof(string));
			this.Columns.Add("InitialValue",typeof(string));
			this.Columns.Add("Operator",typeof(string));
			this.Columns.Add("ChineseName",typeof(string));
			this.PrimaryKey = new DataColumn[]{this.Columns[3]};
		}
		public AtomConditionDataTable(SerializationInfo info, StreamingContext context) : base(info,context)
		{
			
		}
	}
}
