
function MessageModel ( creatorId, messageText)
{
    this.MessageId          = 0
    this.MessageText        = messageText || ''
    this.CreatedDate        = null
    this.ModifiedDate       = null
    this.CreatorId          = creatorId
    this.ModifierId         = creatorId
    this.CreatorName        = ''
    this.ModifierName       = ''
}

export
{
    MessageModel
}
