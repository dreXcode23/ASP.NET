using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Order : System.Web.UI.Page
{
    private Product selectedProduct;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //bind drop down list on first load
            //get and show product on every laod
            ddlProducts.DataBind();
        }

        selectedProduct = this.GetSelectedProduct();
        lblName.Text = selectedProduct.Name;
        lblShortDescription.Text = selectedProduct.ShortDescription;
        lblLongDescription.Text = selectedProduct.LongDescription;
        lblUnitPrice.Text = selectedProduct.UnitPrice.ToString("C") + " each";
        imgProduct.ImageUrl = "images/products/" + selectedProduct.ImageFile;

    }

    private Product GetSelectedProduct()
    {
        //get a row from sqlDataSource based on ddl value
        DataView productsTable = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);

        productsTable.RowFilter = string.Format("ProductID = '{0}'", ddlProducts.SelectedValue);

        DataRowView row = (DataRowView)productsTable[0];

        //Create a new product object and load with data from row
        Product p = new Product();
        p.ProductID = row["ProductID"].ToString();
        p.Name = row["Name"].ToString();
        p.ShortDescription = row["ShortDescription"].ToString();
        p.LongDescription = row["LongDescription"].ToString();
        p.UnitPrice = (decimal)row["UnitPrice"];
        p.ImageFile = row["ImageFile"].ToString();

        return p;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //get cart from session state and selected item from cart
            CartItemList cart = CartItemList.GetCart();
            CartItem cartItem = cart[selectedProduct.ProductID];

            //if item isn't in cart, add it; otherwise, increase its quantity
            if (cartItem == null)
            {
                cart.AddItem(selectedProduct, Convert.ToInt32(txtQuantity.Text));
            }
            else
            {
                cartItem.AddQuantity(Convert.ToInt32(txtQuantity.Text));
            }
            Response.Redirect("Cart.aspx");
        }
    }
}