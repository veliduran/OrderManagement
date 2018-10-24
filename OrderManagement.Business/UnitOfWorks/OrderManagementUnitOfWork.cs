using OrderManagement.Business.Repositories;
using OrderManagement.DataAccess;
using OrderManagement.DataAccess.Entities;
using System;
using System.Transactions;

namespace OrderManagement.Business.UnitOfWorks
{
    public class OrderManagementUnitOfWork : IUnitOfWork
    {
        private OrderManagementContext _context = new OrderManagementContext();
        private EFRepository<Customer> _customerRepository;
        private EFRepository<Order> _orderRepository;
        private EFRepository<OrderDetail> _orderDetailRepository;
        private EFRepository<Product> _productRepository;
        private bool _disposed = false;

        public EFRepository<Customer> CustomerRepository
        {
            get
            {
                if (_customerRepository ==null)
                {
                    _customerRepository = new EFRepository<Customer>(_context);
                }
                return _customerRepository;
            }
        }

        public EFRepository<Order> OrderRepository
        {
            get
            {
                if (_orderRepository==null)
                {
                    _orderRepository = new EFRepository<Order>(_context);
                }
                return _orderRepository;
            }
        }

        public EFRepository<OrderDetail> OrderDetailRepository
        {
            get
            {
                if (_orderDetailRepository == null)
                {
                    _orderDetailRepository = new EFRepository<OrderDetail>(_context);
                }
                return _orderDetailRepository;
            }
        }

        public EFRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new EFRepository<Product>(_context);
                }
                return _productRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Save();
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                _context.SaveChanges();
                tScope.Complete();
            }
        }
    }
}
