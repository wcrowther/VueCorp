
function Account (accountId, accountName)
{
    this.AccountId          = accountId || 0
    this.AccountName        = accountName || ''
    this.AccountEmail       = ''      
    this.AccountPhone       = '' 
    this.StreetAddress      = '' 
    this.City               = '' 
    this.StateProvince      = '' 
    this.PostalCode         = ''
    this.IsInvoiceAccount     = false
    this.IsAutoPay            = false
    this.IsActive           = false 
}

export
{
    Account
}
