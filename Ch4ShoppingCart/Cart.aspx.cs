using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    private CartItemList cart;

    protected void Page_Load(object sender, EventArgs e)
    {
        cart = CartItemList.GetCart();

        if (!IsPostBack)
        {
            this.DisplayCart();
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (cart.Count > 0)
        {
            if (lstCart.SelectedIndex > -1)
            {
                //remove selected item from cart and re-add cart items
                cart.RemoveAt(lstCart.SelectedIndex);
                this.DisplayCart();
            }
            else
            {
                //if no item is selected, notify user
                lblMessage.Text = "Please select an item to remove.";
            }
        }
    }

    private void DisplayCart()
    {
        //remove all current items from the list control
        lstCart.Items.Clear();

        //loop through cart and add each item's Display value to the control
        for (int i = 0; i < cart.Count; i++)
            lstCart.Items.Add(this.cart[i].Display());
    }

    protected void btnEmpty_Click(object sender, EventArgs e)
    {
        //if cart has items, clear both cart and list control
        if (cart.Count > 0)
        {
            cart.Clear();
            lstCart.Items.Clear();
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {

    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "Sorry that function hasn't been implemented yet.";
    }
}