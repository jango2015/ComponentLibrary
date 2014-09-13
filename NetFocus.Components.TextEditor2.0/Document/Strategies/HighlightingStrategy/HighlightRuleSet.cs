
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using System.Xml;

using NetFocus.Components.TextEditor.Util;


namespace NetFocus.Components.TextEditor.Document
{
	public class HighlightRuleSet
	{
		LookupTable keyWords;
		LookupTable prevMarkers;
		LookupTable nextMarkers;
		ArrayList   spans = new ArrayList();
		IHighlightingStrategy highlighter = null;
		bool noEscapeSequences = false;
		string      reference  = null;
		bool ignoreCase = false;
		string name     = null;
		bool[] delimiters = new bool[256];
		
		public ArrayList Spans {
			get {
				return spans;
			}
		}
		
		internal IHighlightingStrategy Highlighter {
			get {
				return highlighter;
			}
			set {
				highlighter = value;
			}
		}
		
		public LookupTable KeyWords {
			get {
				return keyWords;
			}
		}
		
		public LookupTable PrevMarkers {
			get {
				return prevMarkers;
			}
		}
		
		public LookupTable NextMarkers {
			get {
				return nextMarkers;
			}
		}
		
		public bool[] Delimiters {
			get {
				return delimiters;
			}
		}
		
		public bool NoEscapeSequences {
			get {
				return noEscapeSequences;
			}
		}
		
		public bool IgnoreCase {
			get {
				return ignoreCase;
			}
		}
		
		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}
		
		public string Reference {
			get {
				return reference;
			}
		}
		
		
		public HighlightRuleSet()
		{
			keyWords    = new LookupTable(false);
			prevMarkers = new LookupTable(false);
			nextMarkers = new LookupTable(false);
		}
		
		//ÿ��RuleSet�ڵ������:<RuleSet ignorecase = "false">......</RuleSet>
		public HighlightRuleSet(XmlElement el)
		{
			
			if (el.Attributes["name"] != null) {
				Name = el.Attributes["name"].InnerText;
			}
			
			if (el.Attributes["noescapesequences"] != null) {
				noEscapeSequences = Boolean.Parse(el.Attributes["noescapesequences"].InnerText);
			}
			
			if (el.Attributes["reference"] != null) {
				reference = el.Attributes["reference"].InnerText;
			}
			
			if (el.Attributes["ignorecase"] != null) {
				ignoreCase  = Boolean.Parse(el.Attributes["ignorecase"].InnerText);
			}
			
			for (int i  = 0; i < Delimiters.Length; ++i) {
				Delimiters[i] = false;
			}
			
			if (el["Delimiters"] != null) {
				string delimiterString = el["Delimiters"].InnerText;
				foreach (char ch in delimiterString) {
					Delimiters[(int)ch] = true;//����ǰ�ַ���Ϊ�ָ���.
				}
			}

			XmlNodeList nodes = null;

			//�����ǳ�ʼ��Span.
			nodes = el.GetElementsByTagName("Span");
			foreach (XmlElement el2 in nodes) 
			{
				Spans.Add(new Span(el2));
			}

			keyWords    = new LookupTable(!IgnoreCase);
			prevMarkers = new LookupTable(!IgnoreCase);
			nextMarkers = new LookupTable(!IgnoreCase);
			
			//�����ǳ�ʼ��KeyWords.
			nodes = el.GetElementsByTagName("KeyWords");
			foreach (XmlElement el2 in nodes) 
			{
				HighlightColor color = new HighlightColor(el2);
				
				XmlNodeList keys = el2.GetElementsByTagName("Key");
				foreach (XmlElement node in keys) 
				{
					keyWords[node.Attributes["word"].InnerText] = color;//Ϊÿ���ؼ��ֶ�����һ��HighLightColor����.
				}
			}
			
			//ÿ��MarkPrevious�ڵ������:
			//<MarkPrevious bold = "true" italic = "false" color = "MidnightBlue">(</MarkPrevious>
			nodes = el.GetElementsByTagName("MarkPrevious");
			foreach (XmlElement el2 in nodes) {
				PrevMarker prev = new PrevMarker(el2);
				prevMarkers[prev.What] = prev;
			}
			//ÿ��MarkFollowing�ڵ�����Ӻ�MarkFollowing��������ȫһ��.
			nodes = el.GetElementsByTagName("MarkFollowing");
			foreach (XmlElement el2 in nodes) {
				NextMarker next = new NextMarker(el2);
				nextMarkers[next.What] = next;
			}
		}
	}
}
