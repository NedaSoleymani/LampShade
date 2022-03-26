using _0_Framework.Application;
using _0_Framwork.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustomerDiscount:EntityBase
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequeired)]
        public long ProductId { get; private set; }

        [Range(1, 99, ErrorMessage = ValidationMessages.IsRequeired)]
        public int DiscountRate { get; private set; }

       [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public DateTime StartDate { get; private set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public DateTime EndDate { get; private set; }
       // public bool IsActive { get; set; }
        public string Reason { get; private set; }

        public CustomerDiscount(long productId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            //IsActive = true;
        }

        public void Edit(long productId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }


    }
}
