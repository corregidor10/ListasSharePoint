<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="UsoDeListas.VisualWebPart1.VisualWebPart1UserControl" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:ListView runat="server" ID="lstExpenses">

            <LayoutTemplate>

                <table runat="server" id="tblExpenses" style="border: 2px dotted black; color: azure">
                    <thead>
                        <tr>
                           
                            <th></th>
                            <th>Peticion</th>
                            <th>Realizada por</th>
                            <th>Fecha</th>
                            <th>Cantidad</th>
                            <th>Importe</th>
                            <th>Total</th>
                        </tr>
                    </thead>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
                <asp:DataPager ID="datapager" runat="server" PageSize="20">
                    <Fields>
                        <asp:NumericPagerField ButtonCount="10" PreviousPageText="<**" NextPageText="**>" />
                    </Fields>
                </asp:DataPager>

            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">

                    <td runat="server">
                        <asp:CheckBox ID="chkUpdate" runat="server" />
                        <asp:HiddenField ID="hdCodigo" runat="server" Value='<%# Eval("ID") %>' />
                    </td>

                    <td runat="server">
                        <asp:Label ID="lblPeticion" runat="server" Text='<%# Eval("Peticion") %>' />
                    </td>
                    <td runat="server">

                        <asp:Label ID="lblRealizada" runat="server" Text='<%# Eval("Realizada_x0020_por") %>' />
                    </td>
                    <td runat="server">

                        <asp:Label ID="lblFecha" runat="server" Text='<%# Eval("Fecha") %>' />
                    </td>
                    <td runat="server">

                        <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>' />
                    </td>
                    <td runat="server">

                        <asp:Label ID="lblImporte" runat="server" Text='<%# Eval("Importe") %>' />
                    </td>
                    
                       <td runat="server">

                        <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total") %>' />
                    </td>
                    </tr>
               
            </ItemTemplate>
            
        </asp:ListView>
        
    </ContentTemplate>

</asp:UpdatePanel>
<p>
       
            <asp:Button runat="server" ID="btnApprove" Text="Aprobar" Width="100" BackColor="Green"  OnClick="btnApprove_Click"/>
           
            <asp:Button runat="server" ID="btnReject" Text="Rechazar" Width="100" BackColor="Red" OnClick="btnReject_Click"/>     
    
    </p>