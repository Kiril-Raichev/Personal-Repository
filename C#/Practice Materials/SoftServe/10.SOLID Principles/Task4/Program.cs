using System;

namespace Task4
{
    class Program
    {
        // Open Closed Principle code change
        //public enum InvoiceType
        //{
        //    Final,
        //    Proposed,
        //    RecurringInvoice
        //};
        //class Invoice
        //{
        //    public InvoiceType InvoiceType { get; set; }
        //    public double GetDiscount(double amount, InvoiceType invoiceType)
        //    {
        //        double finalAmount = 0;
        //        if (invoiceType == InvoiceType.Final)
        //        {
        //            finalAmount = amount - amount * 0.03;
        //        }
        //        else if (invoiceType == InvoiceType.Proposed)
        //        {
        //            finalAmount = amount - amount * 0.05;
        //        }
        //        return finalAmount;
        //    }
        //}
        public class Invoice
        {
            public virtual double GetDiscount(double amount)
            {
                return amount;
            }
        }
        public class FinalInvoice : Invoice
        {
            public override double GetDiscount(double amount)
            {
                return base.GetDiscount(amount - (amount * 0.03));
            }
        }
        public class ProposedInvoice : Invoice
        {
            public override double GetDiscount(double amount)
            {
                return base.GetDiscount(amount - (amount * 0.05));
            }
        }
        public class RecurringInvoice : Invoice
        {
            public override double GetDiscount(double amount)
            {
                return base.GetDiscount(amount - (amount * 0.10));
            }
        }
        public class OrdinaryInvoice : Invoice
        {
            public override double GetDiscount(double amount)
            {
                return base.GetDiscount(amount - (amount * 0.01));
            }
        }
        static void Main(string[] args)
        {

        
    }
    }
}

