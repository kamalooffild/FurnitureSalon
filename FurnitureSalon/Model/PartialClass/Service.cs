using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FurnitureSalon.Model;

namespace FurnitureSalon.Model
{
    public partial class Service
    {
        public string StrDiscount
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return "";
                else
                    return $"* скидка {Discount * 100}%"; ;
            }
        }



        public decimal CostDiscount
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return (decimal)Cost;
                else
                    return (decimal)Cost - Convert.ToDecimal(Cost) * Convert.ToDecimal(Discount);

            }
        }

        public string Color
        {
            get
            {
                if (Discount > 0)
                    return "#bdffbd";
                else return "#FFFFFF";
            }
        }
    }
}
