
using System;
using System.Xml.Serialization;
using System.Data;
using System.Reflection;

namespace NetFocus.Components.CMPServices
{
	/// <summary>
	/// ��һ���洢���̲�����ӳ����
	/// </summary>
	public class CommandParameter
	{
		private string classMember;                           //�־��Զ������������
		private string parameterName;                         //��������
		private string dbTypeHint;                            //��������
		private ParameterDirection parameterDirection;        //��������

		private void ConstructCommandParameter(string classMember, string initParameterName,string initDbTypeHint,string initParameterDirection)
		{
			this.classMember = classMember;
			this.parameterName = initParameterName;
			this.dbTypeHint = initDbTypeHint;
			this.ParamDirection = initParameterDirection;
		}

		
		public CommandParameter()//һ�����췽���������κβ���
		{
			ConstructCommandParameter("Not Set", "Not Set", "Not Set", "ReturnValue");
		}

		
		public CommandParameter(string classMember, string initParameterName,string initDbTypeHint,string initParameterDirection)
		{
			ConstructCommandParameter(classMember,initParameterName,initDbTypeHint,initParameterDirection);
		}

		/// <summary>
		/// �־��Զ������������
		/// </summary>
		public string ClassMember
		{
			get 
			{
				return classMember;
			}
			set 
			{
				classMember = value;
			}
		}
		
		/// <summary>
		/// ��������
		/// </summary>
		public string ParameterName
		{
			get 
			{
				return parameterName;
			}
			set 
			{
				parameterName = value;
			}
		}

		/// <summary>
		/// ��������
		/// </summary>
		public string DbTypeHint
		{
			get 
			{
				return dbTypeHint;
			}
			set 
			{
				dbTypeHint = value;
			}
		}
		
		/// <summary>
		/// ��������,�ַ�����ʾ
		/// </summary>
		public string ParamDirection
		{
			get 
			{
				return parameterDirection.ToString();
			}
			set 
			{
				if (value == "Input")
					parameterDirection = ParameterDirection.Input;
				else if (value == "InputOutput")
					parameterDirection = ParameterDirection.InputOutput;
				else if (value == "Output" )
					parameterDirection = ParameterDirection.Output;
				else
					parameterDirection = ParameterDirection.ReturnValue;
			}
		}

		/// <summary>
		/// ����ʵ�ʷ���
		/// </summary>
		public ParameterDirection RealParameterDirection
		{
			get 
			{
				return parameterDirection;
			}
		}


	}
}

