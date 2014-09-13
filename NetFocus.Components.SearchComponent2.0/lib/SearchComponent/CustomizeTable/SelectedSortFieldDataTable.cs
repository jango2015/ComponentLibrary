using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace NetFocus.Components.SearchComponent
{
	/// <summary>
	/// һ���̳���DataTable�������,���ڴ�ŵ�ǰѡ���һЩ�����ֶε���Ϣ
	/// </summary>
	[Serializable]
	public class SelectedSortFieldDataTable : DataTable
	{
		public SelectedSortFieldDataTable()
		{
			this.Columns.Add("FieldFullName",typeof(string));
			this.Columns.Add("SortType",typeof(string));
			this.PrimaryKey = new DataColumn[]{this.Columns[0]};
		}
		public SelectedSortFieldDataTable(SerializationInfo info, StreamingContext context) : base(info,context)
		{
			
		}
	}
}
