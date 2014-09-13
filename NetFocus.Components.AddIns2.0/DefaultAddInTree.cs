
using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Xml;

using NetFocus.Components.AddIns.Conditions;
using NetFocus.Components.AddIns.Codons;
using NetFocus.Components.AddIns.Exceptions;
using NetFocus.Components.AddIns.Attributes;

namespace NetFocus.Components.AddIns
{
	/// <summary>
	/// Default implementation for the <see cref="IAddInTree"/> interface.
	/// </summary>
	public class DefaultAddInTree : IAddInTree
	{
		ConditionFactory conditionFactory = new ConditionFactory();
		CodonFactory    codonFactory    = new CodonFactory();
		AddInCollection addIns = new AddInCollection();
		
		DefaultAddInTreeNode  root = new DefaultAddInTreeNode();
		Hashtable registeredAssemblies = new Hashtable();
		
				
		public ConditionFactory ConditionFactory {
			get {
				return conditionFactory;
			}
		}


		public CodonFactory CodonFactory {
			get {
				return codonFactory;
			}
		}

		
		public AddInCollection AddIns {
			get {
				return addIns;
			}
		}
		

		internal DefaultAddInTree()
		{
			// load codons and conditions from the current assembly.
			// that is to say,load the core assembly's self codons and conditions
			LoadCodonsAndConditions(Assembly.GetExecutingAssembly());
		}
		
		
		private DefaultAddInTreeNode CreateTreeNode(DefaultAddInTreeNode localRoot, string path)
		{
			if (path == null || path.Length == 0) 
			{
				return localRoot;
			}
			string[] splittedPath = path.Split(new char[] {'/'});
			DefaultAddInTreeNode curNode = localRoot;
			int      i = 0;
			
			while (i < splittedPath.Length) 
			{
				DefaultAddInTreeNode nextNode = (DefaultAddInTreeNode)curNode.ChildNodes[splittedPath[i]];
				if (nextNode == null) 
				{
					curNode.ChildNodes[splittedPath[i]] = nextNode = new DefaultAddInTreeNode();
				}
				curNode = nextNode;
				++i;
			}
			
			return curNode;
		}
		

		private void AddExtensions(AddIn.Extension extension)
		{
			DefaultAddInTreeNode localRoot = CreateTreeNode(root, extension.Path);
			
			foreach (ICodon codon in extension.CodonCollection) {
				DefaultAddInTreeNode treeNode = CreateTreeNode(localRoot, codon.ID);
				if (treeNode.Codon != null) {
					throw new DuplicateCodonException(codon.ID);
				}
				treeNode.Codon              = codon;
				treeNode.ConditionCollection = (ConditionCollection)extension.Conditions[codon.ID];
			}
		}
		

		public void InsertAddIn(AddIn addIn)
		{
			addIns.Add(addIn);
			foreach (AddIn.Extension extension in addIn.Extensions) {
				AddExtensions(extension);
			}
		}
		

		public void RemoveAddIn(AddIn addIn)
		{ 
			// TODO : Implement the RemoveAddInMethod
			throw new ApplicationException("Implement ME!");
		}
		

		public IAddInTreeNode GetTreeNode(string path)
		{
			if (path == null || path.Length == 0) {
				return root;
			}
			string[] splittedPath = path.Split(new char[] {'/'});
			DefaultAddInTreeNode curTreeNode = root;
			int i = 0;
			
			while (i < splittedPath.Length) {
				DefaultAddInTreeNode nextTreeNode = (DefaultAddInTreeNode)curTreeNode.ChildNodes[splittedPath[i]];
				if (nextTreeNode == null) {
					throw new TreePathNotFoundException(path);
				}
				curTreeNode = nextTreeNode;
				++i;
			}
			
			return curTreeNode;
		}
		
		
		public Assembly LoadAssemblyFromFile(string fileName)
		{
			if(fileName.Trim() == ""){
				return null;
			}
			//�ȴ�hashtable���в��Ҹó����Ƿ����
			Assembly assembly = registeredAssemblies[fileName] as Assembly;

			//���hashtable���в�����,��Ӹ��ļ����ظó���
			if (assembly == null) {
				if (File.Exists(fileName)) {
					assembly = Assembly.LoadFrom(fileName);
				}
				if (assembly == null) {
					assembly = Assembly.Load(fileName);
				}
				if (assembly == null) {
					assembly = Assembly.LoadWithPartialName(fileName);
				}
				registeredAssemblies[fileName] = assembly;
				LoadCodonsAndConditions(assembly);
			}
			
			return assembly;
		}

		/// <summary>
		/// This method does load all codons and conditions in the given assembly.
		/// It will create builders for them which could be used by the factories to
		/// create the codon and condition objects.
		/// </summary>
		private void LoadCodonsAndConditions(Assembly assembly)
		{
			if(assembly != null)
			{
				foreach(Type type in assembly.GetTypes()) 
				{
					if (!type.IsAbstract) 
					{
						if (type.IsSubclassOf(typeof(AbstractCodon)) && Attribute.GetCustomAttribute(type, typeof(CodonTypeAttribute)) != null) 
						{
							codonFactory.AddCodonBuilder(new CodonBuilder(type.FullName, assembly));
						} 
						else if (type.IsSubclassOf(typeof(AbstractCondition)) && Attribute.GetCustomAttribute(type, typeof(ConditionAttribute)) != null) 
						{
							conditionFactory.AddConditionBuilder(new ConditionBuilder(type.FullName, assembly));
						}
					}
				}
			}
		}
	}
}
