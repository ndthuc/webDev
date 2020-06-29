using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using E_Commerce.Models;
using E_Commerce.Models.CartModels;
using E_Commerce.Models.AccountModels;

namespace E_Commerce.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1();

        // GET: Cart
        public ActionResult Index()
        {
            if(Session["user"] == null)
            {
                RedirectToAction("Login", "Account");
            }
            List<CartItem> MyCart = Session["mycart"] as List<CartItem>;
            return View(MyCart);

        }

        public ActionResult Checkout()
        {
            return View();
        }

        public RedirectToRouteResult AddCart(int ProductID)
        {
            if (Session["mycart"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["mycart"] = new List<CartItem>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }

            List<CartItem> Cart = Session["mycart"] as List<CartItem>;  // Gán qua biến giohang dễ code

            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa

            if (Cart.FirstOrDefault(m => m.ProductID == ProductID) == null) // ko co sp nay trong gio hang
            {
                Product product = db.Products.Find(ProductID);  // tim sp theo ProductID
                CartItem newItem = new CartItem()
                {
                    ProductID = ProductID,
                    ProductName = product.ProductName,
                    Quantity = 1,
                    ProductImg = product.ProductImg,
                    Price = Convert.ToInt32(product.Price)

                };  // Tạo ra 1 CartItem mới

                Cart.Add(newItem);  // Thêm CartItem vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                CartItem cardItem = Cart.FirstOrDefault(m => m.ProductID == ProductID);
                cardItem.Quantity++;
            }

            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            return RedirectToAction("Index", new { id = ProductID });
        }

        public RedirectToRouteResult UpdateCartItem(int ProductID, int newQuantity)
        {
            // tìm carditem muon sua
            List<CartItem> Cart = Session["mycart"] as List<CartItem>;
            CartItem updatedItem = Cart.FirstOrDefault(m => m.ProductID == ProductID);
            if (updatedItem != null)
            {
                updatedItem.Quantity = newQuantity;
            }
            return RedirectToAction("Index");

        }

        public ActionResult DeleteCartItem(int ProductID)
        {
            List<CartItem> Cart = Session["mycart"] as List<CartItem>;
            CartItem deletedItem = Cart.FirstOrDefault(m => m.ProductID == ProductID);
            if (deletedItem != null)
            {
                Cart.Remove(deletedItem);
            }
            return RedirectToAction("Index");
        }
    }
}