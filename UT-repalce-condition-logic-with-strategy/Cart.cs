using System;
using System.Collections.Generic;
using System.Text;

namespace repalce_condition_logic_with_strategy
{
    public class Cart
    {
        public double shippingFee(string shipper, double length, double width, double height, double weight)
        {
            return this.ShippingFactory(shipper, length, width, height, weight).Shipping();                
        }

        private IShipping ShippingFactory(string shipper, double length, double width, double height, double weight)
        {
            IShipping f;
            
            if (shipper.Equals("black cat"))
            {
                f = new BlackCat(weight);
            }
            else if (shipper.Equals("hsinchu"))
            {
                f = new HsinchuCat(length, width, height);
            }
            else if (shipper.Equals("post office"))
            {
                f = new PostOfficeCat(length, width, height, weight);
            }
            else
                throw new ArgumentException("shipper not exist");

            return f;
        }
    }

    public class BlackCat : IShipping
    {
        private double weight;

        public BlackCat(double _weight)
        {
            weight = _weight;
        }

        public double Shipping()
        {
            if (weight > 20)
            {
                return 500;
            }
            else
            {
                return 100 + weight * 10;
            }
        }
    }

    public class HsinchuCat : IShipping
    {
        private double length;
        private double width;
        private double height;

        public HsinchuCat(double _length, double _width, double _height)
        {
            length = _length;
            width = _width;
            height = _height;
        }

        public double Shipping()
        {
            double size = length * width * height;
            if (length > 100 || width > 100 || height > 100)
            {
                return size * 0.00002 * 1100 + 500;
            }
            else
            {
                return size * 0.00002 * 1200;
            }
        }
    }

    public class PostOfficeCat : IShipping
    {
        private double length;
        private double width;
        private double height;
        private double weight;

        public PostOfficeCat(double _length, double _width, double _height, double _weight)
        {
            length = _length;
            width = _width;
            height = _height;
            weight = _weight;
        }

        public double Shipping()
        {
            double feeByWeight = 80 + weight * 10;
            double size = length * width * height;
            double feeBySize = size * 0.00002 * 1100;
            return feeByWeight < feeBySize ? feeByWeight : feeBySize;
        }
    }
}
