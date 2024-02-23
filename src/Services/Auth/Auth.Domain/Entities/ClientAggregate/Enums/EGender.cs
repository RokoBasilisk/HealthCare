using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.ClientAggregate.Enums
{
    public class EGender : Enumeration
    {
        public static EGender Male = new(0, nameof(Male));
        public static EGender Female = new(1, nameof(Female));

        public EGender() : this(default, "Unknown") { }

        public EGender(int id, string value) : base(id, value)
        {
        }

        public static EGender GetById(int id)
        {
            if (id == Male.Id) 
                return Male;
            else if (id == Female.Id)
                return Female;
            else
            {
                return new EGender();
            }
        }
    }
}
