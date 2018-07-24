using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Shared;
using System.Data;
using System.Data.SqlServerCe;

namespace ListDemo
{
    class GridViewModel :NotificationObject
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewModel"/> class.
        /// </summary>
        public GridViewModel()
        {

            this.ProductDetails = this.GetProducts();
            _addProduct = new DelegateCommand<ProductDetails>(AddProductHandler, CanAddProduct);
            _editProduct = new DelegateCommand<ProductDetails>(UpdateProductHandler, CanUpdateProduct);
            _deleteProduct = new DelegateCommand<ProductDetails>(DeleteProductHandler);
        }
        #endregion

        #region Command Handler

        /// <summary>
        /// Determines whether this instance [can add Product] the specified Product.
        /// </summary>
        /// <param name="Product">The Product.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can add Product] the specified Product; otherwise, <c>false</c>.
        /// </returns>
        bool CanAddProduct(ProductDetails Product)
        {
            return true;
        }

        /// <summary>
        /// Adds the Product handler.
        /// </summary>
        /// <param name="Product">The Product.</param>
        public void AddProductHandler(ProductDetails product)
        {
            if (product == null)
            {
                return;
            }
            this.ProductDetails.Add(product);
        }

        /// <summary>
        /// Determines whether this instance [can update Product] the specified Product.
        /// </summary>
        /// <param name="Product">The Product.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can update Product] the specified Product; otherwise, <c>false</c>.
        /// </returns>
        bool CanUpdateProduct(ProductDetails product)
        {
            return this.SelectedProduct != null;
        }

        /// <summary>
        /// Updates the Product handler.
        /// </summary>
        /// <param name="Product">The Product.</param>
        public void UpdateProductHandler(ProductDetails product)
        {
            if (product == null)
                return;
            this.SelectedProduct.ProductID =product.ProductID;
            this.SelectedProduct.Name=product.Name;
            this.SelectedProduct.ProductNumber=product.ProductNumber;
            this.SelectedProduct.SafetyStockLevel=product.SafetyStockLevel;
            this.SelectedProduct.ReorderPoint=product.ReorderPoint;
            this.SelectedProduct.DaysToManufacture= product.DaysToManufacture;
            this.SelectedProduct.FinishedGoodsFlag= product.FinishedGoodsFlag; 
        }

        /// <summary>
        /// Deletes the Product handler.
        /// </summary>
        /// <param name="Product">The Product.</param>
        public void DeleteProductHandler(ProductDetails Product)
        {
            if (Product == null)
                return;

            this.ProductDetails.Remove(Product);
        }

        #endregion

        private readonly DelegateCommand<ProductDetails> _addProduct;
        private readonly DelegateCommand<ProductDetails> _editProduct;
        private readonly DelegateCommand<ProductDetails> _deleteProduct;


        /// <summary>
        /// Gets the add Product.
        /// </summary>
        /// <value>The add Product.</value>
        public DelegateCommand<ProductDetails> AddProduct
        {
            get { return _addProduct; }
        }

        /// <summary>
        /// Gets the edit Product.
        /// </summary>
        /// <value>The edit Product.</value>
        public DelegateCommand<ProductDetails> EditProduct
        {
            get { return _editProduct; }
        }

        /// <summary>
        /// Gets the delete Product.
        /// </summary>
        /// <value>The delete Product.</value>
        public DelegateCommand<ProductDetails> DeleteProduct
        {
            get { return _deleteProduct; }
        }   

        #region Properties

        private ObservableCollection<ProductDetails> _productDetails;

        /// <summary>
        /// Gets or sets the Product details.
        /// </summary>
        /// <value>The Product details.</value>
        public ObservableCollection<ProductDetails> ProductDetails
        {
            get
            {
                return _productDetails;
            }
            set
            {
                _productDetails = value;
            }
        }

        private ProductDetails _SelectedProduct;

        /// <summary>
        /// Gets or sets the selected customer.
        /// </summary>
        /// <value>The selected customer.</value>
        public ProductDetails SelectedProduct
        {
            get
            {
                return _SelectedProduct;
            }
            set
            {
                _SelectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
               
            }
        }       
        
        #endregion  
        
        #region Methods

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<ProductDetails> GetProducts()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("AdventureWorksExt.sdf"));

                ObservableCollection<ProductDetails> _products = new ObservableCollection<ProductDetails>();
                using (SqlCeConnection c = new SqlCeConnection(connectionString))
                {

                    c.Open();
                    using (SqlCeCommand com = new SqlCeCommand("SELECT *  FROM Production_Product", c))
                    {
                        SqlCeDataReader reader = com.ExecuteReader();
                        int i = 0;
                        while (reader.Read())
                        {
                            _products.Add(new ProductDetails()
                            {
                                ProductID = Int32.Parse(reader["ProductID"].ToString()),
                                MakeFlag = bool.Parse(reader["MakeFlag"].ToString()),
                                Name = reader["Name"].ToString(),
                                FinishedGoodsFlag = bool.Parse(reader["FinishedGoodsFlag"].ToString()),
                                ProductNumber = (reader["ProductNumber"].ToString()),
                                Color = (reader["Color"].ToString()),
                                SafetyStockLevel = Int32.Parse(reader["SafetyStockLevel"].ToString()),
                                ReorderPoint = Int32.Parse(reader["ReorderPoint"].ToString()),
                                StandardCost = double.Parse(reader["StandardCost"].ToString()),
                                ListPrice = double.Parse(reader["ListPrice"].ToString()),
                                Size = (reader["Size"].ToString()),
                                DaysToManufacture = Int32.Parse(reader["DaysToManufacture"].ToString()),
                            });
                        }
                    }
                    c.Close();
                }
                return _products;
            }
            else
                return null;
        }
        #endregion    
    }   
}
