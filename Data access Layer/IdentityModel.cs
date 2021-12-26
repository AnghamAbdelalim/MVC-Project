
using Data_access_Layer;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access_Layer
{
    public class ApplicationUserIdentity : IdentityUser
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
    public class ApplicationUserStore : UserStore<ApplicationUserIdentity>
    {
        public ApplicationUserStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager()
            : base(new RoleStore<IdentityRole>(new ApplicationDBContext()))
        {

        }
        public ApplicationRoleManager(DbContext db)
            : base(new RoleStore<IdentityRole>(db))
        {

        }
    }
    public class ApplicationUserManager : UserManager<ApplicationUserIdentity>
    {
        public ApplicationUserManager() : base(new ApplicationUserStore())
        {

        }
        public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
        {

        }
    }
    public class Order
    {
        public int OrderId { get; set; }

        public int PaymentId { get; set; }
        public string Orderdate { get; set; }
        public string Description { get; set; }
        public int totalPrice { get; set; }
        public int discount { get; set; }
        public int OrderNumber { get; set; }
        public string UserID { get; set; }
        public int ShipoperID { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ApplicationUserIdentity appUserID { get; set; }
    }
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public int ProductPrice { get; set; }
        public float ProducteDiscount { get; set; }
        public string AutherName { get; set; }
        public int NumberOfPage { get; set; }
        public int ProductQuantity { get; set; }
        public int CategorysID { get; set; }
        public int SuppliersID { get; set; }
        public int OrderDetailsID { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
        public virtual ICollection<CartDetails> CartDetails { get; set; }
    }

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CategoryImage { get; set; }
        
        public virtual ICollection<Product> products { get; set; }
    }
    
   
    public class OrderDetails

    {
        [Key]
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public string BillDate { get; set; }
        public string ShipperDate { get; set; }
        public int Discount { get; set; }
        public int TotalPrice { get; set; }
        public int OrderNumber { get; set; }
        public virtual Order OrderID { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string Logo { get; set; }
        public int Phone { get; set; }
        public virtual ICollection<Product> products { get; set; }
       
    }
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<CartDetails> CartDetails { get; set; }
        public virtual ApplicationUserIdentity appUser { get; set; }

    }
    public class CartDetails
    {
        [Key]
        public int CartDetailId { get; set; }
       
        public int ProductQuantity{ get; set; }
       
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }
        
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("ShoppingCart")]
        public int ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
    public class Payment
    {
        public int PaymentID { get; set; }
        public int Amount { get; set; }
        public virtual CreditCard CreditCardID { get; set; }
        public int CreditCadrdNumber { get; set; }
        public virtual ApplicationUserIdentity UserName { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public DateTime Expire_Date { get; set; }
        public int CCV { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


    }
    public class Shipper
    {
        public int ShipperID { get; set; }
        public string ShipperMethod{ get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
      
        [Column(TypeName = "date")]
        public DateTime shipper_date { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


    }
    public class Wishlist
    {
        public int ID { get; set; }

        [ ForeignKey("User")]
        
        public  string ProductID { get; set; }
        public  int ApplicationUserIdentity_Id { get; set; }
        public virtual ApplicationUserIdentity User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    public class CreditCard
    {
        public int CreditCardID { get; set; }
        public int CreditCadrdNumber { get; set; }
        public string HolderName { get; set; }
        public DateTime Expire_Date { get; set; }
    }
    public class ApplicationDBContext : IdentityDbContext<ApplicationUserIdentity>
    {

        public ApplicationDBContext() :
            base("name=Books")
        {

        }
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Shipper> Shipper { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<CartDetails> CartDetails { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }

    }
}
   

