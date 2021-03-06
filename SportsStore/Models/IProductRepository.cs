﻿using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models {

    public interface IProductRepository {

        IQueryable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);

        List<Product> SearchProducts(string search);
    }
}
