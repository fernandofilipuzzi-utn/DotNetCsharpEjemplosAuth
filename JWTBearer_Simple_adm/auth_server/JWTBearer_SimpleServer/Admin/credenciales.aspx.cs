﻿using JWTBearer_Models.Models;
using JWTBearer_Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JWTBearer_SimpleServer.Admin
{
    public partial class credenciales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack==false)
            {
                string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
                JWTBearer_ServicesManager oservice = new JWTBearer_ServicesManager(pathDb);
               
                lvCredenciales.DataSource = oservice.credencialDAO.BuscarTodos().Tables[0];
                lvCredenciales.DataBind();
            }

        }

        protected void lvCredenciales_ItemCreated(object sender, ListViewItemEventArgs e)
        {

        }

        protected void lvCredenciales_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            /*<asp:HyperLink ID="hlModificar" runat="server">MODIFICAR</asp:HyperLink>
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink hlModificar= e.Item.FindControl("hlModificar") as HyperLink;

                int? Id = DataBinder.Eval(e.Item.DataItem, "id") as int?;
               
                hlModificar.NavigateUrl = $"credenciales_edicion.aspx?Id={Id}";

            }
            */
        }

        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btnEliminar = (LinkButton)sender;
            //int id = Convert.ToInt32(btnEliminar.CommandArgument);
            int id = 1;

            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            JWTBearer_ServicesManager oservice = new JWTBearer_ServicesManager(pathDb);
            oservice.credencialDAO.Eliminar(id);

            lvCredenciales.DataSource = oservice.credencialDAO.BuscarTodos().Tables[0];
            lvCredenciales.DataBind();
        }
    }
}