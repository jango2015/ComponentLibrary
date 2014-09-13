
using System;
using System.Data;
using System.Xml;
using System.Xml.Serialization; 
using System.Text;

namespace NetFocus.Components.CMPServices
{
	/// <summary>
	/// ���г־��Զ���Ļ���
	/// </summary>
	public class PersistableObject
	{
		private DataSet internalData = new DataSet();
		private object returnValue = 0;
		
		/// <summary>
		/// ��ʾ�����Ƿ��ܳ־û�
		/// </summary>
		/// <returns></returns>
		public bool CanPersist()
		{
			return true;
		}

		
		public string ToXmlString()  //���л��ö���
		{
			try 
			{
				Type objType = this.GetType();
				StringBuilder sb = new StringBuilder();
				System.IO.StringWriter sw = new System.IO.StringWriter( sb );
				XmlSerializer xs = new XmlSerializer( objType );
				xs.Serialize( sw, this );
				return sw.GetStringBuilder().ToString();
			}
			catch 
			{
				return "Serialization Failure";
			}
		}
		
		
		/// <summary>
		/// ��ʾ�ɸó־��Զ�������ɵ�һ�����ݼ�
		/// </summary>
		public DataSet ResultSet
		{
			get 
			{
				return internalData;
			}
			set 
			{
				internalData = value;
			}
		}

		/// <summary>
		/// ���ڱ�ʾ�洢���̵ķ���ֵ
		/// </summary>
		public object ReturnValue
		{
			get 
			{
				return returnValue;
			}
			set 
			{
				returnValue = value;
			}
		}

	}
}
