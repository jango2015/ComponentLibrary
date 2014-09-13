
using System;
using System.Collections;
using System.Xml.Schema;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Reflection;


namespace NetFocus.Components.TextEditor.Document
{
	//һ�������������ʾ���ԵĹ�����,�õ���singleton���ģʽ.
	public class HighlightingManager
	{
		ArrayList syntaxModeProviders = new ArrayList();
		static HighlightingManager highlightingManager;
		//����һ����ϣ��,key��syntaxMode.Name,value��һ��IHighlightingStrategy����.
		Hashtable highlightingDefs = new Hashtable();
		//����һ����ϣ��,key���ļ�����չ���ַ���,value��һ��syntaxMode.Name���ַ���.
		Hashtable extensionsToName = new Hashtable();
		
		public Hashtable HighlightingDefinitions {
			get {
				return highlightingDefs;
			}
		}
		
		public static HighlightingManager Manager {
			get {
				return highlightingManager;		
			}
		}
		
		static HighlightingManager()
		{
			highlightingManager = new HighlightingManager();
		}
		
		private HighlightingManager()
		{
			CreateDefaultHighlightingStrategy();
		}
		//����һ��Ĭ�ϵ��﷨��Ŀ��ʾ����.
		void CreateDefaultHighlightingStrategy()
		{
			
			DefaultHighlightingStrategy defaultHighlightingStrategy = new DefaultHighlightingStrategy();
			defaultHighlightingStrategy.Extensions = new string[] {};
			defaultHighlightingStrategy.RuleSets.Add(new HighlightRuleSet());
			highlightingDefs["Default"] = defaultHighlightingStrategy;
		}

		
		public void AddSyntaxModeProvider(SyntaxModeProvider syntaxModeProvider)
		{
			foreach (SyntaxMode syntaxMode in syntaxModeProvider.SyntaxModes) 
			{
				DefaultHighlightingStrategy highlightingStrategy = ParseSyntaxMode(syntaxMode, syntaxModeProvider.GetSyntaxModeXmlTextReader(syntaxMode));
				highlightingStrategy.ResolveReferences();

				highlightingDefs[syntaxMode.Name] = highlightingStrategy;
				
				foreach (string extension in syntaxMode.Extensions) 
				{
					extensionsToName[extension.ToUpper()] = syntaxMode.Name;//��ĳһ���ļ���ʹ������﷨ģʽ.
				}
			}
			if (!syntaxModeProviders.Contains(syntaxModeProvider)) 
			{
				syntaxModeProviders.Add(syntaxModeProvider);//ע��:������Ӷ���.
			}
		}

		
		public IHighlightingStrategy FindHighlighterByName(string name)
		{
			object def = highlightingDefs[name];

			return (IHighlightingStrategy)(def == null ? highlightingDefs["Default"] : def);
		}
		
		
		public IHighlightingStrategy FindHighlighterForFile(string fileName)
		{
			string name = (string)extensionsToName[Path.GetExtension(fileName).ToUpper()];
			if (name != null) {
				return FindHighlighterByName(name);
			} else {
				return (IHighlightingStrategy)highlightingDefs["Default"];
			}
		}
		
		//���ڴ����¼�.
		protected virtual void OnReloadSyntaxHighlighting(EventArgs e)
		{
			if (ReloadSyntaxHighlighting != null) {
				ReloadSyntaxHighlighting(this, e);
			}
		}
		//����װ���﷨��Ŀ��ʾ����.
		public void ReloadSyntaxModes()
		{
			highlightingDefs.Clear();
			extensionsToName.Clear();
			CreateDefaultHighlightingStrategy();
			foreach (SyntaxModeProvider provider in syntaxModeProviders) 
			{
				AddSyntaxModeProvider(provider);
			}
			OnReloadSyntaxHighlighting(EventArgs.Empty);//�����¼�,ʹ��Ӧ��ί��ʵ���ܹ������õ�.
		}
		

		public event EventHandler ReloadSyntaxHighlighting;

		static ArrayList errors = null;
		
		//�˺�������һ��syntaxMode�����һ��XmlTextReader����Ϊ����,������xmlTextReader��������Ӧ���﷨ģʽ�ļ�,
		//������һ����������ʾ���Զ���(DefaultHighlightingStrategy).
		DefaultHighlightingStrategy ParseSyntaxMode(SyntaxMode syntaxMode, XmlTextReader xmlTextReader)
		{
			try 
			{
                //
                //����dotnetFramework2.0�в�֧��XmlValidatingReader�����ԣ���������֤XML�ļ���ʽ�Ĵ���ע�͵��ˡ�
                //
                //System.Xml.XmlValidatingReader validatingReader = new XmlValidatingReader(xmlTextReader);
                //Stream shemaStream = Assembly.GetCallingAssembly().GetManifestResourceStream("Mode.xsd");
                //validatingReader.Schemas.Add("", new XmlTextReader(shemaStream));
                //validatingReader.ValidationType = ValidationType.Schema;
                //validatingReader.ValidationEventHandler += new ValidationEventHandler (ValidationHandler);
				//���϶�����һ��XmlValidatingReader����,������֤�﷨ģʽ�ļ�.(��CSharp-Mode.xshd)
				
				XmlDocument doc = new XmlDocument();
                //doc.Load(validatingReader);   ���ָ��������ע�ͣ�������Ҳ��Ҫ�޸�
                doc.Load(xmlTextReader);
				
				DefaultHighlightingStrategy highlighter = new DefaultHighlightingStrategy(doc.DocumentElement.Attributes["name"].InnerText);
				
				if (doc.DocumentElement.Attributes["extensions"]!= null) 
				{
					highlighter.Extensions = doc.DocumentElement.Attributes["extensions"].InnerText.Split(new char[] { ';', '|' });
				}
				
				// parse environment color
				XmlElement environment = doc.DocumentElement["Environment"];
				if (environment != null) 
				{
					foreach (XmlNode node in environment.ChildNodes) 
					{
						if (node is XmlElement) 
						{
							XmlElement el = (XmlElement)node;
							highlighter.SetColorForEnvironment(el.Name, new HighlightColor(el));
						}
					}
				}
				
				// parse properties,not all xshd files have
				if (doc.DocumentElement["Properties"]!= null) 
				{
					foreach (XmlElement propertyElement in doc.DocumentElement["Properties"].ChildNodes) 
					{
						highlighter.Properties[propertyElement.Attributes["name"].InnerText] =  propertyElement.Attributes["value"].InnerText;
					}
				}
				
				// parse digits
				if (doc.DocumentElement["Digits"]!= null) 
				{
					highlighter.DigitColor = new HighlightColor(doc.DocumentElement["Digits"]);
				}
				
				XmlNodeList nodes = doc.DocumentElement.GetElementsByTagName("RuleSet");
				foreach (XmlElement element in nodes) 
				{
					highlighter.AddRuleSet(new HighlightRuleSet(element));
				}
				
				xmlTextReader.Close();
				
				if(errors!=null) 
				{
					ReportErrors(syntaxMode.FileName);
					errors = null;
					return null;
				} 
				else 
				{
					return highlighter;		
				}
			} 
			catch (Exception e) 
			{
				MessageBox.Show("���ܼ����﷨ģʽ�ļ�.\n" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return null;
			}
		}	
		
		
		void ValidationHandler(object sender, ValidationEventArgs args)
		{
			if (errors==null) 
			{
				errors=new ArrayList();
			}
			errors.Add(args);
		}

		
		void ReportErrors(string fileName)
		{
			StringBuilder msg = new StringBuilder();
			msg.Append("���ܼ����﷨ģʽ�ļ�: " + fileName + " ,ԭ��:\n\n");
			foreach(ValidationEventArgs args in errors) 
			{
				msg.Append(args.Message);
				msg.Append(Console.Out.NewLine);
			}
			MessageBox.Show(msg.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
		}

	}

	

}
