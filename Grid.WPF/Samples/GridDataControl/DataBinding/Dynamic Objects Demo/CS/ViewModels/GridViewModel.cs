using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace DynamicObjectsDemo
{
    class GridViewModel : OrderInfoRepository
    {
        #region Properties

        private readonly DelegateCommand<OrderInfo> _addOrder;
        private readonly DelegateCommand<dynamic> _editOrder;
        private readonly DelegateCommand<dynamic> _deleteOrder;
        private dynamic _selectedOrder;

        /// <summary>
        /// Gets or sets the selected order.
        /// </summary>
        /// <value>The selected order.</value>
        public dynamic SelectedOrder
        {
            get 
            {
                return _selectedOrder; 
            }
            set
            {
                _selectedOrder = value;
                RaisePropertyChanged("SelectedOrder");
            }
        }

        /// <summary>
        /// Gets the add order.
        /// </summary>
        /// <value>The add order.</value>
        public DelegateCommand<OrderInfo> AddOrder
        {
            get { return _addOrder; }
        }


        /// <summary>
        /// Gets the edit order.
        /// </summary>
        /// <value>The edit order.</value>
        public DelegateCommand<dynamic> EditOrder
        {
            get { return _editOrder; }
        }

        /// <summary>
        /// Gets the delete order.
        /// </summary>
        /// <value>The delete order.</value>
        public DelegateCommand<dynamic> DeleteOrder
        {
            get { return _deleteOrder; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewModel"/> class.
        /// </summary>
        public GridViewModel()
        {
            _addOrder = new DelegateCommand<OrderInfo>(AddOrderHandler, CanAddOrder);
            _editOrder = new DelegateCommand<dynamic>(UpdateOrderHandler, CanUpdateOrder);
            _deleteOrder = new DelegateCommand<dynamic>(DeleteOrderHandler, CanDeleteOrder);
        }

        #endregion

        #region Command Handler

        /// <summary>
        /// Determines whether this instance [can add order] the specified new order.
        /// </summary>
        /// <param name="newOrder">The new order.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can add order] the specified new order; otherwise, <c>false</c>.
        /// </returns>
        bool CanAddOrder(OrderInfo newOrder)
        {
            return true;
        }

        /// <summary>
        /// Adds the order handler.
        /// </summary>
        /// <param name="newOrder">The new order.</param>
        public void AddOrderHandler(OrderInfo newOrder)
        {
            if (newOrder == null)
            {
                return;
            }

            dynamic orderDetails=new ExpandoObject();
            orderDetails.OrderID = newOrder.OrderID;
            orderDetails.CustomerID = newOrder.CustomerID;
            orderDetails.EmployeeID = newOrder.EmployeeID;
            orderDetails.ShipCity = newOrder.ShipCity;
            orderDetails.Freight = newOrder.Freight;
            orderDetails.ShipCountry = newOrder.ShipCountry;
            this.DynamicOrders.Add(orderDetails);
        }

        /// <summary>
        /// Determines whether this instance [can update order] the specified new order.
        /// </summary>
        /// <param name="newOrder">The new order.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can update order] the specified new order; otherwise, <c>false</c>.
        /// </returns>
        bool CanUpdateOrder(dynamic newOrder)
        {
            return this.SelectedOrder != null;
        }

        /// <summary>
        /// Determines whether this instance [can delete order] the specified new order.
        /// </summary>
        /// <param name="newOrder">The new order.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can delete order] the specified new order; otherwise, <c>false</c>.
        /// </returns>
        bool CanDeleteOrder(dynamic newOrder)
        {
            return this.SelectedOrder != null;
        }

        /// <summary>
        /// Updates the order handler.
        /// </summary>
        /// <param name="newOrder">The new order.</param>
        public void UpdateOrderHandler(dynamic newOrder)
        {
            if (newOrder == null)
                return;

            _selectedOrder.OrderID = newOrder.OrderID;
            _selectedOrder.CustomerID = newOrder.CustomerID;
            _selectedOrder.EmployeeID = newOrder.EmployeeID;
            _selectedOrder.ShipCity = newOrder.ShipCity;
            _selectedOrder.Freight = newOrder.Freight;
            _selectedOrder.ShipCountry = newOrder.ShipCountry;           
        }

        /// <summary>
        /// Deletes the zip code handler.
        /// </summary>
        /// <param name="Order">The zip code.</param>
        public void DeleteOrderHandler(dynamic Order)
        {
            if (Order == null)
                return;

            this.DynamicOrders.Remove(Order);
        }

        #endregion
    }
}
