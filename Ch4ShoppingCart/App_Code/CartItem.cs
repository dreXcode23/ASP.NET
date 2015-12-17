using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartItem
/// </summary>
public class CartItem
{
    //Properties
    public Product Product { get; set; }
    public int Quantity { get; set; }

    //Constructors
    public CartItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public CartItem(Product product, int quantity)
    {
        this.Product = product;
        this.Quantity = quantity;
    }

    //Method
    public void AddQuantity(int quantity)
    {
        this.Quantity += quantity;
    }

    public string Display()
    {
        return String.Format("{0} ({1} at {2} each)", Product.Name, Quantity.ToString(),
            Product.UnitPrice.ToString("c"));
    }
}