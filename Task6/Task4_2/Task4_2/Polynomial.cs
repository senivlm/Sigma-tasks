using System;
using System.Collections.Generic;
using System.Text;

namespace Task4_2
{
    class Polynomial
    {
        private Monomial[] monomials;

        public Monomial[] Monomials
        {
            get { return monomials; }
            set 
            {
                try
                {
                    if (value == null)
                        throw new NullReferenceException("Null reference");
                    monomials = value;
                }
                catch(NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Polynomial()
        {
            monomials = null;
        }
        public Polynomial(Monomial monomial)
        {
            this.monomials = new Monomial[1];
            this.monomials[0] = new Monomial();
            this.monomials[0] = monomial.Copy();
        }
        
        public Polynomial(Monomial[] monomials)
        {
            bool repeatOrders = false;
            for (int i = 0; i < monomials.Length; ++i)
            {
                if (monomials.Length == 1)
                {
                    break;
                }
                for (int j = i + 1; j < monomials.Length; ++j)
                {
                    if (monomials[i].Equals(monomials[j]))
                    {
                        repeatOrders = true;
                        break;
                    }
                }
                if (repeatOrders)
                {
                    break;
                }
            }
            try
            {
                if (repeatOrders)
                    throw new Exception("Repetitive orders in monomials");
                this.monomials = new Monomial[monomials.Length];
                for (int i = 0; i < monomials.Length; ++i)
                {
                    this.monomials[i] = new Monomial();
                    this.monomials[i] = monomials[i].Copy();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public double this[int m]
        {
            get { return monomials[m].C; }
            set 
            {
                bool exist = false;
                if (value != 0)
                {
                    for (int i = 0; i < monomials.Length; ++i)
                    {
                        if (monomials[i].Order == m)
                            exist = true;
                    }
                    if (exist)
                        monomials[m].C = value;
                    else
                    {
                        Monomial[] duplicateMonomials = new Monomial[monomials.Length];
                        for (int i = 0; i < monomials.Length; ++i)
                        {
                            duplicateMonomials[i] = new Monomial();
                            duplicateMonomials[i] = monomials[i].Copy();
                        }
                        monomials = new Monomial[duplicateMonomials.Length + 1];
                        for (int i = 0; i < duplicateMonomials.Length; ++i)
                        {
                            monomials[i] = new Monomial();
                            monomials[i] = duplicateMonomials[i].Copy();
                        }
                        monomials[monomials.Length - 1] = new Monomial();
                        monomials[monomials.Length - 1].C = value;
                        monomials[monomials.Length - 1].Order = m;
                    }
                }
                else if (value == 0)
                {
                    for (int i = 0; i < monomials.Length; ++i)
                    {
                        if (monomials[i].Order == m)
                            exist = true;
                    }
                    if (exist)
                    {
                        Monomial[] duplicateMonomials = new Monomial[monomials.Length];
                        for (int i = 0; i < monomials.Length; ++i)
                        {
                            duplicateMonomials[i] = new Monomial();
                            duplicateMonomials[i] = monomials[i].Copy();
                        }
                        monomials = new Monomial[duplicateMonomials.Length - 1];
                        for (int i = 0, j = 0; i < monomials.Length; ++i, ++j)
                        {
                            if (j == m)
                            {
                                ++j;
                            }
                            monomials[i] = duplicateMonomials[j].Copy();
                        }
                    }
                }
                BubbleSort(ref monomials);
            }
        }

        public override string ToString()
        {
            string result = "";
            try
            {
                if (monomials == null)
                    throw new Exception("Polynom is empty");
                BubbleSort(ref monomials);
                for (int i = 0; i < monomials.Length; ++i)
                {
                    if (monomials[i].Order == 0 && monomials.Length == 1)
                        result += monomials[i].C;
                    else if (monomials[i].Order == 0 && monomials.Length > 1 && monomials[i + 1].C > 0)
                        result += monomials[i].C + "+";
                    else if (monomials[i].Order == 0 && monomials.Length > 1 && monomials[i + 1].C < 0)
                        result += monomials[i].C + "-";
                    else
                    {
                        if (i == (monomials.Length - 1))
                        {
                            result += monomials[i].C + "*x^" + monomials[i].Order;
                        }
                        else
                        {
                            if (monomials[i + 1].C > 0)
                            {
                                if (monomials[i].C < 0)
                                {
                                    result += -(monomials[i].C) + "*x^" + monomials[i].Order + "+";
                                }
                                else
                                {
                                    result += monomials[i].C + "*x^" + monomials[i].Order + "+";
                                }
                            }
                            else if (monomials[i + 1].C < 0)
                            {
                                result += (monomials[i].C) + "*x^" + monomials[i].Order;
                            }
                        }
                    }
                }
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        private void Swap(ref Monomial[] array, int i, int j)
        {
            Monomial temp = array[i].Copy();
            array[i] = array[j].Copy();
            array[j] = temp.Copy();
        }

        private void BubbleSort(ref Monomial[] array)
        {
            for (int i = 0; i < (array.Length - 1); ++i)
            {
                for (int j = 1; j < (array.Length - i); ++j)
                {
                    if (array[j - 1].Order > array[j].Order)
                    {
                        Swap(ref array, j - 1, j);
                    }
                }
            }
        }

        private void DeleteMonomial(int index)
        {
            try
            {
                if (index < 0)
                    throw new IndexOutOfRangeException("Incorrect index");
                int numberNonNullMonomials = 0;
                for (int i = 0; i < monomials.Length; ++i)
                {
                    if (monomials[i] != null)
                    {
                        ++numberNonNullMonomials;
                    }
                }
                Monomial[] duplicateMonomials = new Monomial[numberNonNullMonomials];
                for (int i = 0; i < numberNonNullMonomials; ++i)
                {
                    duplicateMonomials[i] = monomials[i].Copy();
                }
                monomials = new Monomial[duplicateMonomials.Length];
                for (int i = 0, j = 0; i < duplicateMonomials.Length; ++i)
                {
                    if (i != index)
                    {
                        monomials[j] = duplicateMonomials[i].Copy();
                        ++j;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Parse(string s)
        {
            try 
            {
                if (s == "")
                    throw new ArgumentNullException("Line is empty");
                string[] split = s.Split('+',StringSplitOptions.RemoveEmptyEntries);
                string[][] part = new string[split.Length][];
                for (int i = 0; i < split.Length; ++i)
                {
                    string[] str = split[i].Split("*x^");
                    if (!double.TryParse(str[0], out double valueC))
                        throw new FormatException("Incorrect format of coefficient in monomial");
                    if (str.Length == 1)
                    {
                        part[i] = new string[str.Length + 1];
                        part[i][1] = "0";
                    }
                    else
                        part[i] = new string[str.Length];
                    part[i][0] = str[0];
                    if (str.Length > 1)
                    {
                        if (!int.TryParse(str[1], out int valueOrder))
                            throw new FormatException("Incorrect format of order in monomial");
                        part[i][1] = str[1];
                    }
                }
                monomials = new Monomial[part.GetLength(0)];
                for (int i = 0; i < monomials.Length; ++i)
                {
                    monomials[i] = new Monomial(double.Parse(part[i][0]), int.Parse(part[i][1]));
                }
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Polynomial operator +(Polynomial polynomial1)
        {
            return polynomial1;
        }

        public static Polynomial operator -(Polynomial polynomial1)
        {
            Polynomial polynomial = new Polynomial();
            polynomial.monomials = new Monomial[polynomial1.monomials.Length];
            for (int i = 0; i < polynomial1.monomials.Length; ++i)
            {
                polynomial.monomials[i] = new Monomial(-(polynomial1.monomials[i].C), polynomial1.monomials[i].Order);
            }
            return polynomial;
        }

        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            Polynomial polynomial = new Polynomial();
            if (polynomial1.monomials.Length > polynomial2.monomials.Length)
            {
                polynomial.monomials = new Monomial[polynomial1.monomials.Length];
                for (int i = 0; i < polynomial1.monomials.Length; ++i)
                {
                    polynomial.monomials[i] = new Monomial();
                    polynomial.monomials[i] = polynomial1.monomials[i].Copy();
                }
                for (int i = 0; i < polynomial2.monomials.Length; ++i)
                {
                    if (polynomial1.monomials[i].Order == polynomial2.monomials[i].Order)
                        polynomial.monomials[i].C += polynomial2.monomials[i].C;
                }
            }
            else
            {
                polynomial.monomials = new Monomial[polynomial2.monomials.Length];
                for (int i = 0; i < polynomial2.monomials.Length; ++i)
                {
                    polynomial.monomials[i] = new Monomial();
                    polynomial.monomials[i] = polynomial2.monomials[i].Copy();
                }
                for (int i = 0; i < polynomial1.monomials.Length; ++i)
                {
                    if (polynomial1.monomials[i].Order == polynomial2.monomials[i].Order)
                        polynomial.monomials[i].C += polynomial1.monomials[i].C;
                }
            }
            return polynomial;
        }

        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            return polynomial1 + (-polynomial2);
        }

        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
        {
            Polynomial polynomial = new Polynomial();

            polynomial.monomials = new Monomial[polynomial1.monomials[polynomial1.monomials.Length - 1].Order + polynomial2.monomials[polynomial2.monomials.Length - 1].Order + 1];
            for (int i = 0; i < polynomial.monomials.Length; ++i)
            {
                polynomial.monomials[i] = new Monomial();
            }

            int k = 0;
            for (int i = 0; i < polynomial1.monomials.Length; ++i)
            {
                Monomial monomial = new Monomial();
                for (int j = 0; j < polynomial2.monomials.Length; ++j)
                {
                    monomial.C = polynomial1.monomials[i].C * polynomial2.monomials[j].C;
                    if (polynomial1.monomials[i].Order == 0 && polynomial2.monomials[j].Order != 0)
                    {
                        monomial.Order = (polynomial1.monomials[i].Order + 1) * polynomial2.monomials[j].Order;
                    }
                    else if (polynomial1.monomials[i].Order != 0 && polynomial2.monomials[j].Order == 0)
                    {
                        monomial.Order = polynomial1.monomials[i].Order * (polynomial2.monomials[j].Order + 1);
                    }
                    else
                    {
                        monomial.Order = polynomial1.monomials[i].Order + polynomial2.monomials[j].Order;
                    }

                    bool repetitiveOrder = false;
                    for (int u = 0; u < polynomial.monomials.Length; ++u)
                    {
                        if (monomial.Order == polynomial.monomials[u].Order)
                        {
                            repetitiveOrder = true;
                            if (monomial.Order == 0 && polynomial.monomials[u].Order == 0)
                            {
                                ++k;
                                polynomial.monomials[u].C += monomial.C;
                                break;
                            }
                            else
                            {
                                polynomial.monomials[u].C += monomial.C;
                                break;
                            }
                        }
                    }

                    if (!repetitiveOrder)
                    {
                        polynomial.monomials[k].C = monomial.C;
                        polynomial.monomials[k].Order = monomial.Order;
                        ++k;
                    }
                }
            }

            return polynomial;
        }

        public static implicit operator Polynomial(double number)
        {
            Monomial monomial = new Monomial(number, 0);
            Polynomial polynomial = new Polynomial(monomial);
            return polynomial;
        }
    }
}
