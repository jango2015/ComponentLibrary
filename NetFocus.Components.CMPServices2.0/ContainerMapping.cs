using System;
using System.Xml;
using System.Xml.Serialization; 
using System.Reflection;
using System.Collections;


namespace NetFocus.Components.CMPServices
{
	/// <summary>
	/// �����洢���̼��ϵ�һ������ӳ����
	/// </summary>
	public class ContainerMapping  //��������һ��������ӳ��
	{
		private string containerMappingId;
		private Hashtable commandMappingList = new Hashtable();
		private string currentCommandName;

		/// <summary>
		/// ͨ��һ��ContainerMapping�ڵ�������һ�����������
		/// </summary>
		/// <param name="xmlNode"></param>
		public ContainerMapping(XmlNode xmlNode)
		{
			containerMappingId = xmlNode.Attributes.GetNamedItem("Id").Value;

			XmlNodeList commandMappingNodeList = xmlNode.SelectNodes("Command");
			
			foreach(XmlNode commandMappingNode in commandMappingNodeList)
			{
				string commandName = commandMappingNode.Attributes.GetNamedItem("CommandName").Value;
				if(commandMappingList.Contains(commandName))
				{
					throw new CommandMappingReduplicateException(containerMappingId,commandName);
				}
				commandMappingList[commandName] = CreateCommandMappingFromNode(commandName, commandMappingNode );
				
			}
			
		}

		
		private static CommandMapping CreateCommandMappingFromNode(string commandName, XmlNode cmdNode)
		{
			CommandMapping newCmdMap = new CommandMapping(commandName);

			CommandParameter newParam;
			XmlNodeList parameterList = cmdNode.SelectNodes("Parameter");

			foreach (XmlNode cmdParamNode in parameterList)
			{
				newParam = new CommandParameter();
				newParam.ClassMember = cmdParamNode.Attributes.GetNamedItem("ClassMember").Value;
				newParam.ParameterName = cmdParamNode.Attributes.GetNamedItem("ParameterName").Value;
				newParam.DbTypeHint = cmdParamNode.Attributes.GetNamedItem("DbTypeHint").Value;
				newParam.ParamDirection = cmdParamNode.Attributes.GetNamedItem("ParamDirection").Value;
				
				newCmdMap.AddParameter(newParam);
			}

			return newCmdMap;
		}

		
		/// <summary>
		/// ������ID
		/// </summary>
		public string ContainerMappingId
		{
			get 
			{
				return containerMappingId;
			}
			set 
			{
				containerMappingId = value;
			}
		}


		/// <summary>
		/// �洢���̼���
		/// </summary>
		public Hashtable CommandMappingList
		{
			get
			{
				return commandMappingList;
			}
			set
			{
				commandMappingList = value;
			}
		}
		
		
		/// <summary>
		/// ��ǰ�洢��������
		/// </summary>
		public string CurrentCommandName
		{
			get
			{
				return currentCommandName;
			}
			set
			{
				currentCommandName = value;
			}
		}


	}
}
