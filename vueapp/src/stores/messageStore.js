
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
        async getMessages ()
        {         
            try 
            {
                // console.log('--- >>> Get Messages From Server')
                // 
                // const result = await apiPost(`/messages/getMessages`)
                // 
                // if(result.success) 
                // {
                //     this.messages  = Object.assign(new PagerModel(), result.data.Pager)
                // }

                throw new Error('Not implemented yet')
            }
            catch (err){ useToastStore().showError(err.message) }
        },
    }
})

