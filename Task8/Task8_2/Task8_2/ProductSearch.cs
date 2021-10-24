using System;
using System.Collections.Generic;
using System.Text;

namespace Task8_2
{
    class ProductSearch
    {
        public delegate List<Product> FindProducts(Storage firstStorage, Storage secondStorage);

        private FindProducts del;

        public FindProducts Del
        {
            get { return del; }
        }

        public ProductSearch()
        {
            del = null;
        }
        public void RegisterDelegate(FindProducts del)
        {
            this.del += del;
        }
        public void RemoveDelegate(FindProducts del)
        {
            this.del -= del;
        }
    }
}
