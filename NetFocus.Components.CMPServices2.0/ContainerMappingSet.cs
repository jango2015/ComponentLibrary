using System;
using System.Xml;
using System.Xml.Serialization; 
using System.Reflection;
using System.Collections;

namespace NetFocus.Components.CMPServices
{
	/// <summary>
	/// �������ڴ洢���е�����ӳ����Ķ���
	/// </summary>
	public class ContainerMappingSet
	{
		private Hashtable containerMappings;

		public ContainerMappingSet()
		{
			containerMappings = new Hashtable();
		}

		/// <summary>
		/// �ṩ����������ļ�ֵ�Է���
		/// </summary>
		public ContainerMapping this[string key]
		{
			get 
			{
				if(containerMappings.ContainsKey(key))
				{
					return containerMappings[key] as ContainerMapping;
				}
				else
				{
					return null;
				}
			}
			set 
			{
				if (containerMappings.ContainsKey(key))
				{
					throw new ContainerMappingReduplicateException(key);
				}
				containerMappings.Add(key, value);
			}
		}

		/// <summary>
		/// �ṩ�������������������
		/// </summary>
		public ContainerMapping this[int index]
		{
			get 
			{
				IDictionaryEnumerator enumerator = containerMappings.GetEnumerator();
				int i = 0;
				while(enumerator.MoveNext())
				{
					if(i == index)
					{
						return enumerator.Value as ContainerMapping;
					}
					i++;
				}
				return null;
			}

		}

		
		/// <summary>
		/// ����������ĸ���
		/// </summary>
		public int Count
		{
			get 
			{
				return containerMappings.Count;
			}
		}

	}
}

