using ApiDeEstudo.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiDeEstudo.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get;private set; }
        public int PersonId {  get; private set; }
        public DateTime Date {  get; private set; }
        public Person Person { get; private set; }
        public Product Product { get; private set; }
        
        public  Purchase(int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date);
        }

        public Purchase(int id,int productId ,int personId, DateTime? date)
        {
            DomainValidationsException.When(id < 0, "Id deve ser informado");
            Id = id;
            Validation(productId, personId, date);
        }

        private void Validation(int productId, int personId, DateTime? date)
        {
            DomainValidationsException.When(productId < 0, "Id Produto deve ser informado");
            DomainValidationsException.When(personId < 0 , "Id PessoaERP deve ser informado");
            DomainValidationsException.When(date.HasValue, "Data deve ser informado");

            ProductId = productId;
            PersonId = personId;
            Date = date.Value;
        }
    }
}
