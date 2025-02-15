
function AuthUser (	userId, firstName, lastName, userName, userEmail, role, 
					token, tokenExpiration, refreshToken, refreshTokenExpiration)
{
	this.UserId  				= userId 	|| 0
	this.FirstName 				= firstName || ''
	this.LastName 				= lastName 	|| ''
	this.UserName 				= userName 	|| ''
	this.UserEmail 				= userEmail || ''
	this.Role 					= role 		|| ''
	this.Token 					= token 		|| ''
	this.RefreshToken 			= refreshToken 	|| ''
	this.TokenExpiration 		= tokenExpiration 		 || ''
	this.RefreshTokenExpiration = refreshTokenExpiration || ''
}

export { AuthUser }

	
