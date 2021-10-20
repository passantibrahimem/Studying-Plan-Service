<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterationForm.aspx.cs" Inherits="StudyingplanApp.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link rel="Stylesheet" type="text/css" href="PageFormat.css" />
    <title runat="server" id="MyTitle">Registeration Form</title>
    <style>
        #footer {
            position: fixed;
            padding: 10px 10px 0px 10px;
            bottom: 0;
            width: 100%;
            /* Height of the footer*/
            height: 40px;
            background: white;
        }

        title {
            font-size: large;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <style type="text/css">
        .submit {
            border: 1px solid #563d7c;
            border-radius: 5px;
            color: white;
            padding: 5px 10px 5px 25px;
            position: center;
            background: url(https://i.stack.imgur.com/jDCI4.png) left 3px top 5px no-repeat #563d7c;
        }
         .error
        {
            border: 1px solid red;
        }
           .errorstyle
        {
            font-size: 16px;
            line-height: 22px;           
        }
     
        .errorstyle ul li
        {
            margin-left: 5px;
            color: #ff0000;
        }
    </style>
    <form id="form2" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManagerCalendar" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanelCalendar" runat="server">
                <ContentTemplate>
                    <asp:Label ID="LabelDate" runat="server" Text=" Starting Date:"></asp:Label>
                    <asp:TextBox ID="TextBoxDate" runat="server" Font-Size="Small"
                        Height="20"
                        ReadOnly="true"
                        Width="80px"></asp:TextBox>
                    <asp:ImageButton ID="ImageButtonCalendar" runat="server"
                        ImageUrl="~/Images/calender.gif"
                        OnClick="ImageButtonCalendar_Click" ImageAlign="AbsMiddle" />
                    <asp:Calendar ID="Calendar" runat="server"
                        BackColor="#FFFFCC"
                        BorderColor="#FFCC66"
                        BorderWidth="1px"
                        DayNameFormat="Shortest"
                        Font-Names="Verdana"
                        Font-Size="8pt"
                        ForeColor="#663399"
                        Height="200px"
                        ShowGridLines="True"
                        Visible="false"
                        Width="220px"
                        CssClass="centered"
                        OnSelectionChanged="Calendar_SelectionChanged">
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                    </asp:Calendar>
                </ContentTemplate>
            </asp:UpdatePanel>         
        </div>
        <br />

        <div>
            <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="studyingDayslbl" runat="server" Text="Studying days"></asp:Label></td>
                    <td align="left">
                        <asp:ListBox runat="server" ID="DaysList" SelectionMode="multiple">
                            <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                            <asp:ListItem Text="Sunday" Value="Sunday"></asp:ListItem>
                            <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                            <asp:ListItem Text="Tuesday" Value="Tuesday"></asp:ListItem>
                            <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                            <asp:ListItem Text="Thursday" Value="Thursday"></asp:ListItem>
                            <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                        </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>

            <asp:Label ID="Label4" runat="server" Text=" Starting Chapter"></asp:Label>
            <asp:DropDownList ID="ChaptersDropBox" AutoPostBack="True" runat="server"></asp:DropDownList>

        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:Label ID="Sessionlbl" runat="server" Text=" Number of Sessions/Chapter"></asp:Label>
            <asp:TextBox ID="noOfsessionstxt" runat="server" Font-Size="Small" Height="10"></asp:TextBox>
        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit" runat="server" CssClass="submit" />
        </div>
        <br />
        <br />
        <br />
        <table>
            <tr>
                <td align="right">
                    <asp:Label ID="Ouputlabel" runat="server" Text="Sessions" /></td>
                <td align="left">
                    <asp:TextBox ID="Outputtxt" runat="server" TextMode="MultiLine" /></td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <table>
            <tr>
                <td align="right">
                    <asp:Label ID="ChapterDayslbl" runat="server" Text="Days/Chapter" /></td>
                <td align="left">
                    <asp:TextBox ID="EveryChapterDays" runat="server" TextMode="MultiLine" /></td>
            </tr>
        </table>
        <div class="errorstyle" >
            <asp:Literal ID="ltrlErrorMsg" runat="server"></asp:Literal>
        </div>
    </form>
    <div id="footer">
        &copy; Registeration Form
    </div>
</body>
</html>
