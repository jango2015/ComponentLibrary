<%@ Control targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellpadding="5" cellspacing="3" border="0" width="100%" style="BORDER-RIGHT: #b8d1f8 1px solid; BORDER-TOP: #b8d1f8 1px solid; BORDER-LEFT: #b8d1f8 1px solid">
	<tr>
		<td>
			<b>��ѯҵ������:</b><br>
			<asp:panel id="P" runat="server"></asp:panel>
		</td>
	</tr>
</table>
<table cellpadding="3" cellspacing="3" border="0" width="100%" style="BORDER-RIGHT: #b8d1f8 1px solid; BORDER-TOP: #b8d1f8 1px solid; BORDER-LEFT: #b8d1f8 1px solid; BORDER-BOTTOM: #b8d1f8 1px solid">
	<tr>
		<td valign="top">
			<b>�����ѯ����:</b><br>
			<asp:Table id="T" runat="server"></asp:Table>
		</td>
	</tr>
	<tr height="30">
		<td valign="middle">
			<asp:Button ID="Save" Runat="server" Text="��������"></asp:Button><FONT face="����">&nbsp;&nbsp; 
				&nbsp;
				<asp:Button id="Query" Text="ִ�в�ѯ" Runat="server"></asp:Button></FONT>
		</td>
	</tr>
	<tr>
		<td>
			<asp:Label ID="showMessage" Runat="server"></asp:Label>
		</td>
	</tr>
</table>
