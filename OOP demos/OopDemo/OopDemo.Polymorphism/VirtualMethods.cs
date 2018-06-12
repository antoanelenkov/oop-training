using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopDemo.Polymorphism
{
    public abstract class EuropeanCountry
    {
        public string GetName()
        {
            return "European country";
        }

        public virtual string GetCurrency()
        {
            return "EURO";
        }
    }

    public class Bulgaria : EuropeanCountry
    {
        public new string GetName()
        {
            return "Bulgaria";
        }

        public override string GetCurrency()
        {
            return "BGN";
        }
    }

    public class France : EuropeanCountry
    {
        public new string GetName()
        {
            return "France";
        }
    }
}
