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
    UserName:           { required, minLength: minLength(6) }, 
    Password:           { required, minLength: minLength(6) }
}

export const authSignupValidator = 
{
    UserName:           { required }, 
    Password:           { required, minLength: minLength(6) }, 
	UserEmail:          { required, minLength: minLength(6) },
	FirstName:          { required },
	LastName:           { required }
}

export const userValidator = 
{
	FirstName:          { required },
	LastName:           { required },
	UserName:           { required },
	UserEmail:          { required, minLength: minLength(6) },
    Role:               { required }
}
