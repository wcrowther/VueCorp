
function User (userId, firstName, lastName, userEmail, roles)
{
    this.UserId             = userId || 0
    this.FirstName          = firstName || ''
    this.LastName           = lastName  || ''     
    this.UserEmail          = userEmail  || ''     
    this.Roles              = roles  || ''     
}

export
{
    User
}
