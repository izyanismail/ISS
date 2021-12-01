<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExtensionB.aspx.cs" Inherits="ExtensionB" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>

    <table  align="center" cellpadding="10">
     <tr>
     <%-- <td rowspan="2">
        <asp:Label ID="Label2" runat="server" Text="Select date :"></asp:Label>
      </td>--%>
      <td>
         <asp:TextBox ID="TextBox2" runat="server" Width="280px"></asp:TextBox>
         <asp:ImageButton ID="ImageButton1" runat="server" imageURL="~/calendar.png" 
             Height="30px" Width="29px" onclick="ImageButton1_Click" 
             ImageAlign="AbsBottom"/>
      </td>
      <td>
        <cc1:TimeSelector ID="TimeSelector8" runat="server" SelectedTimeFormat="TwentyFour" DisplaySeconds="false">
        </cc1:TimeSelector>
       </td>
     </tr>

     <tr>
      <td colspan="">
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
             BorderColor="#999999" CellPadding="4" DayNameFormat="FirstLetter" 
             Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
             onselectionchanged="Calendar1_SelectionChanged" Width="200px" 
             Visible="False">
             <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
             <NextPrevStyle VerticalAlign="Bottom" />
             <OtherMonthDayStyle ForeColor="#808080" />
             <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
             <SelectorStyle BackColor="#CCCCCC" />
             <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
             <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
             <WeekendDayStyle BackColor="#FFFFCC" />
         </asp:Calendar>
      </td>
     </tr>

     <tr>
        <td colspan="2">
          <center>
             <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" 
              style="width: 56px" />
              <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
          </center>
      </td>
     </tr>
    </table>

    <br /><br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    </form>
</body>
</html>
