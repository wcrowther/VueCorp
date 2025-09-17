
export default class AccountModel 
{
    constructor(accountId = 0, accountName = '') 
    {
        this.AccountId = accountId;
        this.AccountName = accountName;
        this.AccountEmail = '';
        this.AccountPhone = '';
        this.StreetAddress = '';
        this.City = '';
        this.StateProvince = '';
        this.PostalCode = '';
        this.IsInvoice = false;
        this.IsAutoPay = false;
        this.IsActive = false;
        this.CreatedDate = null;
        this.ModifiedDate = null;
        this.CreatorId = 0;
        this.ModifierId = 0;
        this.CreatorName = '';
        this.ModifierName = '';
    }
}
