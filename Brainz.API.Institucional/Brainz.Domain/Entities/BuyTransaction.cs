using Brainz.Domain.Enumerators;
using System;
using System.Collections.Generic;

namespace Brainz.Domain.Entities
{
    public class BuyTransaction
    {
        public Guid Id { get; private set; }
        public float TotalValue { get; private set; }
        public PaymentTypeEnum PaymentType { get; private set; }
        public CustomerInfo CustomerInfos { get; private set; }
        public List<BuyedCourse> BuyedCourses { get; private set; }
        public Person Person { get; private set; }
        public string CustomerInfo { get; private set; }
        public Guid PersonId { get; private set; }
        public int TotalInstallments { get; private set; }
        public DateTime PaymentConfirmationDate { get; private set; }
    }
}
