﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BankingProductCategory
    {
        BUSINESS_LOANS,
        CRED_AND_CHRG_CARDS,
        LEASES,
        MARGIN_LOANS,
        OVERDRAFTS,
        PERS_LOANS,
        REGULATED_TRUST_ACCOUNTS,
        RESIDENTIAL_MORTGAGES,
        TERM_DEPOSITS,
        TRADE_FINANCE,
        TRANS_AND_SAVINGS_ACCOUNTS,
        TRAVEL_CARDS
    }
}
