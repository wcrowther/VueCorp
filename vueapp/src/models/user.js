
function User (userId, userName, firstName, lastName, userEmail, role)
{
	this.UserId		= userId || 0
	this.UserName	= userName || ''
	this.FirstName	= firstName || ''
	this.LastName	= lastName  || ''
	this.UserEmail	= userEmail  || ''
	this.Role		= role  || 'User'
}

export
{
	User
}
