using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckOut : System.Web.UI.Page
{
    private Customer customer;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            customer = (Customer)Session["Customer"];
            this.LoadCustomerData();
        }
    }
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            this.GetCustomerData();
            Response.Redirect("~/CheckOut2.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session.Remove("Cart");
        Session.Remove("Customer");
        Response.Redirect("~/Order.aspx");
    }
    private void LoadCustomerData()
    {
        if (customer != null)
        {
            txtFirstName.Text = customer.FirstName;
            txtLastName.Text = customer.LastName;
            txtEmail1.Text = customer.EmailAddress;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address;
            txtCity.Text = customer.City;
            ddlState.SelectedValue = customer.State;
            txtZip.Text = customer.Zip;
            // load data into other text boxes from customer object
            cblAboutList.Items[0].Selected = customer.NewProductsInfo;
            cblAboutList.Items[1].Selected = customer.SpecialPromosInfo;
            cblAboutList.Items[2].Selected = customer.NewRevisionsInfo;
            cblAboutList.Items[3].Selected = customer.LocalEventsInfo;
            if (!IsPostBack)
            {
                lstContactVia.SelectedValue = customer.ContactVia;
            }        
        }
    }
    private void GetCustomerData()
    {
        if (customer == null)
            customer = new Customer();
        customer.FirstName = txtFirstName.Text;
        customer.LastName = txtLastName.Text;
        customer.EmailAddress = txtEmail1.Text;
        customer.Phone = txtPhone.Text;
        customer.Address = txtAddress.Text;
        customer.City = txtCity.Text;
        customer.State = ddlState.SelectedValue;
        customer.Zip = txtZip.Text;
        //get data from the other text boxes and load into customer object
        customer.NewProductsInfo = cblAboutList.Items[0].Selected;
        customer.SpecialPromosInfo = cblAboutList.Items[1].Selected; 
        customer.NewRevisionsInfo = cblAboutList.Items[2].Selected; 
        customer.LocalEventsInfo = cblAboutList.Items[3].Selected;

        //collect every index from the server control / listbox control
        int[] indiciesArray = lstContactVia.GetSelectedIndices();

        //goes through every index inside the array
        foreach(var i in indiciesArray)
        {
            switch(i)
            {
                case 0:
                    customer.ContactViaTwitter = true;
                    break;
                case 1:
                    customer.ContactViaFacebook = true;
                    break;
                case 2:
                    customer.ContactViaText = true;
                    break;
                case 3:
                    customer.ContactViaEmail = true;
                    break;
            }
        }
        
    //    if (lstContactVia.SelectedValue == "Twitter") { customer.ContactViaTwitter = true; }
    //    if (lstContactVia.SelectedValue == "Facebook") { customer.ContactViaFacebook = true; }
    //    if (lstContactVia.SelectedValue == "Text") { customer.ContactViaText = true; }
    //    if (lstContactVia.SelectedValue == "Email") { customer.ContactViaEmail = true; }
        Session["Customer"] = customer;
    }
}