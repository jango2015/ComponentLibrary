
using System;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using NetFocus.Components.TextEditor.Document;


namespace NetFocus.Components.TextEditor
{
	public delegate void MarginMouseEventHandler(AbstractMargin sender, Point mousepos, MouseButtons mouseButtons);
	public delegate void MarginPaintEventHandler(AbstractMargin sender, Graphics g, Rectangle rect);
	
	//��������һ������,������һ���ı�����,Ҳ������һ��װ��������,������һ���۵�����,etc.
	public abstract class AbstractMargin
	{
		protected Rectangle drawingRectangle = new Rectangle(0, 0, 0, 0);
		protected TextArea  textArea;
		
		public Rectangle DrawingRectangle {
			get {
				return drawingRectangle;
			}
			set {
				drawingRectangle = value;
			}
		}
		
		public TextArea TextArea {
			get {
				return textArea;
			}
		}
		
		public IDocument Document {
			get {
				return textArea.Document;
			}
		}
		
		public ITextEditorProperties TextEditorProperties {
			get {
				return textArea.Document.TextEditorProperties;
			}
		}
		
		public virtual Cursor Cursor {
			get {
				return Cursors.Default;//Ĭ���������Ĺ��,������˵��GutterMargin�������д��Ĭ��ֵ.
			}
		}
		
		public virtual Size Size {
			get {
				return new Size(-1, -1);
			}
		}
		
		public virtual bool IsVisible {
			get {
				return true;
			}
		}
		
		
		protected AbstractMargin(TextArea textArea)
		{
			this.textArea = textArea;
		}
		
		
		//���¶�����һЩ���������¼��ͷ���,�Լ�������һ����λ����Լ����¼��ͷ���.
		public virtual void OnMouseDown(Point mousepos, MouseButtons mouseButtons)
		{
			if (MouseDown != null) {
				MouseDown(this, mousepos, mouseButtons);
			}
		}
		public virtual void OnMouseMove(Point mousepos, MouseButtons mouseButtons)
		{
			if (MouseMove != null) {
				MouseMove(this, mousepos, mouseButtons);
			}
		}
		public virtual void OnMouseLeave(EventArgs e)
		{
			if (MouseLeave != null) {
				MouseLeave(this, e);
			}
		}
		
		public virtual void OnPaint(Graphics g, Rectangle rect)
		{
			if (Paint != null) 
			{
				Paint(this, g, rect);
			}
		}
		
		public event MarginMouseEventHandler MouseDown;
		public event MarginMouseEventHandler MouseMove;
		public event EventHandler            MouseLeave;
		public event MarginPaintEventHandler Paint;
	}
}

