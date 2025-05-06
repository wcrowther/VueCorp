
function UserModel (userId, userName, firstName, lastName, userEmail, role)
{
	this.UserId			= userId || 0
	this.UserName		= userName || ''
	this.FirstName		= firstName || ''
	this.LastName		= lastName  || ''
	this.UserEmail		= userEmail  || ''
	this.Role			= role  || 'User'
	this.IsActive       = false 
    this.CreatedDate    = null 
    this.ModifiedDate   = null 
    this.CreatedId      = 0
    this.ModifiedId     = 0
	this.CreatorName    = ''
    this.ModifierName   = ''
}

export
{
	UserModel
}
