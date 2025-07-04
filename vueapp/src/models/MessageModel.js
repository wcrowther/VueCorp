
function MessageModel (messageId, messageText)
{
    this.MessageId          = messageId || 0
    this.MessageText        = messageText || ''
    this.CreatedDate        = null
    this.ModifiedDate       = null
    this.CreatorId          = 0
    this.ModifierId         = 0
    this.CreatorName        = 'Fred'
    this.ModifierName       = ''
}

export
{
    MessageModel
}
