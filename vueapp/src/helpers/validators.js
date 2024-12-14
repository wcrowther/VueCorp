import 
{ 
    required,
    minLength,
    maxLength

} from '@vuelidate/validators'

export const accountValidator = 
{
    AccountName:        { required },
    AccountEmail:       { required },
    AccountPhone:       { required },
    StreetAddress:      { required },
    City:               { required },
    StateProvince:      { required },
    PostalCode:         { required, minLength: minLength(5), maxLength: maxLength(10) },
    IsActive:           {},
    IsAutoPay:          {},
    IsInvoiceAccount:   {}
}

export const authRequestValidator = 
{
    UserName:           { required }, 
    Password:           { required }
}

export const authSignupValidator = 
{
    UserName:           { required }, 
    Password:           { required },
	UserEmail:          { required },
	FirstName:          { required },
	LastName:           { required }
}

export const userValidator = 
{
	FirstName:          { required },
	LastName:           { required },
	UserName:           { required },
	UserEmail:          { required },
    Role:               { required }
}

