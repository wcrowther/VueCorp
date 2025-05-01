
function IAuditable (dateCreated, dateModified, creatorId, modifierId )
{
	this.DateCreated 	= dateCreated
	this.DateModified 	= dateModified
	this.CreatorId		= creatorId
	this.ModifierId 	= modifierId
}

export { IAuditable }
