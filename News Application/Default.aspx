<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ OutputCache Duration="30" VaryByParam="*" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>News TryIt Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="News TryIt Example"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Enter US zipcode"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" placeholder="zipcode"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Font-Bold="True" Text="Search" OnClick="searchButton_Click" />

        </div>
        <asp:Label ID="Label1" runat="server" Text="Output:"></asp:Label>
        <asp:Label ID="validateLabel" runat="server"></asp:Label>
        <br />
        <br />

            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Earthquake Counter"></asp:Label>
            <br />
        <asp:Label ID="Label5" runat="server" Text="From Date: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="YYYY-MM-DD"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="To Date: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" placeholder="YYYY-MM-DD"></asp:TextBox>
            &nbsp;<asp:Button ID="FindButton" runat="server" Font-Bold="true" Text="Find" OnClick="Button2_Click" />
        <br />
            <asp:Label ID="Label7" runat="server" Text="No Of EarthQuakes Occured in above zipcode: "></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox4" runat="server" placeholder="-" Width="62px"></asp:TextBox>
        <br />
        <br />

            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Weather Forecast"></asp:Label>
            &nbsp;<br />
        <br />
        <asp:Button ID="Button2" runat="server" Font-Bold="true" OnClick="Button2_Click1" style="margin-right: 0px" Text="Give Detailed Weather Report" />
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Temperature: "></asp:Label>
            <asp:TextBox ID="t3" runat="server" placeholder="x"></asp:TextBox>
            <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="is DayTime? "></asp:Label>
            <asp:TextBox ID="t4" runat="server" placeholder="x"></asp:TextBox>
            <br />
        <br />
        <asp:Label ID="Label11" runat="server" Text="Detailed Forecast: "></asp:Label>
            <asp:TextBox ID="t5" runat="server" placeholder="x"></asp:TextBox>
            <br />
        <br />
        <asp:Label ID="Label12" runat="server" Text="Number: "></asp:Label>
            <asp:TextBox ID="t6" runat="server" placeholder="x"></asp:TextBox>
            <br />
        <br />
        <asp:Label ID="Label13" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="t7" runat="server" placeholder="x"></asp:TextBox>
            <br />
        <br />
        <br />
            <br />
        <br />
    </form>
    <div id="outputDiv" runat="server"></div>
</body>
</html>
