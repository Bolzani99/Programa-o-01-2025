﻿
namespace Modelo
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? HomeAddress { get; set; }
        public string? WorkAddress { get; set; }
        
        public static InstanceCount = 0; 
        public int ObjectCount = 0;
        public bool Validade()
        {
            return true;
        }
        
        public Customer Retrieve()
        {
            return new Customer();
        }

        public void Save(Customer customer)
        {         
            
        }

    }

}
