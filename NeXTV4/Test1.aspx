<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test1.aspx.cs" Inherits="Test1" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
         body {
             background-size: 100%;
             width: 98%;
             background-repeat : no-repeat
            }
            
         .lbl input
           {
           font-family: Arial;
            font-size: medium;
            
          
            width: 50px !important;
            height: 30px !important;
           }
            
      </style>
</head>
<body background="bg1.jpeg">
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>

   <div  style="background-color:rgba(0,0,0,0.9); height: 80px; width:100;">
    <table  align="center" cellpadding="10">
     <tr>
     <%-- <td rowspan="2">
        <asp:Label ID="Label2" runat="server" Text="Select date :"></asp:Label>
      </td>--%>
      <td>
         <asp:TextBox ID="TextBox2" runat="server" Width="330px" Height="30px" 
              AutoPostBack="True" ></asp:TextBox>
         <asp:ImageButton ID="ImageButton1" runat="server" imageURL="~/calendar.png" 
             Height="40px" Width="40px" onclick="ImageButton1_Click" 
             ImageAlign="AbsBottom"/>
      </td>
      <td>
       <div class="lbl">
         <cc1:TimeSelector ID="TimeSelector8" runat="server" 
               DisplaySeconds="false"  >
         </cc1:TimeSelector>
        </div>
       </td>
          <td colspan="2">
          <center>
             <asp:Button ID="Button1" runat="server" Text="GO !" onclick="Button1_Click" 
              Height="30px"  Width="114px"  ForeColor="White"  Font-Names="Verdana" 
              Font-Size="Large" Font-Bold="True" BackColor="#0066FF" />
          </center>
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
     </table>
   </div>

    
    <div  style="background-color:rgba(255,255,255,0.6); height: 530px; width:100;">
       
       <table align="center">
        <tr>
         <td>
             <asp:GridView ID="GridView2" runat="server"  Font-Names="Arial"  
              style="text-align:center;width: auto;padding: 5px" CellPadding="1">
              <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             </asp:GridView>
         </td>
         <td>
            <asp:GridView ID="GridView1" runat="server"  Font-Names="Arial"  
             style="text-align:center;width: auto;padding: 0px" CellPadding="1">
             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
         </td>
         <td>
            <asp:GridView ID="GridView3" runat="server"
             Font-Names="Arial" style="text-align:center;width: auto;padding: 0px" CellPadding="1" >
             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
         </td>
        </tr>
       </table>
      
    
    </div>
    </form>
</body>
</html>
