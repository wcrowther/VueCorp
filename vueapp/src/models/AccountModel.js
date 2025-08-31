
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
    this.IsInvoice          = false
    this.IsAutoPay          = false
    this.IsActive           = false 
    this.CreatedDate        = null
    this.ModifiedDate       = null
    this.CreatorId          = 0
    this.ModifierId         = 0
    this.CreatorName        = ''
    this.ModifierName       = ''
}

export
{
    AccountModel
}
