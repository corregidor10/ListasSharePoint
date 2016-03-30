using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Office.Server.Utilities;
using Microsoft.SharePoint;

namespace UsoDeListas.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        DataTable dtable;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            dtable = new DataTable();

            dtable.Columns.Add("ID");
            dtable.Columns.Add("Title");
            dtable.Columns.Add("Peticion");
            dtable.Columns.Add("Realizada_x0020_por");
            dtable.Columns.Add("Fecha");
            dtable.Columns.Add("Cantidad", typeof(int));
            dtable.Columns.Add("Importe", typeof(decimal));
            dtable.Columns.Add("Total", typeof(decimal));
        }

        private bool ProcessError(SPListItem item, Exception e)
        {
            throw new Exception("Error al procesar, artista", e);
        }

        private void ProcessItem(SPListItem item)
        {
            string uniqueId = item["ID"].ToString();
            //string title = item["Title"].ToString(); quito el title xq no lo uso
            string peticion = item["Peticion"].ToString();
            string realizada = item["Realizada_x0020_por"].ToString();
            string fecha = item["Fecha"].ToString();
            int cantidad = Int32.Parse(item["Cantidad"].ToString());
            decimal importe = Decimal.Parse(item["Importe"].ToString());
            decimal total = Decimal.Parse((cantidad * importe).ToString()); 


            dtable.Rows.Add(uniqueId, peticion, realizada, fecha, cantidad, importe, total);

        }

        protected override void OnPreRender(EventArgs e)
        {
            var consultachapuza = @"
                <Where>
                                         <Eq>
                            <FieldRef Name=""Estado""></FieldRef>
                            <Value Type=""Choice"">Pendiente</Value>
                        </Eq>
                                  </Where>
                ";

            var verCampos = @"                
                <FieldRef Name=""ID"" />
                <FieldRef Name=""Peticion"" />
                <FieldRef Name=""Realizada_x0020_por"" />
                <FieldRef Name=""Fecha"" />                                                
                <FieldRef Name=""Cantidad"" />
                <FieldRef Name=""Importe"" />    
                <FieldRef Name=""Total"" />         
                ";
            SPQuery consulta = new SPQuery();
            consulta.Query = consultachapuza;

            consulta.ViewFields = verCampos;


            var web = SPContext.Current.Web;
            var list = web.Lists["PresupuestoMaterial"];

           ContentIterator iterator= new ContentIterator();
            iterator.ProcessListItems(list, consulta, ProcessItem, ProcessError);
            lstExpenses.DataSource = dtable;
            lstExpenses.DataBind();

            // TODO 001 REEMPLAZAMOS EL BINDING PARA LA PROBAR LA GESTION DE TABLAS LARGAS
            //
            //var items = list.GetItems(consulta);

            //lstExpenses.DataSource = items.GetDataTable();
            //lstExpenses.DataBind();

        }

        private static bool IsChecked(ListViewDataItem item)
        {
            var checkBox = item.FindControl("chkUpdate") as CheckBox;

            return checkBox.Checked;
        }

        private void UpdateItems(bool isApproved)
        {
            string status = isApproved ? "Aprobado" : "Rechazado"; // if else 2.0

            var selectedItems = from item in lstExpenses.Items

                                where IsChecked(item)

                                select item;


            var web = SPContext.Current.Web;
            var list = web.Lists["PresupuestoMaterial"];

            foreach (var selectedItem in selectedItems)
            {
                var campoOculto = selectedItem.FindControl("hdCodigo") as HiddenField;
                int itemID;

                if (int.TryParse(campoOculto.Value, out itemID))
                {
                    SPListItem item = list.GetItemById(itemID);

                    item["Estado"] = status;

                    item.Update();
                }
            }

        }


        protected void btnApprove_Click(object sender, EventArgs e)
        {
            UpdateItems(true);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            UpdateItems(false);
        }
    }
}
