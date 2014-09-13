
using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;


namespace NetFocus.Components.CMPServices
{
	/// <summary>
	/// ��һ���洢���̵�ӳ����
	/// </summary>
	public class CommandMapping
	{
		private string commandName;                  //�洢���̵�����
		private ArrayList commandParameters;         //�洢���̵Ĳ�������
		private string returnValueType;              //�洢���̵ķ���ֵ����

		private void ConstructCommandMapping( string initCommandName, ArrayList initCommandParameters )
		{
			commandName = initCommandName;
			commandParameters = initCommandParameters;
		}


		public CommandMapping()
		{
			ConstructCommandMapping("Not Set", new ArrayList());
		}

		
		public CommandMapping( string initCommandName )
		{
			ConstructCommandMapping(initCommandName, new ArrayList());
		}

		
		public CommandMapping( string initCommandName, ArrayList initCommandParameters )
		{
			ConstructCommandMapping( initCommandName, initCommandParameters );
		}

		
		/// <summary>
		/// �洢���̵�����
		/// </summary>
		public string CommandName
		{
			get 
			{
				return commandName;
			}
			set 
			{
				commandName = value;
			}
		}

		
		/// <summary>
		/// �洢���̵Ĳ�������
		/// </summary>
		public ArrayList Parameters
		{
			get 
			{
				return commandParameters;
			}
			set 
			{
				commandParameters = value;
			}
		}
		
		
		/// <summary>
		/// �洢���̵ķ���ֵ����
		/// </summary>
		public string ReturnValueType
		{
			get
			{
				return returnValueType;
			}
			set
			{
				returnValueType = value;
			}
		}

		
		/// <summary>
		/// ���һ���洢���̲���
		/// </summary>
		/// <param name="newParameter"></param>
		public void AddParameter( CommandParameter newParameter )
		{
			commandParameters.Add( newParameter );
		}

	}
}
