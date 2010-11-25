﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;
using NHibernate.Criterion;

namespace Raisins.Services
{
    [ActiveRecord]
    public class Beneficiary : ActiveRecordBase<Beneficiary>
    {

        [PrimaryKey(PrimaryKeyType.Identity)]
        public long ID { get; set; }

        [Property]
        public string Name { get; set; }

        [Property]
        public string Description { get; set; }

        [HasMany]
        public IList<Payment> Payments { get; set; }

        public decimal GetTotalAmount()
        {
            ScalarQuery<decimal> query = new ScalarQuery<decimal>(typeof(Payment), "select sum(payment.Amount) from Payment payment where payment.Beneficiary = ?", this);

            return query.Execute();
        }

        public long GetTotalVotes()
        {
            ScalarQuery<long> query = new ScalarQuery<long>(typeof(Ticket), "select count(ticket) from Ticket ticket where ticket.Payment.Beneficiary = ?", this);

            return query.Execute();
        }

        public static Beneficiary FindByName(string name)
        {
            return FindFirst(Expression.Eq("Name", name));
        }
    }
}
