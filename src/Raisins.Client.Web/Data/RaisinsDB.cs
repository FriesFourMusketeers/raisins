﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Raisins.Client.Web.Models;

namespace Raisins.Client.Web.Data
{
    public class RaisinsDB : DbContext
    {
        static RaisinsDB _instance = null;

        public static RaisinsDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RaisinsDB();
                }

                return _instance;
            }
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<WinnerLog> WinnerLogs { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}