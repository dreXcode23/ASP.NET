using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartItemList
/// </summary>
public class CartItemList
{
    private List<CartItem> cartItems;

    public CartItemList()
    {
        cartItems = new List<CartItem>();
    }

    /*Read-Only property that returns the number of items
      int the list */
    public int Count
    {
        get { return cartItems.Count; }
    }

    //indexer to locate an item in the list by index
    public CartItem this[int index]
    {
        get { return cartItems[index]; }
        set { cartItems[index] = value; }
    }

    //indexer to locate an item in the list by product
    public CartItem this[string id]
    {
        get { return cartItems.FirstOrDefault(c => c.Product.ProductID == id); }
    }

    //static method to get the cart object from session state
    public static CartItemList GetCart()
    {
        CartItemList cart = (CartItemList)HttpContext.Current.Session["Cart"];
        if (cart == null)
        {
            HttpContext.Current.Session["Cart"] = new CartItemList();
        }
        return (CartItemList)HttpContext.Current.Session["Cart"];
    }

    //Methods that add, remove, and clear items in the internal list
    public void AddItem(Product product, int quantity)
    { 
        CartItem c = new CartItem(product, quantity);
        cartItems.Add(c);
    }

    public void RemoveAt(int index)
    {
        cartItems.RemoveAt(index);
    }

    public void Clear()
    {
        cartItems.Clear(); 
    }
}