
using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Reflection;

using NetFocus.Components.AddIns.Attributes;

namespace NetFocus.Components.AddIns.Conditions
{
	/// <summary>
	/// The condition builder builds a new condition
	/// </summary>
	public class ConditionBuilder
	{
		Assembly assembly;
		string className;
		StringCollection requiredAttributes = new StringCollection();
		
		/// <summary>
		/// This is a collection of all attributes which are required
		/// to construct this condition object.
		/// </summary>
		public StringCollection RequiredAttributes {
			get {
				return requiredAttributes;
			}
		}
		/// <summary>
		/// �ӵ�ǰ����������ͨ������õ����е����ԣ��ŵ�StringCollection������
		/// </summary>
		private void SetRequiredAttributes()
		{
			Type currentType = assembly.GetType(className);
			while (currentType != typeof(object)) 
			{
				FieldInfo[] fieldInfoArray = currentType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
				
				foreach (FieldInfo fieldInfo in fieldInfoArray) 
				{
					// process TaskAttribute attributes
					XmlMemberAttributeAttribute codonAttribute = (XmlMemberAttributeAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(XmlMemberAttributeAttribute));
					if (codonAttribute != null && codonAttribute.IsRequired) 
					{
						requiredAttributes.Add(codonAttribute.Name);
					}
				}
				currentType = currentType.BaseType;
			}
		}
		/// <summary>
		/// Initializes a new ConditionBuilder instance with beeing
		/// className the name of the condition class and assembly the
		/// assembly in which the class is defined.
		/// </summary>
		public ConditionBuilder(string className, Assembly assembly)
		{
			this.assembly  = assembly;
			this.className = className;
			
			SetRequiredAttributes();
		}
		
		/// <summary>
		/// Returns a newly build <code>ICondition</code> object.
		/// </summary>
		public ICondition BuildCondition(AddIn addIn)
		{
			//һ��AddIn��û�к�һ��ICondition����,���Դ���һ��IConditionʱ���Բ����ṩAddIn����
			ICondition condition = (ICondition)assembly.CreateInstance(className, true);
			
			return condition;
		}
	}
}
