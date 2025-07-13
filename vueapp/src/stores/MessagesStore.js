export const useMessagesStore = defineStore('MessagesStore',
{
    state: () => 
    ({
        message: {},
        messages: [],
    }),
    getters:{},
    actions:
    {
        async addNewMessage(userId, messageText)
        {
            this.message = new MessageModel(userId, messageText)
        },
        async getAllMessages ()
        {
            try 
            {
                console.log('--- >>> Get All Messages From Server')
                
                const result = await apiGet(`/messages/getAllMessages`)
                
                if(result.success) 
                    this.messages   = result.data.Result

            }
            catch (err){ useToastStore().showError(err.message) }
        },
        async saveMessage ()
        {
            try 
            {
                console.log(`--- >>> Save Message To Server`)
                
                const result = await apiPost(`/messages/saveMessage`, this.message)
                
                if(result.success) 
                {
                    this.message   = result.data.Result   
                }

                return this.message
            }
            catch (err){ useToastStore().showError(err.message) }
        },
    }
})
