using ApiDeEstudo.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeEstudo.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; private set; }

        public Product(string name, string codErp, decimal price) 
        {
            Validation(name, codErp, price);
        }

        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationsException.When(id < 0, "Id deve ser informado");

            Id = id;
            Validation(name, codErp, price);
        }

        private void Validation(string name, string codErp, decimal price) 
        {
            DomainValidationsException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationsException.When(string.IsNullOrEmpty(codErp), "Código ERP deve ser informado");
            DomainValidationsException.When(price < 0, "Preço deve ser informado");

            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
