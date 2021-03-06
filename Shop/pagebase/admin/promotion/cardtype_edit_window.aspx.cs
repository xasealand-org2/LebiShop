﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Bussiness;
using Shop.Model;
using Shop.Tools;

namespace Shop.Admin.Config
{
    public partial class CardType_Edit_window : AdminAjaxBase
    {
        protected Lebi_CardOrder model;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("cardtype_edit", "编辑优惠券"))
            {
                PageNoPower();
            }
            int id = RequestTool.RequestInt("id", 0);
            model = B_Lebi_CardOrder.GetModel(id);
            if (model == null)
            {
                model = new Lebi_CardOrder();
                model.Type_id_CardType = 311;
            }
        }

        public string protypes(string ids)
        {
            string str = "";
            List<Lebi_Pro_Type> ts = B_Lebi_Pro_Type.GetList("Parentid=0", "Sort desc");
            foreach (Lebi_Pro_Type t in ts)
            {
                string sel = "";
                if (("," + ids + ",").Contains("," + t.id + ","))
                    sel = "checked";
                str += "<label><input type=\"checkbox\" name=\"Pro_Type_ids\" shop=\"true\" value=\"" + t.id + "\" " + sel + "/>" + Lang(t.Name) +"</label>";
            }

            return str;
        }
    }
}