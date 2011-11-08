﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raisins.Client.Web.Data;

namespace Raisins.Client.Web.Models
{
    public class Beneficiary
    {
        public int BeneficiaryID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public static Beneficiary Get(int id)
        {
            return RaisinsDB.Instance.Beneficiaries.Where(beneficiary => beneficiary.BeneficiaryID == id).FirstOrDefault();
        }

        public static Beneficiary[] GetAll(string userName)
        {
            var account = Account.FindUser(userName);

            if (account.Setting != null && account.Setting.BeneficiaryID > 0)
            {
                return new Beneficiary[] { Get(account.Setting.BeneficiaryID) };
            }
            else
            {
                return RaisinsDB.Instance.Beneficiaries.DefaultIfEmpty().ToArray();
            }
        }
    }
}