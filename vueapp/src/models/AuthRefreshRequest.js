
function AuthRefreshRequest (userId, refreshToken)
{
	this.UserId			= userId || ''
	this.RefreshToken	= refreshToken || ''
}

export { AuthRefreshRequest }
