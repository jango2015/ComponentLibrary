<%@ Control targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table height="380" cellSpacing="4" cellPadding="3" width="100%" border="1">
	<tr height="20">
		<td vAlign="middle" align="left" width="10%">��1</td>
		<td vAlign="middle" align="left" width="35%">
			<asp:dropdownlist id="relationFromTable1DropDownList" AutoPostBack="True" Width="170" Runat="server"></asp:dropdownlist></td>
		<td vAlign="middle" align="left" width="10%">��2
		</td>
		<td vAlign="middle" align="left" width="35%" colspan="2">
			<asp:dropdownlist id="relationFromTable2DropDownList" AutoPostBack="True" Width="170" Runat="server"></asp:dropdownlist></td>
	</tr>
	<tr height="20">
		<td vAlign="middle" align="left" width="10%">�ֶ�
		</td>
		<td vAlign="middle" align="left" width="35%">
			<asp:dropdownlist id="relationField1Dropdownlist" Width="170" Runat="server"></asp:dropdownlist></td>
		<td vAlign="middle" align="left" width="10%">�ֶ�</td>
		<td vAlign="middle" align="left" width="30%">
			<asp:dropdownlist id="relationField2Dropdownlist" Width="170" Runat="server"></asp:dropdownlist>
		</td>
		<td vAlign="middle" align="right">
			<asp:button id="addJoinFieldButton" Runat="server" Text="����ֶ�"></asp:button></td>
	</tr>
	<tr>
		<td vAlign="top" align="left" colSpan="6" height="100">��ǰ�������ֶ�<br>
			<asp:listbox id="currentSelectedJoinFieldListBox" Width="100%" runat="server" Height="105px"></asp:listbox>
		</td>
	</tr>
	<tr height="30">
		<td align="right" colspan="5">
			ѡ���������<asp:dropdownlist id="joinTypeDropdownlist" Width="120" Runat="server">
				<asp:ListItem Value="Cross Join">��������</asp:ListItem>
				<asp:ListItem Value="Inner Join">������</asp:ListItem>
				<asp:ListItem Value="Left Join">������</asp:ListItem>
				<asp:ListItem Value="right Join">������</asp:ListItem>
				<asp:ListItem Value="Full Join">ȫ����</asp:ListItem>
			</asp:dropdownlist>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:button id="addRelationButton" Runat="server" Text="��ӹ���"></asp:button></td>
	</tr>
	<tr>
		<td vAlign="top" align="left" colSpan="5">��ǰ���й�ϵ<br>
			<asp:listbox id="currentTableRelationListBox" Width="100%" runat="server" Height="150px"></asp:listbox></td>
	</tr>
</table>
