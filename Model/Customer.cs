using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace E3RestService.Model
{
    [DataContract]
    public class Customer
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private int _regYear;

        public Customer()
        {
            
        }
        
        public Customer(int id, string firstName, string lastName, int regYear)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _regYear = regYear;
        }

        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [DataMember]
        public int RegYear
        {
            get { return _regYear; }
            set { _regYear = value; }
        }
    }
}
