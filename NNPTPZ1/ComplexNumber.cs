﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPTPZ1
{
    public class ComplexNumber
    {
        public double RealPart { get; set; }
        public double ImaginaryPart { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
            {
                ComplexNumber numberToCompare = obj as ComplexNumber;
                return numberToCompare.RealPart == RealPart && numberToCompare.ImaginaryPart == ImaginaryPart;
            }
            return base.Equals(obj);
        }

        public readonly static ComplexNumber Zero = new ComplexNumber()
        {
            RealPart = 0,
            ImaginaryPart = 0
        };

        public ComplexNumber Multiply(ComplexNumber complexNumberArgument)
        {
            ComplexNumber complexNumberBase = this;
            return new ComplexNumber()
            {
                RealPart = complexNumberBase.RealPart * complexNumberArgument.RealPart - complexNumberBase.ImaginaryPart * complexNumberArgument.ImaginaryPart,
                ImaginaryPart = complexNumberBase.RealPart * complexNumberArgument.ImaginaryPart + complexNumberBase.ImaginaryPart * complexNumberArgument.RealPart
            };
        }
        public double GetAbS() => Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart);

        public ComplexNumber Add(ComplexNumber complexNumberArgument)
        {
            ComplexNumber complexNumberBase = this;
            return new ComplexNumber()
            {
                RealPart = complexNumberBase.RealPart + complexNumberArgument.RealPart,
                ImaginaryPart = complexNumberBase.ImaginaryPart + complexNumberArgument.ImaginaryPart
            };
        }
        public double GetAngleInDegrees() => Math.Atan(ImaginaryPart / RealPart);

        public ComplexNumber Subtract(ComplexNumber complexNumberArgument)
        {
            ComplexNumber complexNumberBase = this;
            return new ComplexNumber()
            {
                RealPart = complexNumberBase.RealPart - complexNumberArgument.RealPart,
                ImaginaryPart = complexNumberBase.ImaginaryPart - complexNumberArgument.ImaginaryPart
            };
        }

        public override string ToString() => $"({RealPart} + {ImaginaryPart}i)";

        internal ComplexNumber Divide(ComplexNumber complexNumber)
        {
            ComplexNumber dividedNumber = this;
            double divider = (complexNumber.RealPart * complexNumber.RealPart) + (complexNumber.ImaginaryPart * complexNumber.ImaginaryPart);

            double realPartCalculated = ((dividedNumber.RealPart * complexNumber.RealPart) + (dividedNumber.ImaginaryPart * complexNumber.ImaginaryPart)) / divider;
            double imaginaryPartCalculated = ((dividedNumber.ImaginaryPart * complexNumber.RealPart) - (dividedNumber.RealPart * complexNumber.ImaginaryPart)) / divider;
            
            return new ComplexNumber()
            {
                RealPart = realPartCalculated,
                ImaginaryPart = imaginaryPartCalculated
            };
        }
    }
}
