<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Application.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home</h1>
    <asp:DropDownList ID="ddlHobbies" Visible="True" DataTextField="Hobby" DataValueField="ID" runat="server"></asp:DropDownList>
</asp:Content>