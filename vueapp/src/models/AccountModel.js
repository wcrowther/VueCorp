
function AccountModel (accountId, accountName)
{
    this.AccountId          = accountId || 0
    this.AccountName        = accountName || ''
    this.AccountEmail       = ''      
    this.AccountPhone       = '' 
    this.StreetAddress      = '' 
    this.City               = '' 
    this.StateProvince      = '' 
    this.PostalCode         = ''
    this.IsInvoiceAccount   = false
    this.IsAutoPay          = false
    this.IsActive           = false 
    this.CreatedDate        = null 
    this.ModifiedDate       = null 
    this.CreatedId          = 0
    this.ModifiedId         = 0
}

export
{
    AccountModel
}
