<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="Application.Person" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>People</h1>
    <asp:LinkButton ID="lnkPrev" OnClick="lnkPrev_OnClick" runat="server">Previous</asp:LinkButton>
    <asp:LinkButton ID="lnkNext" OnClick="lnkNext_OnClick" runat="server">Next</asp:LinkButton>
    <br />
    <br />
    ID:
    <asp:Label ID="lblID" runat="server" Text="1"></asp:Label>
    <br />
    Name:
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    <br />
    Age:
    <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
    <br />
    Date of Birth:
    <asp:Label ID="lblDob" runat="server" Text=""></asp:Label>
    <br />
    Hobby:
    <asp:Label ID="lblHobby" runat="server" Text=""></asp:Label>
</asp:Content>