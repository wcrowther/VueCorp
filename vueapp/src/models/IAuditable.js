
function IAuditable (dateCreated, dateModified, creatorName, modifierName)
{
	this.DateCreated 	= dateCreated
	this.DateModified 	= dateModified
	this.CreatorName 	= creatorName
	this.ModifierName 	= modifierName
}

export { IAuditable }
