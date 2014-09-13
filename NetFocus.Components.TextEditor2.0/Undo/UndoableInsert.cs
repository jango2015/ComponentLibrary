
using System;
using System.Diagnostics;
using System.Drawing;
using NetFocus.Components.TextEditor.Document;
using NetFocus.Components.TextEditor.Undo;


namespace NetFocus.Components.TextEditor.Undo
{
	/// <summary>
	/// This class is for the undo of Document insert operations
	/// </summary>
	public class UndoableInsert : IUndoableOperation
	{
		IDocument document;
		int      offset;
		string   text;

		public UndoableInsert(IDocument document, int offset, string text)
		{
			if (document == null) {
				throw new ArgumentNullException("�ĵ�");
			}
			if (offset < 0 || offset > document.TextLength) {
				throw new ArgumentOutOfRangeException("λ��");
			}

			this.document = document;
			this.offset   = offset;
			this.text     = text;
		}
		
		public void Undo()
		{
			document.UndoStack.AcceptChanges = false;
			document.Remove(offset, text.Length);
			document.UndoStack.AcceptChanges = true;
		}
		
		public void Redo()
		{
			document.UndoStack.AcceptChanges = false;
			document.Insert(offset, text);
			document.UndoStack.AcceptChanges = true;
		}
	}
}

