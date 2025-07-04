
export const useMessageStore = defineStore('MessagesStore',
{
    state: () => 
    ({
        newMessage: '',
        messages: [],
    }),
    getters:{},
    actions:
    {
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
    }
})
