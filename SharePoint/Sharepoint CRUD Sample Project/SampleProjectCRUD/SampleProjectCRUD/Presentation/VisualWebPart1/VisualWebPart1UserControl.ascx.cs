using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SampleProjectCRUD.Business_Layer;

namespace SampleProjectCRUD.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        #region Declaration of variable, class
        PersonManager personManager = new PersonManager();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridView1.DataSource = personManager.retrievePerson();
                GridView1.DataBind();
            }
        }
    }
}
