using DCt1205.Services;
using DCT1205.Entity;
using DCT1205.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DCT1205.Services.implementation
{
    internal class PaymentRecordServices : IPaymentRecordServices
    {
        private readonly ApplicationDbContext _context;
        private decimal overTimeHours;
        private decimal contractualEarnings;
        public PaymentRecordServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task CreateByAsync(PaymentRecord record)
        {
            await _context.PaymentRecord.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll()
        {
            return _context.PaymentRecord
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var ListTaxYear = _context.TaxYear.Select(t => new SelectListItem
            {
                Text = t.YearOfTax,
                Value = t.Id.ToString()
            });
            return ListTaxYear;
        }

        public PaymentRecord GetById(int id)
        {
            return _context.PaymentRecord
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public TaxYear GetTaxYearById(int id)
        {
            return _context.TaxYear.FirstOrDefault(t => t.Id == id);
        }

        public decimal NetPay(decimal totalEarnings, decimal totalDeduction)
        {
            return totalEarnings - totalDeduction;
        }

        public decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours)
        {
            return overTimeHours * overtimeRate;
        }

        public decimal OvertimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if (hoursWorked < contractualHours)
            {
                overTimeHours = 0.0m;
            }
            else if (hoursWorked > contractualHours)
            {
                overTimeHours = hoursWorked - contractualHours;
            }
            return overTimeHours;
        }

        public decimal OvertimeRate(decimal hourlyRate)
        {
            return hourlyRate * 1.5m;
        }

        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFees)
        {
            return tax + nic + studentLoanRepayment + unionFees;
        }

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings)
        {
            return overtimeEarnings + contractualEarnings;
        }
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if (hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }
            return contractualEarnings;
        }
    }
}