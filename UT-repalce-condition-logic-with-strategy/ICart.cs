using System;
using System.Collections.Generic;
using System.Text;

namespace repalce_condition_logic_with_strategy
{
    interface IShipping
    {
        //double shippingFee(string shipper, double length, double width, double height, double weight);
        //double shippingFee(double length, double width, double height, double weight);
        double Shipping();
    }
}
