
using System;
using System.Xml;

using NetFocus.Components.AddIns.Exceptions;

namespace NetFocus.Components.AddIns.Conditions
{
	/// <summary>
	/// Creates a new <code>ICondition</code> object.
	/// </summary>
	public class ConditionFactory
	{
		ConditionBuilderCollection conditionBuilderCollection = new ConditionBuilderCollection();
		
		/// <summary>
		/// Add a new condition builder to the collection.
		/// </summary>
		/// <exception cref="DuplicateConditionException">
		/// When there is already a condition which the same required attributes
		/// in this collection.
		/// </exception>
		/// <exception cref="ConditionWithoutRequiredAttributesException">
		/// When the given condition does not have required attributes.
		/// </exception>
		public void AddConditionBuilder(ConditionBuilder builder) 
		{
			foreach (ConditionBuilder b in conditionBuilderCollection) 
			{
				if (b.RequiredAttributes.Equals(builder.RequiredAttributes)) 
				{
					throw new DuplicateConditionException(builder.RequiredAttributes);
				}
			}
			if (builder.RequiredAttributes.Count == 0) 
			{
				throw new ConditionWithoutRequiredAttributesException();
			}
			conditionBuilderCollection.AddConditionBuilder(builder);
		}
	
		
		/// <summary>
		/// Creates a new <code>ICondition</code> object using <code>conditionNode</code>
		/// as a mask of which class to take for creation.
		/// </summary>
		public ICondition CreateCondition(AddIn addIn, XmlNode conditionNode)
		{
			//ͨ��һ��XmlNode���õ�һ������������,���,������õ������Ӵ������ķ�ʽ��һ��
			//��ôΪʲô��������ӵķ�ʽ�������������������õ�һ��������������?
			//ԭ������Ϊ���������������������һ���򵥵�����������,Ҫ����builder.RequiredAttributes������,
			//���Բ��ܼ򵥵�ʹ��һ��Hashtable���������������
			ConditionBuilder builder = conditionBuilderCollection.GetConditionBuilder(conditionNode);
			
			if (builder == null) {
				throw new ConditionNotFoundException("unknown condition found");
			}
			
			return builder.BuildCondition(addIn);
		}
		
	}
}
