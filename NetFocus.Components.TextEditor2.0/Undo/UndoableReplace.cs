
using System;
using System.Diagnostics;
using System.Drawing;
using NetFocus.Components.TextEditor.Document;
using NetFocus.Components.TextEditor.Undo;


namespace NetFocus.Components.TextEditor.Undo
{
	/// <summary>
	/// This class is for the undo of Document replace operations
	/// </summary>
	public class UndoableReplace : IUndoableOperation
	{
		IDocument document;
		int       offset;
		string    text;
		string    origText;
			
		public UndoableReplace(IDocument document, int offset, string origText, string text)
		{
			if (document == null) {
				throw new ArgumentNullException("�ĵ�");
			}
			if (offset < 0 || offset > document.TextLength) {
				throw new ArgumentOutOfRangeException("λ��");
			}

			this.document = document;
			this.offset   = offset;
			this.origText = origText;
			this.text     = text;
		}

		public void Undo()
		{
			document.UndoStack.AcceptChanges = false;
			document.Replace(offset, text.Length, origText);
			document.UndoStack.AcceptChanges = true;
		}
		
		public void Redo()
		{
			document.UndoStack.AcceptChanges = false;
			document.Replace(offset, origText.Length, text);
			document.UndoStack.AcceptChanges = true;
		}
	}
}
