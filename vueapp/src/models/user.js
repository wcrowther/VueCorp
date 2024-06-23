
function User (userId, firstName, lastName, userEmail, role)
{
    this.UserId             = userId || 0
    this.FirstName          = firstName || ''
    this.LastName           = lastName  || ''     
    this.UserEmail          = userEmail  || ''     
    this.Role               = role  || ''     
}

export
{
    User
}
