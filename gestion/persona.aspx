<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="persona.aspx.cs" Inherits="gestion.persona" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="codigoEmpleado" runat="server" />
    <asp:Label ID="lblNombreEmpleado" runat="server" Text="Nombre"></asp:Label><asp:TextBox ID="txtNombreEmpleado" runat="server"></asp:TextBox>
<asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Guardar_Click" />
 <asp:Button ID="Button2" runat="server" Text="Cancelar" OnClick="Cancelar_Click" />
</asp:Content>
