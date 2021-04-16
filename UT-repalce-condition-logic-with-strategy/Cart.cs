using System;
using System.Collections.Generic;
using System.Text;

namespace repalce_condition_logic_with_strategy
{
    public class Cart
    {
        public double shippingFee(string shipper, double length, double width, double height, double weight)
        {
            ICart cart = null;
            if (shipper.Equals("black cat"))
            {
                cart = new BlackCat(weight);
            }
            else if (shipper.Equals("hsinchu"))
            {
                cart = new HsinchuCat(length, width, height);
            }
            else if (shipper.Equals("post office"))
            {
                cart = new PostOfficeCat(length, width, height, weight);
            }

            if (cart == null)
                throw new ArgumentException("shipper not exist");

            return cart.shippingFee();
        }
    }

    public class BlackCat : ICart
    {
        private double weight;

        public BlackCat(double _weight)
        {
            weight = _weight;
        }

        public double shippingFee()
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

    public class HsinchuCat : ICart
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

        public double shippingFee()
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

    public class PostOfficeCat : ICart
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

        public double shippingFee()
        {
            double feeByWeight = 80 + weight * 10;
            double size = length * width * height;
            double feeBySize = size * 0.00002 * 1100;
            return feeByWeight < feeBySize ? feeByWeight : feeBySize;
        }
    }
}
