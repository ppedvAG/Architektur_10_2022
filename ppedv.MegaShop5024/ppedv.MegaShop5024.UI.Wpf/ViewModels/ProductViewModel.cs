using ppedv.MegaShop5024.Model.Contracts;
using ppedv.MegaShop5024.Model.DomainModel;
using System;
using System.Collections.Generic;

namespace ppedv.MegaShop5024.UI.Wpf.ViewModels
{
    public class ProductViewModel
    {
        //todo bessere DI
        private IRepository _repo = new Data.EfCore.EfRepository();

        public List<Product> ProductList { get; set; } = new List<Product>();

        public Product SelectedProduct { get; set; }

        public ProductViewModel()
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            ProductList.Clear();
            foreach (var item in _repo.Query<Product>())
            {
                ProductList.Add(item);
            }
        }
    }
}
