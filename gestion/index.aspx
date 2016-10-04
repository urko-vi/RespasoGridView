<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="gestion.index" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button runat="server" Text="Crear Empleado" OnClick="crearEmpleado"></asp:Button>
    <asp:GridView ID="gridEmpleados" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataKeyNames="idTrabajador" OnRowCommand="gridEmpleados_RowCommand">
        <Columns>
            <asp:ButtonField CommandName="editEmpleado" Text="Editar" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" OnClientClick="return confirm('¿Esta ud. seguro de querer borrar el empleado?')" runat="server" CausesValidation="false" CommandName="deleteEmpleado" Text="Borrar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>


    </asp:GridView>

    <!--

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GESTPERSONALConnectionString %>" SelectCommand="SELECT * FROM [trabajador]"></asp:SqlDataSource>
    -->
</asp:Content>
